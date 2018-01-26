using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using MetalWorker.Cryptography;

namespace RSA_code
{
    public partial class MainForm : Form
    {
        bool passwordHidden = true;
        private char delimiter = ':';

        public MainForm()
        {
            InitializeComponent();
            GenerateKeySizeCombobox(10);
        }

        void GenerateKeySizeCombobox(uint maxDegree)
        {
            if (maxDegree < 4)
                throw new ArgumentException("Key size cannot be less than 16 bits");

            for(int i = 4; i <= maxDegree; ++i)
                keyBitCountComboBox.Items.Add(1 << i);
            keyBitCountComboBox.SelectedIndex = 0;
        }

        private void Encrypt(object sender, EventArgs e)
        {
            ciphertextRichTextBox.Text = StringRSA.Encrypt(
                plaintextRichTextBox.Text, 
                ParseKey(publicKeyTextBox));            
            plaintextRichTextBox.Text = String.Empty;
        }

        private void Decrypt(object sender, EventArgs e)
        {
            plaintextRichTextBox.Text = StringRSA.Decrypt(
                ciphertextRichTextBox.Text, 
                ParseKey(privateKeyTextBox));
            ciphertextRichTextBox.Text = String.Empty;
        }

        private void ButtonCheck(object sender, EventArgs e)
        {
            bool keysNotEmpty = !privateKeyTextBox.IsEmpty()
                && !publicKeyTextBox.IsEmpty();

            encryptButton.Enabled = !plaintextRichTextBox.IsEmpty()
                && !publicKeyTextBox.IsEmpty();
            decryptButton.Enabled = !ciphertextRichTextBox.IsEmpty()
                && !privateKeyTextBox.IsEmpty();
            showButton.Enabled = !privateKeyTextBox.IsEmpty();
            copyButton.Enabled = !privateKeyTextBox.IsEmpty();
            if(privateKeyTextBox.IsEmpty())
            {
                passwordHidden = true;
                ShowHidePassword();
            }
        }

        private BlockRSA.Key<BigInteger> ParseKey(TextBox textBox)
        {
            var parts = textBox.Text.Split(delimiter);
            return new BlockRSA.Key<BigInteger>(BigInteger.Parse(parts[0]), BigInteger.Parse(parts[1]));
        }

        private void GenerateKeys(object sender, EventArgs e)
        {
            BlockRSA.KeyData<BigInteger> keys = BlockRSA.GenerateKeys((uint)(1 << keyBitCountComboBox.SelectedIndex));
            publicKeyTextBox.Text = keys.N.ToString() + 
                delimiter + keys.E.ToString();
            privateKeyTextBox.Text = keys.N.ToString() + 
                delimiter + keys.D.ToString();
            ButtonCheck(sender, e);
        }

        private void ShowButtonClick(object sender, EventArgs e)
        {
            passwordHidden = !passwordHidden;
            ShowHidePassword();
        }

        private void ShowHidePassword()
        {
            if (!passwordHidden)
            {
                privateKeyTextBox.PasswordChar = (char)0;
                showButton.Text = "Hide";
            }
            else
            {
                privateKeyTextBox.PasswordChar = '●';
                showButton.Text = "Show";
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(privateKeyTextBox.Text);
        }
    }

    static class TextBoxExtensions
    {
        public static bool IsEmpty(this TextBox textBox)
        {
            return textBox.Text.Length == 0;
        }
    }

    static class RichTextBoxExtensions
    {
        public static bool IsEmpty(this RichTextBox textBox)
        {
            return textBox.Text.Length == 0;
        }
    }
}
