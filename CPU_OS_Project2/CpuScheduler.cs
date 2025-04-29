using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
using System.Drawing.Imaging;
using System.IO;

namespace CpuSchedulingWinForms
{
    public partial class CpuScheduler : Form
    {
        public CpuScheduler()
        {
            InitializeComponent();
            this.Size = new Size(670, 450); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dashBoardTab.Show();
            this.tabSelection.SelectTab(0);
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;

            //this.btnProductCode.BackColor = Color.Transparent;
            //this.btnCpuScheduler.BackColor = Color.Transparent;
            //this.btnDashBoard.BackColor = Color.DimGray;
        }

        private void btnCpuScheduler_Click(object sender, EventArgs e)
        {
            //this.dashBoardTab.Show();
            this.tabSelection.SelectTab(1);
            this.sidePanel.Height = btnCpuScheduler.Height;
            this.sidePanel.Top = btnCpuScheduler.Top;

            //this.btnProductCode.BackColor = Color.Transparent;         
            //this.btnDashBoard.BackColor = Color.Transparent;
            //this.btnCpuScheduler.BackColor = Color.DimGray;
        }


        private void btnFCFS_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.fcfsAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;
                
                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    //listBoxProcess.Items.Add(" Process " + (i + 1));
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                //listBoxProcess.Items.Add("\n");
                //listBoxProcess.Items.Add(" Total number of processes executed: " + numberOfProcess);
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnSJF_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.sjfAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;
               
                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }



        private void btnPriority_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.priorityAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles : " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnSRTF_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.SRTFfAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);

                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); // CPU progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38);
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        // The new button handler for HRRN
        private void btnHRRN_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.HRRNAlgorithm(txtProcess.Text); // Implement the HRRN algorithm
                int numberOfProcess = Int16.Parse(txtProcess.Text);

                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(5); // CPU progress bar for HRRN
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(15);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(17);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(42);
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Response Ratio", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-"); // To show response ratio or other info later
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void txtProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void restartApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            CpuScheduler cpuScheduler = new CpuScheduler();
            cpuScheduler.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxCodeOutput.Image == null)
            {
                return;
            }
            else if (pictureBoxCodeOutput.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png|JPEG|*.jpeg|ICON|*.ico"})
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBoxCodeOutput.Image.Save(saveFileDialog.FileName);
                    }
                }
            }           
        }

        private void CpuScheduler_Load(object sender, EventArgs e)
        {
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;
            this.progressBar1.Increment(5);
            this.progressBar2.Increment(17);
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            timer1.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnRoundRobin_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.roundRobinAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                string quantumTime = Helper.QuantumTime;
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add(quantumTime);
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0.0)
            {
                this.Opacity -= 0.021;
            } else
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void cpuSchedulerTab_Click(object sender, EventArgs e)
        {

        }
    }
}