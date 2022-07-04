using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libdebug;
using System.Media;
using System;
using System.IO;


namespace DOPFNS_RealWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PS4DBG PS4;
        private int pid;
        ProcessList processList;
        private int Gpid = 0;
        private int KernBase = 0x400000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.125;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AttachBtn.Enabled = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - MoveForm.X;
                this.Top += e.Y - MoveForm.Y;
            }
        }
        Point MoveForm;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm = new Point(e.X, e.Y);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PS4 = new PS4DBG(textBoxPS44IP.Text);
                PS4.Connect();
                PS4.Notify(222, "Connection Established With MCHAX4U");
                MessageBox.Show("Successfully Connected to Your PS4", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AttachBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                AttachBtn.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AttachBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TheProcName = "eboot.bin";
                processList = PS4.GetProcessList();
                Gpid = processList.FindProcess(TheProcName, false).pid;
                PS4.Notify(222, "Attachment successful");
                MessageBox.Show("Successfully Attached to Game", "Attachment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer2.Start();
            }
            catch (Exception esax)
            {
                MessageBox.Show(esax.Message, "Didnt attach", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void checkBoxUnfairAttack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (PS4 == null)
                {
                    MessageBox.Show("You are not connected", "MCHAX4U", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (checkBoxRapidhit.Checked)
                    {
                        PS4.Notify(222, " Unfiar Attack On");
                        PS4.WriteMemory(Gpid + KernBase, 0x6c1957c, new byte[] { 0x00, 0x00, 0xE0, 0x40 });

                    }
                    else
                    {
                        PS4.Notify(222, " Unfiar Attack Off");
                        PS4.WriteMemory(Gpid + KernBase, 0x6c1957c, new byte[] { 0xCD, 0xCC, 0xCC, 0x3D });
                    }
                }

            } catch (Exception sx)
            {
                MessageBox.Show(sx.Message, "MCHAX4U", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void checkBoxRapidhit_CheckedChanged(object sender, EventArgs e)
        { 
            try
            {
                if (PS4 == null)
                {
                    MessageBox.Show("You are not connected", "MCHAX4U", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (checkBoxRapidhit.Checked)
                    {
                        PS4.Notify(222, " Rapid Hit On");
                        PS4.WriteMemory(Gpid + KernBase, 0x6a19fb2, new byte[] { 0x88, 0x50, 0x28 });/// do u know how to do it right? bro ur confusing me i need to learn ps4 way its ddiffent to ps3

                    }
                    else
                    {
                        PS4.Notify(222, " Rapid Hit Off");
                        PS4.WriteMemory(Gpid + KernBase, 0x6a19fb2, new byte[] { 0x88, 0x50, 0x18 });//did it forgot about new   
                    }
                }

            }
            catch (Exception sx)
            {
                MessageBox.Show(sx.Message, "MCHAX4U", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This tool is for PS4 Minecraft Coded By ⓘNELUx0799#1656");
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.textBoxnamechanger.Text);
            Array.Resize<byte>(ref bytes, bytes.Length + 1);
            PS4.WriteMemory(Gpid, 0x2002F0568, bytes);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(DOPFNS_RealWorld.Properties.Resources.SURVIVE); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Load();
            audio.Play();
            AboutBox1 abou = new AboutBox1();
            abou.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/TVw3BTB");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255); label7.ForeColor = Color.FromArgb(A, R, G, B);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCKSK6H4zpg2Yh1PEhK0sIZw");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

  
