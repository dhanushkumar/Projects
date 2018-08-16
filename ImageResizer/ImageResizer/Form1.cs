using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        private void ResizeAndCreateImage(string file)
        {
            var canvasWidth = 600;
            var canvasHeight = 300;
            try
            {
                using (var destinationImage = new Bitmap(canvasWidth, canvasHeight))
                {
                    //using (var graphics = Graphics.FromImage(destinationImage))
                    using (var graphics = System.Drawing.Graphics.FromImage(destinationImage))
                    {
                        graphics.Clear(Color.Black);
                        using (var sourceImage =  Image.FromFile(file))
                        {
                            // Use alpha blending in case the source image has transparencies.
                            graphics.CompositingMode = CompositingMode.SourceOver;
                            // Use high quality compositing and interpolation.
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            /* ------------------ new code --------------- */

                            // Figure out the ratio
                            double ratioX = (double)canvasWidth / (double)sourceImage.Width;
                            double ratioY = (double)canvasHeight / (double)sourceImage.Height;
                            // use whichever multiplier is smaller
                           // double ratio = ratioX < ratioY ? ratioX : ratioY;
                            double ratio = Math.Min(ratioX, ratioY);

                            // now we can get the new height and width
                            int newHeight = Convert.ToInt32(sourceImage.Height * ratio);
                            int newWidth = Convert.ToInt32(sourceImage.Width * ratio);

                            // Now calculate the X,Y position of the upper-left corner 
                            // (one of these will always be zero)
                            int posX = Convert.ToInt32((canvasWidth - (sourceImage.Width * ratio)) / 2);
                            int posY = Convert.ToInt32((canvasHeight - (sourceImage.Height * ratio)) / 2);
                            graphics.DrawImage(sourceImage, posX, posY, newWidth, newHeight);
                        }
                    }
                    /* ------------- end new code ---------------- */

                    var info = ImageCodecInfo.GetImageEncoders();
                    var encoder = GetEncoderInfo(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L);
                    //destinationImage.Save(string.Format("{0}\\{1}", lblDestinationFolder.Text, file.Split('\\').Last()), info[1], encoderParameters);
                    destinationImage.Save(string.Format("{0}\\{1}.{2}", lblDestinationFolder.Text, file.Split('\\').Last().Split('.').First(),"png"), encoder, encoderParameters);

                }
            }
             catch (Exception exception)
            {
                SetText(file, exception.Message, exception.StackTrace);
            }
}

        private void ProcessImages()
        {
           // var imageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".bmp" };
            var files = Directory.GetFiles(lblSourceFolder.Text, "*.*", SearchOption.AllDirectories)
                .Where(e => e.EndsWith("jpg") || e.EndsWith("jpeg") || e.EndsWith("png") || e.EndsWith("bmp"));
            //var files = Directory.GetFiles(lblSourceFolder.Text).Where(x => imageExtensions.Contains(Path.GetExtension(x).ToLowerInvariant())).Select(x => x);
            var fileCount = files.Count();
            if (fileCount == 0)
            {
                System.Windows.Forms.MessageBox.Show("No images found in the selected directory! ", "Message");
            }
            else
            {
                int i = 0;
                foreach (var file in files)
                {
                    i++;
                    ResizeAndCreateImage(file);
                    int percentComplete = (int)Math.Round((double)(100 * i) / fileCount);
                    backgroundWorker1.ReportProgress(percentComplete);
                }
            }
            
        }

        private void openSourceFolder_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (!string.IsNullOrEmpty(lblSourceFolder.Text))
                {
                    //var folder = System.Environment.SpecialFolder.
                    fbd.SelectedPath = lblSourceFolder.Text;
                }
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lblSourceFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblSourceFolder.Text) && !string.IsNullOrEmpty(lblDestinationFolder.Text))
            {
                if (lblSourceFolder.Text == lblDestinationFolder.Text)
                {
                    System.Windows.Forms.MessageBox.Show("Source and destination cannot be the same! ", "Warning!");
                }
                else
                {
                    btnResize.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Source and destination are required! ", "Message");
            }
        }

        private void btnDestinationFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(lblDestinationFolder.Text))
                {
                    folderDialog.SelectedPath = lblDestinationFolder.Text;
                }
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    lblDestinationFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           ProcessImages();
        }
        delegate void SetTextCallback(string fileName,string message, string exception);

        private void SetText(string fileName, string message, string exception)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dataGridLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { fileName,message, exception });
            }
            else
            {
                //var form = new Form();
                //form.Show(this);
                dataGridLog.Visible = true;
                dataGridLog.ColumnCount = 3;
                dataGridLog.Columns[0].Name = "File Name";
                dataGridLog.Columns[1].Name = "Message";
                dataGridLog.Columns[2].Name = "InnerException";
                

                //string[] row = new string[] { fileName, name, exception };
                var r = new DataGridViewRow();
                r.CreateCells(dataGridLog);
                r.Cells[0].Value = fileName;
                r.Cells[1].Value = message;
                r.Cells[2].Value = exception;
                
                r.DefaultCellStyle.BackColor = Color.Red;
                dataGridLog.Rows.Add(r);
               
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPercentage.Text = e.ProgressPercentage.ToString() + "%" ;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnResize.Enabled = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
