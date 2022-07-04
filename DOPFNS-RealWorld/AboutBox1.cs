using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System;
using System.IO;

namespace DOPFNS_RealWorld
{
    partial class AboutBox1 : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        public AboutBox1()
        {
            InitializeComponent();

        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(DOPFNS_RealWorld.Properties.Resources.SURVIVE); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Load();
            audio.Stop();
            AboutBox1 abou = new AboutBox1();
            this.Close();
        }

        private void AboutBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= x;
                newpoint.Y -= y;
                base.Location = newpoint;
            }
        }

        private void AboutBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - base.Location.X;
            y = Control.MousePosition.Y - base.Location.Y;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {         
            DialogResult Launchit = MessageBox.Show("Do You Want To Download Patch Multiplayer 2.35 For PS4?\n\nWe Will Redirect You To Page!", "MCHAX4U", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(Launchit == DialogResult.Yes)
            {
              System.Diagnostics.Process.Start("https://www.psxhax.com/threads/minecraft-v1-18-1-ps4-pkg-to-bypass-psn-play-on-minecraft-servers.12849/");
            }
            else if(Launchit == DialogResult.No)
            {
              MessageBox.Show("OK! Thats Fine You Dont Want To Play ONLINE!", "MCHAX4U", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
