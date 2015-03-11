using Mono.Security.Authenticode;
using Mono.Security.X509;
using Mono.Security.X509.Extensions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Certificate
{
    public static class CertGen
    {
        public static X509Certificate2 CreateSelfSignedCertificate(string subjectName)
        {
            byte[] sn = Guid.NewGuid().ToByteArray();
            DateTime notBefore = DateTime.Now;
            DateTime notAfter = new DateTime(643445675990000000); // 12/31/2039 23:59:59Z
            string subject = "CN=" + subjectName;
            string issuer = "CN=" + subjectName;
            RSA subjectKey = new RSACryptoServiceProvider(2048);
            RSA issuerKey = subjectKey;
            string hashName = "SHA1";

            BasicConstraintsExtension bce = new BasicConstraintsExtension
            {
                PathLenConstraint = BasicConstraintsExtension.NoPathLengthConstraint,
                CertificateAuthority = true
            };

            // serial number MUST be positive
            if ((sn[0] & 0x80) == 0x80)
                sn[0] -= 0x80;

            if (subject == null)
                throw new Exception("Missing Subject Name");

            X509CertificateBuilder cb = new X509CertificateBuilder(3);
            cb.SerialNumber = sn;
            cb.IssuerName = issuer;
            cb.NotBefore = notBefore;
            cb.NotAfter = notAfter;
            cb.SubjectName = subject;
            cb.SubjectPublicKey = subjectKey;
            cb.Hash = hashName;
            cb.Extensions.Add(bce);

            IDigest digest = new Sha1Digest();
            byte[] resBuf = new byte[digest.GetDigestSize()];
            var spki = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(DotNetUtilities.GetRsaPublicKey(issuerKey));
            byte[] bytes = spki.PublicKeyData.GetBytes();
            digest.BlockUpdate(bytes, 0, bytes.Length);
            digest.DoFinal(resBuf, 0);

            cb.Extensions.Add(new SubjectKeyIdentifierExtension { Identifier = resBuf });
            cb.Extensions.Add(new AuthorityKeyIdentifierExtension { Identifier = resBuf });

            byte[] rawcert = cb.Sign(issuerKey);



            PKCS12 p12 = new PKCS12();
            p12.Password = "";

            ArrayList list = new ArrayList();
            // we use a fixed array to avoid endianess issues 
            // (in case some tools requires the ID to be 1).
            list.Add(new byte[4] { 1, 0, 0, 0 });
            Hashtable attributes = new Hashtable(1);
            attributes.Add(PKCS9.localKeyId, list);

            p12.AddCertificate(new Mono.Security.X509.X509Certificate(rawcert), attributes);
            p12.AddPkcs8ShroudedKeyBag(subjectKey, attributes);
            p12.SaveToFile("cert.p12");

            var x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2("cert.p12", "", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable);



            return x509;
        }
    }
}
