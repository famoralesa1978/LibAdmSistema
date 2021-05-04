using System;
using System.Security.Cryptography;
using System.IO;


namespace LibAdmSistema
{
	class ClsUtilidades
	{

    private SymmetricAlgorithm alg;
    const string sKey = "compass";

    #region "Contraseñas"

    public string GenerateHashMD5(string input)
    {
      TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
      //  Compute the MD5 hash.
      DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
      //  Set the cipher mode.
      DES.Mode = CipherMode.ECB;
      //  Create the encryptor.
      ICryptoTransform DESEncrypt = DES.CreateEncryptor();
      //  Get a byte array of the string.
      byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
      //  Transform and return the string.
      return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
    }

    public string DecryptTripleDES(string sOut)
    {
      TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
      //  Compute the MD5 hash.
      DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
      //  Set the cipher mode.
      DES.Mode = CipherMode.ECB;
      //  Create the decryptor.
      ICryptoTransform DESDecrypt = DES.CreateDecryptor();
      byte[] Buffer = Convert.FromBase64String(sOut);
      //  Transform and return the string.
      return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
    }

    public Byte[] insertarPDF(string pdfnombre)
    {
      FileStream fs = new FileStream(pdfnombre, FileMode.Open, FileAccess.Read);
      BinaryReader br = new BinaryReader(fs);
      Byte[] bytes = br.ReadBytes((Int32)fs.Length);
      br.Close();
      fs.Close();
      return bytes;
    }

    #endregion

  }
}
