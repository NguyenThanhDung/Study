using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC4Demo
{
    class RC4Engine
    {
        private string sPlainText = "";
        private string sCypherText = "";
        private string sKey = "";
        
        public RC4Engine()
        {
        }

        public string PlainText
        {
            get
            {
                return sPlainText;
            }
            set
            {
                this.sPlainText = value;
            }
        }

        public string CypherText
        {
            get
            {
                return sCypherText;
            }
            set
            {
                this.sCypherText = value;
            }
        }

        public string Key
        {
            get
            {
                return sKey;
            }
            set
            {
                this.sKey = value;
            }
        }

        static public string HexaStrToPlainStr(string str)
        {
            str = str.ToUpper();
            Encoding enc_default = Encoding.Default;
            byte[] b1 = enc_default.GetBytes(str);
            if (b1.Length % 2 != 0)
                return null;   //Error: Number of characters is not even
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] >= 48 && b1[i] <= 57)   //0..9
                    b1[i] -= 48;
                else if (b1[i] >= 65 && b1[i] <= 70)  //A..F
                    b1[i] -= 55;
                else
                    return null;   //Error: Not a hexa character
            }
            byte[] b2 = new byte[b1.Length / 2];
            for (int i = 0, j = 0; i < b2.Length; i++, j++)
            {
                b2[i] = (byte)(b1[j] << 4);
                j++;
                b2[i] ^= b1[j];
            }
            char[] arrchar = new char[enc_default.GetCharCount(b2, 0, b2.Length)];
            enc_default.GetChars(b2, 0, b2.Length, arrchar, 0);
            return new string(arrchar); //Successful
        }

        static public string PlainStrToHexaStr(string str)
        {
            Encoding enc_default = Encoding.Default;
            byte[] b = enc_default.GetBytes(str);

            string outstr = "";
            for (int i = 0; i < b.Length; i++)
            {
                string c = string.Format("{0:x2}", b[i]);
                outstr += c;
            }
            return outstr.ToUpper();
        }

        private byte[] PlainStrToBytes(string str)
        {
            Encoding enc_default = Encoding.Default;
            return enc_default.GetBytes(str);
        }

        private string BytesToPlainStr(byte[] b)
        {
            Encoding enc_default = Encoding.Default;
            char[] arrchar = new char[enc_default.GetCharCount(b, 0, b.Length)];
            enc_default.GetChars(b, 0, b.Length, arrchar, 0);
            return new string(arrchar);                
        }

        public bool Encrypt()
        {
            bool isSuccess = true;
            try
            {
                int i,j;
                
                byte[] input = PlainStrToBytes(sPlainText);
                byte[] key = PlainStrToBytes(sKey);
                byte[] output = new byte[input.Length];

                byte[] S = new byte[256];

                //Key-Scheduling Algorithm (KSA)
                for (i = 0; i <= 255; i++)
                    S[i] = (byte)i;
                for (i = 0, j = 0; i < 256; i++)
                {
                    j = (j + S[i] + key[i % key.Length]) % 256;
                    byte t = S[i];
                    S[i] = S[j];
                    S[j] = t;
                }

                //Pseudo-Random Generation Algorithm (PRGA)
                i = 0;
                j = 0;
                for (int n = 0; n < input.Length; n++)
                {
                    i = (i + 1) % 256;
                    j = (j + S[i]) % 256;
                    
                    byte t = S[i];
                    S[i] = S[j];
                    S[j] = t;

                    output[n] = (byte)(input[n] ^ S[(S[i] + S[j]) % 256]);
                }

                this.sCypherText = BytesToPlainStr(output);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool Decrypt()
        {
            bool isSuccess = true;
            try
            {
                sPlainText = sCypherText;
                if (isSuccess == Encrypt())
                    sPlainText = sCypherText;
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
