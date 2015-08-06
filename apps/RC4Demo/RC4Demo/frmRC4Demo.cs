using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RC4Demo
{
    public partial class frmRC4Demo : Form
    {
        private RC4Engine myRC4Engine = new RC4Engine();

        public frmRC4Demo()
        {
            InitializeComponent();
        }

        private void frmRC4Demo_Load(object sender, EventArgs e)
        {
            rdbKeyText.Checked = true;
            rdbPlainText.Checked = true;
            rdbCypherHexa.Checked = true;
            btnEncrypt.Enabled = false;
            btnDecrypt.Enabled = false;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (rdbPlainText.Checked == true) myRC4Engine.PlainText = txtPlainText.Text;
            else myRC4Engine.PlainText = RC4Engine.HexaStrToPlainStr(txtPlainText.Text);
            
            if (rdbKeyText.Checked == true) myRC4Engine.Key = txtKey.Text;
            else myRC4Engine.Key = RC4Engine.HexaStrToPlainStr(txtKey.Text);
            
            myRC4Engine.Encrypt();
            
            if (rdbCypherText.Checked == true) txtCypherText.Text = myRC4Engine.CypherText;
            else txtCypherText.Text = RC4Engine.PlainStrToHexaStr(myRC4Engine.CypherText);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (rdbCypherText.Checked == true) myRC4Engine.CypherText = txtCypherText.Text;
            else myRC4Engine.CypherText = RC4Engine.HexaStrToPlainStr(txtCypherText.Text);

            if (rdbKeyText.Checked == true) myRC4Engine.Key = txtKey.Text;
            else myRC4Engine.Key = RC4Engine.HexaStrToPlainStr(txtKey.Text);

            myRC4Engine.Decrypt();

            if (rdbPlainText.Checked == true) txtPlainText.Text = myRC4Engine.PlainText;
            else txtPlainText.Text = RC4Engine.PlainStrToHexaStr(myRC4Engine.PlainText);
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text.Length > 0 && txtPlainText.Text.Length > 0)
                btnEncrypt.Enabled = true;
            else
                btnEncrypt.Enabled = false;

            if (txtKey.Text.Length > 0 && txtCypherText.Text.Length > 0)
                btnDecrypt.Enabled = true;
            else
                btnDecrypt.Enabled = false;
        }

        private void txtPlainText_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text.Length > 0 && txtPlainText.Text.Length > 0)
                btnEncrypt.Enabled = true;
            else
                btnEncrypt.Enabled = false;
        }

        private void txtCypherText_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text.Length > 0 && txtCypherText.Text.Length > 0)
                btnDecrypt.Enabled = true;
            else
                btnDecrypt.Enabled = false;
        }

        private void rdbKeyText_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKeyText.Checked == true)
            {
                string str = RC4Engine.HexaStrToPlainStr(txtKey.Text);
                if (str != null)
                    txtKey.Text = str;
                else
                {
                    //rdbKeyHexa.Checked = true;
                    //rdbKeyText.Checked = false;
                    MessageBox.Show("Error: Hexa string is invalid", "RC4 Demo");
                }
            }
            else
            {
                txtKey.Text = RC4Engine.PlainStrToHexaStr(txtKey.Text);
            }
        }

        private void rdbPlainText_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPlainText.Checked == true)
            {
                string str = RC4Engine.HexaStrToPlainStr(txtPlainText.Text);
                if (str != null)
                    txtPlainText.Text = str;
                else
                {
                    //rdbPlainText.Checked = false;
                    //rdbPlainHexa.Checked = true;
                    MessageBox.Show("Error: Hexa string is invalid", "RC4 Demo");
                }
            }
            else
            {
                txtPlainText.Text = RC4Engine.PlainStrToHexaStr(txtPlainText.Text);
            }
        }

        private void rdbCypherText_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCypherText.Checked == true)
            {
                string str = RC4Engine.HexaStrToPlainStr(txtCypherText.Text);
                if (str != null)
                    txtCypherText.Text = str;
                else
                {
                    //rdbCypherText.Checked = false;
                    //rdbCypherHexa.Checked = true;
                    MessageBox.Show("Error: Hexa string is invalid", "RC4 Demo");
                }
            }
            else
            {
                txtCypherText.Text = RC4Engine.PlainStrToHexaStr(txtCypherText.Text);
            }
        }

        private void txtPlainText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                txtPlainText.SelectAll();
            }
        }

        private void txtCypherText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                txtCypherText.SelectAll();
            }
        }
    }
}
