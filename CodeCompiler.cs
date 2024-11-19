using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coders_Space
{
    public partial class CodeCompiler : Form
    {
        private Guna2CircleButton selectedButton;
        public CodeCompiler()
        {
            InitializeComponent();
            InitWebView();
            selectedButton = buttonCPP;
            //UpdateButtonColors();
        }
        async void InitWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate("https://www.tutorialspoint.com/compile_csharp_online.php");

        }

        /*private void UpdateButtonColors()
        {
            // Set the background color of all buttons to their default color

            foreach (Guna2Button button in webView21.Controls.OfType<Guna2Button>())
            {
                if (button != selectedButton)
                {
                    button.BackColor = Color.Transparent;
                    button.FillColor = Color.Transparent;
                }
                else
                {
                    button.BorderRadius = 15;
                    button.FillColor = Color.Violet;
                    button.BackColor = Color.Transparent;
                }
            }


        }*/

        private void buttonCPP_Click(object sender, EventArgs e)
        {
            selectedButton = (Guna2CircleButton)sender;
            //UpdateButtonColors();
            webView21.CoreWebView2.Navigate("https://www.tutorialspoint.com/compile_csharp_online.php");
        }

        private void buttonCSharp_Click(object sender, EventArgs e)
        {
            selectedButton = (Guna2CircleButton)sender;
            //UpdateButtonColors();
            webView21.CoreWebView2.Navigate("https://www.tutorialspoint.com/compile_csharp_online.php");
        }
    }
}
