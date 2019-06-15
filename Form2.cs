using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Termo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }



        public void CancelAsyncButton_Click_1(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {

                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();

                this.Dispose();

            }

        }

        private void BackgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;

                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(25);
                    worker.ReportProgress(i * 1);
                }
            }
        }

        private void BackgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar1.Value < 99)
            {
                progressBar1.Value = (e.ProgressPercentage);
            }
            else
            {
                this.Dispose();
            }
       
        }

        private void BackgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled == true)
            //{
            //    resultLabel.Text = "Canceled!";
            //}
            //else if (e.Error != null)
            //{
            //    resultLabel.Text = "Error: " + e.Error.Message;
            //}
            //else
            //{
            //    resultLabel.Text = "Done!";
            //}
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}