using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    public partial class TakePhotoForm : Form
    {
        public TakePhotoForm(string monikerString, string pcbSerialNo)
        {
            InitializeComponent();
            this.monikerString = monikerString;
            this.pcbSerialNo = pcbSerialNo;
        }

        List<Image> imageList = new List<Image>();

        VideoCaptureDevice FinalFrame;
        Bitmap camFrameBitmap;
        private readonly string monikerString;
        private readonly string pcbSerialNo;
        bool rotate180 = false;

        private void buttonAddPic_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < 11)
            {
                Image img = pictureBox1.Image;

                imageList.Add(img);
                
                PictureBox picBx = new PictureBox();
                picBx.Name = (imageList.Count - 1).ToString();
                picBx.Margin = new Padding(2);
                picBx.Height = flowLayoutPanel1.Height - 4;
                picBx.Width = img.Width / img.Height * picBx.Height;
                picBx.Image = img;
                picBx.SizeMode = PictureBoxSizeMode.Zoom;
                picBx.MouseEnter += picBx_MouseEnter;
                picBx.MouseLeave += picBx_MouseLeave;
                picBx.MouseClick += picBx_MouseClick;
                picBx.BorderStyle = BorderStyle.FixedSingle;

                flowLayoutPanel1.Controls.Add(picBx);
            }
            else
            {
                MessageBox.Show("Max 10 zdjęć. Skasuj zdjęcia aby dodać nowe.");
            }

            if (flowLayoutPanel1.Controls.Count >= 2) 
            {
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
            }
        }

        private void picBx_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int index = -1;
            for (int i=0;i<flowLayoutPanel1.Controls.Count;i++)
            {
                if (flowLayoutPanel1.Controls[i].Name == pb.Name)
                {
                    index = i;
                    break;
                }
            }
            
            imageList.RemoveAt(index);
            flowLayoutPanel1.Controls.Remove(pb);

            if (flowLayoutPanel1.Controls.Count < 2) 
            {
                buttonSave.Enabled = false;
            }
        }

        private void picBx_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pb.Tag != null)
            {
                pb.Image = (Bitmap)pb.Tag;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
            FinalFrame.Start();
        }

        private void picBx_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Tag = pb.Image;
            pb.SizeMode = PictureBoxSizeMode.CenterImage;
            pb.Image = LED_Service.Properties.Resources.delete_1_icon;
            FinalFrame.Stop();
            pictureBox1.Image = (Image)pb.Tag;


        }

        private void TakePhotoForm_Load(object sender, EventArgs e)
        {
            string rotationSettings = AppSettings.GetSettings("camRotation180");
            rotate180 = rotationSettings == "ON" ? true : false;
            FinalFrame = new VideoCaptureDevice();
            FinalFrame = new VideoCaptureDevice(monikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.NewFrame -= Handle_New_Frame;
            FinalFrame.Start();

            if (!System.IO.Directory.Exists(@"P:\LED_Serwis"))
            {
                NetworkShareConnect.Conntect();
            }
        }

        private void Handle_New_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            if (camFrameBitmap != null)
                camFrameBitmap.Dispose();
            camFrameBitmap = new Bitmap(eventArgs.Frame);

            if (pictureBox1.Image != null)
                this.Invoke(new MethodInvoker(delegate () { pictureBox1.Image.Dispose(); }));
            pictureBox1.Image = camFrameBitmap;
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            camFrameBitmap = (Bitmap)eventArgs.Frame.Clone();
            if (rotate180)
            {
                camFrameBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            pictureBox1.Image = camFrameBitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //var imgFolderPath = ConfigurationManager.AppSettings["ImgPath"] + "\\" + FixedDate + "\\" + LotNumber+"\\";
            var imgFolderPath = @"P:\LED_Serwis\" + DateTime.Now.ToString("yyyy")+@"\"+ DateTime.Now.ToString("MMM") + @"\" + DateTime.Now.ToString("dd");//AppSettings.GetSettings("ImgPath") + "\\" + DateTime.Now.ToString("dd.MM.yyyy");
            System.IO.Directory.CreateDirectory(imgFolderPath);

            for (int i = 0; i < imageList.Count; i++)
            {
                Image img = imageList[i];
                var saveBmp = new Bitmap(img);
                saveBmp.Save(imgFolderPath + "\\" + pcbSerialNo + "_" + i + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TakePhotoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalFrame.Stop();
            
        }
    }
}
