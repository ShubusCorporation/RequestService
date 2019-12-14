using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5Hasher
{
    public class Md5HashProvider
    {
        private System.Security.Cryptography.SHA256 _Sha256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
        StringBuilder _Sb = new StringBuilder();
        private string _Sol = "";


        public Md5HashProvider()
        {
            byte[] data = Convert.FromBase64String("VW1WeGRXVnpkRk5sY25acFkyVT0=");
            _Sol = Encoding.UTF8.GetString(data);
        }


        private Int64 CalculateMD5Hash(string input)
        {
            byte[] inputBytes = Encoding.Unicode.GetBytes(input);          
            byte[] bytes = _Sha256.ComputeHash(inputBytes);

            Int64 ret = BitConverter.ToInt64(bytes, 0) ^ BitConverter.ToInt64(bytes, 8) ^ BitConverter.ToInt64(bytes, 16);
            return ret;
        }


        public Int64 GetHash(string Login, string Password)
        {
            Int64 ret = -1;

            try
            {
                _Sb.Clear();
                _Sb.Append(Login);
                _Sb.Append(Password);
                _Sb.Append(_Sol);
                ret = CalculateMD5Hash(_Sb.ToString());
            }
            catch
            {
                throw;
            }
            return ret;
        }
    }
}
