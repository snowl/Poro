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
        /// <summary>
        /// Generates a self-signed X509Certificate2.
        /// </summary>
        /// <param name="subjectName">The server name to generate for</param>
        /// <returns>A self-signed certificate</returns>
        public static X509Certificate2 CreateSelfSignedCertificate(string subjectName)
        {
            //Generate a serial number for the certificate.
            byte[] sn = Guid.NewGuid().ToByteArray();
            string subject = "CN=" + subjectName;

            //Use 2048-bit RSA for the public & private key
            RSA subjectKey = new RSACryptoServiceProvider(2048);

            // serial number MUST be positive
            if ((sn[0] & 0x80) == 0x80)
                sn[0] -= 0x80;

            //Use the cert builder to create the certificate
            X509CertificateBuilder cb = new X509CertificateBuilder(3);
            cb.SerialNumber = sn;
            cb.IssuerName = subject;

            //Sets the date created to DateTime.Now
            cb.NotBefore = DateTime.Now;
            //Sets the expire date to some time way in the future
            cb.NotAfter = new DateTime(643445675990000000);
            cb.SubjectName = subject;
            
            //Sets the public key to the 2048-bit RSA key generate before
            cb.SubjectPublicKey = subjectKey;
            cb.Hash = "SHA1";

            //Sign the key with the RSA key
            byte[] rawcert = cb.Sign(subjectKey);

            //Creates a new PKCS12 bag to add the private key to the cert
            PKCS12 p12 = new PKCS12();
            p12.AddCertificate(new Mono.Security.X509.X509Certificate(rawcert));
            p12.AddPkcs8ShroudedKeyBag(subjectKey);

            //Return the generated certificate
            return new X509Certificate2(p12.GetBytes());
        }
    }
}
