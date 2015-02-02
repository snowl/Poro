using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace PoroLib.Users
{
    public class DPAPI
    {
        [DllImport("crypt32.dll",
                    SetLastError = true,
                    CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern
            bool CryptProtectData(ref DATA_BLOB pPlainText,
                                        string szDescription,
                                    ref DATA_BLOB pEntropy,
                                        IntPtr pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int dwFlags,
                                    ref DATA_BLOB pCipherText);

        [DllImport("crypt32.dll",
                    SetLastError = true,
                    CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern
            bool CryptUnprotectData(ref DATA_BLOB pCipherText,
                                    ref string pszDescription,
                                    ref DATA_BLOB pEntropy,
                                        IntPtr pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int dwFlags,
                                    ref DATA_BLOB pPlainText);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DATA_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CRYPTPROTECT_PROMPTSTRUCT
        {
            public int cbSize;
            public int dwPromptFlags;
            public IntPtr hwndApp;
            public string szPrompt;
        }

        static private IntPtr NullPtr = ((IntPtr)((int)(0)));

        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;

        private static void InitPrompt(ref CRYPTPROTECT_PROMPTSTRUCT ps)
        {
            ps.cbSize = Marshal.SizeOf(
                                      typeof(CRYPTPROTECT_PROMPTSTRUCT));
            ps.dwPromptFlags = 0;
            ps.hwndApp = NullPtr;
            ps.szPrompt = null;
        }

        private static void InitBLOB(byte[] data, ref DATA_BLOB blob)
        {
            if (data == null)
                data = new byte[0];

            blob.pbData = Marshal.AllocHGlobal(data.Length);

            if (blob.pbData == IntPtr.Zero)
                throw new Exception(
                    "Unable to allocate data buffer for BLOB structure.");

            blob.cbData = data.Length;
            Marshal.Copy(data, 0, blob.pbData, data.Length);
        }

        public enum KeyType { UserKey = 1, MachineKey };

        private static KeyType defaultKeyType = KeyType.UserKey;

        public static string Encrypt(string plainText)
        {
            return Encrypt(defaultKeyType, plainText, String.Empty,
                            String.Empty);
        }

        public static string Encrypt(KeyType keyType, string plainText)
        {
            return Encrypt(keyType, plainText, String.Empty,
                            String.Empty);
        }

        public static string Encrypt(KeyType keyType,
                                     string plainText,
                                     string entropy)
        {
            return Encrypt(keyType, plainText, entropy, String.Empty);
        }

        public static string Encrypt(KeyType keyType,
                                     string plainText,
                                     string entropy,
                                     string description)
        {
            if (plainText == null) plainText = String.Empty;
            if (entropy == null) entropy = String.Empty;

            return Convert.ToBase64String(
                    Encrypt(keyType,
                            Encoding.UTF8.GetBytes(plainText),
                            Encoding.UTF8.GetBytes(entropy),
                            description));
        }

        public static byte[] Encrypt(KeyType keyType,
                                     byte[] plainTextBytes,
                                     byte[] entropyBytes,
                                     string description)
        {
            if (plainTextBytes == null) plainTextBytes = new byte[0];
            if (entropyBytes == null) entropyBytes = new byte[0];
            if (description == null) description = String.Empty;

            DATA_BLOB plainTextBlob = new DATA_BLOB();
            DATA_BLOB cipherTextBlob = new DATA_BLOB();
            DATA_BLOB entropyBlob = new DATA_BLOB();

            CRYPTPROTECT_PROMPTSTRUCT prompt =
                                      new CRYPTPROTECT_PROMPTSTRUCT();
            InitPrompt(ref prompt);

            try
            {
                try
                {
                    InitBLOB(plainTextBytes, ref plainTextBlob);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Cannot initialize plaintext BLOB.", ex);
                }

                try
                {
                    InitBLOB(entropyBytes, ref entropyBlob);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Cannot initialize entropy BLOB.", ex);
                }

                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                if (keyType == KeyType.MachineKey)
                    flags |= CRYPTPROTECT_LOCAL_MACHINE;

                bool success = CryptProtectData(ref plainTextBlob,
                                                    description,
                                                ref entropyBlob,
                                                    IntPtr.Zero,
                                                ref prompt,
                                                    flags,
                                                ref cipherTextBlob);
                if (!success)
                {
                    int errCode = Marshal.GetLastWin32Error();

                    throw new Exception(
                        "CryptProtectData failed.", new Win32Exception(errCode));
                }

                byte[] cipherTextBytes = new byte[cipherTextBlob.cbData];

                Marshal.Copy(cipherTextBlob.pbData,
                                cipherTextBytes,
                                0,
                                cipherTextBlob.cbData);

                return cipherTextBytes;
            }
            catch (Exception ex)
            {
                throw new Exception("DPAPI was unable to encrypt data.", ex);
            }
            finally
            {
                if (plainTextBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(plainTextBlob.pbData);

                if (cipherTextBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(cipherTextBlob.pbData);

                if (entropyBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(entropyBlob.pbData);
            }
        }

        public static string Decrypt(string cipherText)
        {
            string description;

            return Decrypt(cipherText, String.Empty, out description);
        }

        public static string Decrypt(string cipherText,
                                     out string description)
        {
            return Decrypt(cipherText, String.Empty, out description);
        }

        public static string Decrypt(string cipherText,
                                         string entropy,
                                     out string description)
        {
            if (entropy == null) entropy = String.Empty;

            return Encoding.UTF8.GetString(
                        Decrypt(Convert.FromBase64String(cipherText),
                                    Encoding.UTF8.GetBytes(entropy),
                                out description));
        }

        public static byte[] Decrypt(byte[] cipherTextBytes,
                                         byte[] entropyBytes,
                                     out string description)
        {
            DATA_BLOB plainTextBlob = new DATA_BLOB();
            DATA_BLOB cipherTextBlob = new DATA_BLOB();
            DATA_BLOB entropyBlob = new DATA_BLOB();

            CRYPTPROTECT_PROMPTSTRUCT prompt =
                                      new CRYPTPROTECT_PROMPTSTRUCT();
            InitPrompt(ref prompt);

            description = String.Empty;

            try
            {
                try
                {
                    InitBLOB(cipherTextBytes, ref cipherTextBlob);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Cannot initialize ciphertext BLOB.", ex);
                }

                try
                {
                    InitBLOB(entropyBytes, ref entropyBlob);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Cannot initialize entropy BLOB.", ex);
                }

                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                bool success = CryptUnprotectData(ref cipherTextBlob,
                                                  ref description,
                                                  ref entropyBlob,
                                                      IntPtr.Zero,
                                                  ref prompt,
                                                      flags,
                                                  ref plainTextBlob);

                if (!success)
                {
                    int errCode = Marshal.GetLastWin32Error();
                    throw new Exception(
                        "CryptUnprotectData failed.", new Win32Exception(errCode));
                }

                byte[] plainTextBytes = new byte[plainTextBlob.cbData];

                Marshal.Copy(plainTextBlob.pbData,
                             plainTextBytes,
                             0,
                             plainTextBlob.cbData);

                return plainTextBytes;
            }
            catch (Exception ex)
            {
                throw new Exception("DPAPI was unable to decrypt data.", ex);
            }
            finally
            {
                if (plainTextBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(plainTextBlob.pbData);

                if (cipherTextBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(cipherTextBlob.pbData);

                if (entropyBlob.pbData != IntPtr.Zero)
                    Marshal.FreeHGlobal(entropyBlob.pbData);
            }
        }
    }
}
