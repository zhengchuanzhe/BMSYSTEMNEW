using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.IO;
using System.Windows.Media.Imaging;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows;
using Size = System.Drawing.Size;

namespace BMSYSTEM
{
    public partial class Camera : Form
    {
        private FilterInfoCollection videoDevices;
        //拍摄照片的二进制流
        public byte[] CaptureData { get; set; }

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    combCamera.Items.Add(device.Name);
                }

                combCamera.SelectedIndex = 0;
                Connent();
            }
            catch (ApplicationException)
            {
                combCamera.Items.Add("没有检测到本地摄像头");
                videoSourcePlayer = null;
                this.Close();
            }

        }

        //连接摄像头
        private void Connent()
        {
            try
            {

                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[combCamera.SelectedIndex].MonikerString);
                //videoSource.DesiredFrameSize = new System.Drawing.Size(320, 240);   
                //videoSource.DesiredFrameRate = 1;

                videoSourcePlayer.VideoSource = videoSource;
                videoSourcePlayer.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("连接摄像头失败");
            }
        }

        //拍照按钮事件
        private void Buttonphotograpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSourcePlayer.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());




                    BitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        CaptureData = ms.ToArray();
                    }

                    clossing();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }


        //关闭摄像头
        private void clossing()
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            clossing();
        }

        private void combCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[combCamera.SelectedIndex].MonikerString);
        }



    }
}
