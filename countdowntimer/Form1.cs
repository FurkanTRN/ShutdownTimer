using System;
using System.Windows.Forms;



namespace countdowntimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int counter;
        private int choose;

        private void Form1_Load(object sender, EventArgs e)
        {


            for (int i = 0; i <= 59; i++)
            {
                if (i <= 24)
                {
                    hours.Items.Add(i);

                }

                seconds.Items.Add(i);
                minutes.Items.Add(i);
            }

            TimeSpan time = TimeSpan.FromSeconds(0);
            label1.Text = time.ToString(@"hh\:mm\:ss");
            hours.SelectedItem = 0;
            minutes.SelectedItem = 0;
            seconds.SelectedItem = 0;
            //    textBox1.BackColor = this.BackColor;
            //    textBox2.BackColor = this.BackColor;
            //    textBox3.BackColor = this.BackColor;
            //
        }



        private void timer1_Tick(object sender, EventArgs e)
        {


            TimeSpan time = TimeSpan.FromSeconds(counter);
            label1.Text = time.ToString(@"hh\:mm\:ss");
            counter--;
            if (counter == -1)
            {
                timer1.Stop();
                timer1.Enabled = false;
                switch (this.choose)
                {
                    case 1:
                        System.Diagnostics.Process.Start(@"C:\Windows\system32\shutdown.exe", "-s -t 0");


                        //shutdown method
                        break;
                    case 2:
                        System.Diagnostics.Process.Start(@"C:\Windows\system32\shutdown.exe", "-r -t 0");
                        //reset method
                        break;
                    case 3:
                        //lock out method
                        System.Diagnostics.Process.Start(@"C:\Windows\system32\shutdown.exe", "-l -t 0");
                        break;

                }

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            int saat = int.Parse(hours.SelectedItem.ToString());
            int dakika = int.Parse(minutes.SelectedItem.ToString());
            int saniye = int.Parse(seconds.SelectedItem.ToString());
            counter = (saat * 3600) + (dakika * 60) + saniye;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            counter = 0;
            TimeSpan time = TimeSpan.FromSeconds(counter);
            label1.Text = time.ToString(@"hh\:mm\:ss");
        }

        // pc shutdown
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.choose = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Yeniden başlatma
            this.choose = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //lock out
            this.choose = 3;


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

