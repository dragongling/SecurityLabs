using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace DigitalSignature
{
    public partial class DigitalSignForm : Form
    {
        static readonly string hashAlgorithm = CryptoConfig.MapNameToOID("SHA512");
        static XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
        const int keySizeInBytes = 2048;
        const string signatureFileFilter = "Signature files (*.sign)|*.sign";
        const string keyFileFilter = "XML files (*.xml)|*.xml";

        public DigitalSignForm()
        {
            InitializeComponent();
            #if DEBUG
                dataFilePathTextBox.Text = @"F:\Projects\apps\OSU\SecurityLabs\DSA2\bin\TestFiles\presentation.ppt";
            #endif
        }

        private void GenerateKeys(object sender, EventArgs e)
        {
            var csp = new RSACryptoServiceProvider(keySizeInBytes);
            string[] keyNames = new string[] { "public", "private" };
            for(byte i = 0; i < keyNames.Length; ++i)
            {
                var key = csp.ExportParameters(Convert.ToBoolean(i));
                keyPathTextBox.Text = SaveFile(keyNames[i] + "Key", keyFileFilter, KeyToString(key));
            }
            CheckButtons();
        }

        private void Sign(object sender, EventArgs e)
        {
            try
            {
                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(StringToKey(File.ReadAllText(keyPathTextBox.Text)));
                if (csp.PublicOnly)
                    throw new Exception("Key is not private");
                var dataBytes = File.ReadAllBytes(dataFilePathTextBox.Text);
                var signature = csp.SignData(dataBytes, hashAlgorithm);
                signPathTextBox.Text = SaveFile("signature", signatureFileFilter, signature);
                CheckButtons();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }        

        private void Verify(object sender, EventArgs e)
        {
            try {
                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(StringToKey(File.ReadAllText(keyPathTextBox.Text)));
                var dataBytes = File.ReadAllBytes(dataFilePathTextBox.Text);
                var signature = File.ReadAllBytes(signPathTextBox.Text);            
                var valid = csp.VerifyData(dataBytes, hashAlgorithm, signature);
                MessageBox.Show("Verification " + (valid ? "succeded" : "failed") + "!", "Verification");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void OpenDataFile(object sender, EventArgs e)
        {
            OpenFileTo(dataFilePathTextBox);
        }

        private void OpenKeyFile(object sender, EventArgs e)
        {
            OpenFileTo(keyPathTextBox, keyFileFilter);
        }

        private void OpenSignatureFile(object sender, EventArgs e)
        {
            OpenFileTo(signPathTextBox, signatureFileFilter);
        }

        string SaveFile(string defaultFilename, string filter, object data)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = defaultFilename,
                Filter = filter
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (data.GetType() == typeof(string))
                    File.WriteAllText(sfd.FileName, (string)data);
                else if (data.GetType() == typeof(byte[]))
                    File.WriteAllBytes(sfd.FileName, (byte[])data);
                else
                    throw new ArgumentException("type of data should be either string or byte[]");
                return sfd.FileName;
            }
            return string.Empty;
        }

        private void OpenFileTo(TextBox textBox, string filter = "All files (*.*)|*.*")
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = filter };
            if (ofd.ShowDialog() == DialogResult.OK)
                textBox.Text = ofd.FileName;
            CheckButtons();
        }

        private void CheckButtons() { CheckButtons(null, null); }

        private void CheckButtons(object sender, EventArgs e)
        {
            signButton.Enabled = !(
                string.IsNullOrEmpty(dataFilePathTextBox.Text) ||
                string.IsNullOrEmpty(keyPathTextBox.Text));
            verifyButton.Enabled = signButton.Enabled &&
                !string.IsNullOrEmpty(signPathTextBox.Text);
        }

        string KeyToString(RSAParameters key)
        {
            var sw = new StringWriter();
            xs.Serialize(sw, key);
            return sw.ToString();
        }

        RSAParameters StringToKey(string str)
        {
            return (RSAParameters)xs.Deserialize(new StringReader(str));
        }
    }
}
