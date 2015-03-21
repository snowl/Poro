using Mono.Security.Authenticode;
using Mono.Security.X509;
using Mono.Security.X509.Extensions;
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
            string subject = "CN=" + subjectName;
            RSA subjectKey = new RSACryptoServiceProvider(2048);

            // serial number MUST be positive
            if ((sn[0] & 0x80) == 0x80)
                sn[0] -= 0x80;

            X509CertificateBuilder cb = new X509CertificateBuilder(3);
            cb.SerialNumber = sn;
            cb.IssuerName = subject;
            cb.NotBefore = DateTime.Now;
            cb.NotAfter = new DateTime(643445675990000000);
            cb.SubjectName = subject;
            cb.SubjectPublicKey = subjectKey;
            cb.Hash = "SHA1";

            byte[] rawcert = cb.Sign(subjectKey);

            PKCS12 p12 = new PKCS12();
            p12.AddCertificate(new Mono.Security.X509.X509Certificate(rawcert));
            p12.AddPkcs8ShroudedKeyBag(subjectKey);
            return new X509Certificate2(p12.GetBytes());
        }
    }
}
