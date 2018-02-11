using System;
using System.Text;
using System.Windows.Forms;


namespace DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DES desCryptor = new DES();

        private void encrypt(object sender, EventArgs e)
        {
            try
            {
                ciphertextTextBox.Text = HexadecimalEncoding.ToHexString(
                        DES.feistel_crypt(openTextTextBox.Text, keyTextBox.Text)
                        );
                openTextTextBox.Text = String.Empty;
            } catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message, "Error");
            }
        }

        private void decrypt(object sender, EventArgs e)
        {
            try
            {
                openTextTextBox.Text = DES.feistel_decrypt(
                    HexadecimalEncoding.FromHexString(ciphertextTextBox.Text), 
                    keyTextBox.Text);
                ciphertextTextBox.Text = String.Empty;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message, "Error");
            }
            
        }
    }

    public class HexadecimalEncoding
    {
        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
    }
}
