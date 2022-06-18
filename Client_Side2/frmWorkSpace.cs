using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;

namespace Client_Side2
{
    public partial class frmWorkSpace : Form
    {
        #region declare
        Graphics g;
        Bitmap bm;
        Bitmap bmCurve;
        Pen p;
        Point pt1, pt2;
        Socket client;
        Socket signal;
        List<Point> lstPoint;
        List<Image> lstImage;
        List<Point> lstPointCurve;
        List<string> lstUserOnline;
        Pen penErarse;
        SaveFileDialog SaveFile;
        ColorDialog colorDialog;
        OpenFileDialog OpenFileDialog;
        CustomPictureBox custom;
        Cursor pencil;
        Cursor eraser;
        Cursor fill;
        Cursor defaultCursor;
        IPAddress address = IPAddress.Loopback;
        int sX, sY, cX, cY;
        int index;
        int indexImage = -1;
        bool flagImage = false;
        bool paint = false;
        object obj = new object();
        object obj2 = new object();
        string nameRoom;
        string nameUser;
        string account;
        string strIP;
        #endregion
        #region construct
        public frmWorkSpace()
        {
            InitializeComponent();
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            lstPoint = new List<Point>();
            lstPointCurve = new List<Point>();
            penErarse = new Pen(Color.White, 10);
            p = new Pen(Color.Black);
            colorDialog = new ColorDialog();
            SaveFile = new SaveFileDialog();
            OpenFileDialog = new OpenFileDialog();
            bm = new Bitmap(pic.Width, pic.Height);
            bmCurve = new Bitmap(pic.Width, pic.Height);
            custom = new CustomPictureBox();
            lstImage = new List<Image>();
            lstUserOnline = new List<string>();

            Image imagePencil = Image.FromFile(Application.StartupPath + "\\pencil.png");
            Image imageEraser = Image.FromFile(Application.StartupPath + "\\eraser.png");
            Image imageFill = Image.FromFile(Application.StartupPath + "\\fill.png");
            Image imageCursor = Image.FromFile(Application.StartupPath + "\\cursor.png");

            pencil = CreateCursor((Bitmap)imagePencil);
            fill = CreateCursor((Bitmap)imageFill);
            eraser = CreateCursor((Bitmap)imageEraser);
            defaultCursor = CreateCursor((Bitmap)imageCursor);
            btnPen.Cursor = defaultCursor;
            btnErarse.Cursor = defaultCursor;
            btnFill.Cursor = defaultCursor;
            btnSave.Cursor = defaultCursor;
            btnImage.Cursor = defaultCursor;
            btnPrintImage.Cursor = defaultCursor;
            btnResize.Cursor = defaultCursor;
            btnColor.Cursor = defaultCursor;
            this.Cursor = defaultCursor;

            OpenFileDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            p.StartCap = p.EndCap = LineCap.Round;
            penErarse.StartCap = penErarse.EndCap = LineCap.Square;
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            CreateSignalConnection();
            var threadReceiveSignal = new Thread(ReceiveSignalFromServer);
            threadReceiveSignal.Start();
            var threadReceive = new Thread(ReceiveFromServer);
            threadReceive.Start();
        }
        private Cursor CreateCursor(Bitmap bm)
        {
            bm.MakeTransparent();
            return new Cursor(bm.GetHicon());
        }
        #endregion
        #region signal handle
        private void CreateSignalConnection()
        {
            signal = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            var remoteHost = new IPEndPoint(address, 9091);
            signal.Connect(remoteHost);
            SendSignalToServer(nameRoom + "|" + account);
        }

        private void SendSignalToServer(object obj)
        {
            string str = obj + "";
            using (var stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, str);
                signal.Send(stream.ToArray());
            }
        }

        private void ReceiveSignalFromServer()
        {
            byte[] bytesReceive = new byte[1024 * 5000];
            while (true)
            {
                signal.Receive(bytesReceive);
                string message = "";
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        message = bf.Deserialize(stream) + "";
                    }
                    catch (Exception)
                    {
                        
                        continue;
                    }
                }
                if(message == "undo")
                {
                    indexImage--;
                    bm = lstImage[indexImage].Clone() as Bitmap;
                    g = Graphics.FromImage(bm);
                    UpdatePic(bm);
                }
                else if(message == "redo")
                {
                    indexImage++;
                    bm = lstImage[indexImage].Clone() as Bitmap;
                    g = Graphics.FromImage(bm);
                    UpdatePic(bm);
                }
                else
                {
                    lstUserOnline.Clear();
                    string[] arrStr = message.Split('|');
                    for (int i = 1 ; i < arrStr.Length - 1; i++)
                    {
                        lstUserOnline.Add(arrStr[i]);
                    }
                }
            }
        }
        #endregion
        #region receive image
        private void ReceiveFromServer()
        {
            byte[] bytesReceive = new byte[1024 * 5000];
            while (true)
            {
                try
                {
                    int num = client.Receive(bytesReceive);
                }
                catch (Exception)
                {
                 
                    continue;
                }
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    Image image;
                    try
                    {
                        image = (Image)binary.Deserialize(stream);
                    }
                    catch (Exception)
                    {

                       
                        continue;
                    }
                    g = Graphics.FromImage(image);
                    bm = image as Bitmap;
                    lock (obj)
                    {
                        UpdatePic(bm);
                    }
                    if (lstImage.Count != indexImage + 1)
                    {
                        lstImage.RemoveRange(indexImage + 1, lstImage.Count - 1 - (indexImage));
                    }
                    lstImage.Add(image.Clone() as Image);
                    indexImage = lstImage.Count - 1;
                }
            }
        }

        private void UpdatePic(object obj)
        {
            if (pic.InvokeRequired)
            {
                pic.Invoke(new Action(() =>
                {
                    pic.Image = (Image)obj;
                    pic.Refresh();
                }));
            }
        }

        #endregion 
        #region send image
        private void SendToServer()
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter binary = new BinaryFormatter();
                Image image;
                lock (obj)
                {
                    image = (Image)bm.Clone();
                }
                binary.Serialize(stream, image);
                client.Send(stream.ToArray());
            }
        }

        #endregion
        #region Pass data
        public void PassData(Socket socket, string nameUser, string nameRoom, string strIP, string account)
        {
            client = socket;
            this.nameRoom = nameRoom;
            this.nameUser = nameUser;
            this.strIP = strIP;
            this.account = account;
            address = IPAddress.Parse(strIP);
            lbRoom.Text += nameRoom;
            lbUser.Text += nameUser;
        }
        #endregion
        #region picturebox event
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            pt1 = e.Location;
            cX = e.X;
            cY = e.Y;
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (!paint) return;
            pt2 = e.Location;
            if(index == 1)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                g.DrawLine(p, pt1, pt2);
                pt1 = pt2;
            }
            if(index == 2)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                g.DrawLine(penErarse, pt1, pt2);
                pt1 = pt2;
            }
            lock (obj)
            {
                pic.Refresh();
            }
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            paint = false;
            if(index == 3)
            {
                g.DrawLine(p, pt1, pt2);
                pic.Refresh();
            }
            if(index == 4)
            {
                sX = e.X - cX;
                sY = e.Y - cY;
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if(index == 5)
            {
                sX = e.X - cX;
                sY = e.Y - cY;
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 7)
            {
                if (lstPointCurve.Count < 2) return;
                g.DrawCurve(p, lstPointCurve.ToArray());
            }
            lstPoint.Clear();
            Thread threadSend = new Thread(SendToServer);
            threadSend.Start();
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            if (!paint) return;
            Graphics g = e.Graphics;
            if(index == 3)
            {
                g.DrawLine(p, pt1, pt2);
            }
            if(index == 4)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if(index == 5)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
        }
        private void curveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 7;
            bmCurve = bm.Clone() as Bitmap;
            lstPointCurve.Clear();
        }

        #endregion
        #region width
        private void line1_Click(object sender, EventArgs e)
        {
            p.Width = 1;
        }

        private void line3_Click(object sender, EventArgs e)
        {
            p.Width = 3;
        }
        private void line5_Click(object sender, EventArgs e)
        {
            p.Width = 5;
        }

        private void line8_Click(object sender, EventArgs e)
        {
            p.Width = 8;
        }
        #endregion
        #region button event
        private void btnElipse_Click(object sender, EventArgs e)
        {
            this.Cursor = defaultCursor;
            index = 4;
        }

        private void btnRectangular_Click(object sender, EventArgs e)
        {
            this.Cursor = defaultCursor;
            index = 5;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            index = 8;
            this.Cursor = defaultCursor;
            colorDialog.ShowDialog();
            p.Color = colorDialog.Color;
            btnShowColor.BackColor = colorDialog.Color;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            index = 9;
            this.Cursor = defaultCursor;
            SaveFile.Filter = "Image(*.png)|*.png|Image1(*.*)|*.*";
            var thread = new Thread((ThreadStart)(() =>
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    string path = SaveFile.FileName;
                    Bitmap bitmap = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat);
                    bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                }
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            this.Cursor = pencil;
            index = 1;
        }

        private void btnErarse_Click(object sender, EventArgs e)
        {
            this.Cursor = eraser;
            index = 2;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            this.Cursor = fill;
            index = 6;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.Cursor = defaultCursor;
            index = 3;
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            index = 10;
            this.Cursor = defaultCursor;
            if (flagImage)
            {
                MessageBox.Show("You have not printed the current image !");
                return;
            }
            var thread = new Thread((ThreadStart)(() =>
            {
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    flagImage = true;
                    string path = OpenFileDialog.FileName;
                    Image image = Image.FromFile(path);
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            custom.Image = image;
                            custom.Width = 300;
                            custom.Height = 300;
                            custom.SizeMode = PictureBoxSizeMode.StretchImage;
                            custom.Location = new Point(100, 100);
                            pic.Controls.Add(custom);
                        }));
                    }
                }
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnPrintImage_Click(object sender, EventArgs e)
        {
            index = 11;
            this.Cursor = defaultCursor;
            if (!flagImage) return;
            flagImage = false;
            g.DrawImage(custom.Image, custom.Location.X, custom.Location.Y, custom.Width, custom.Height);
            lock (obj)
            {
                pic.Controls.Remove(custom);
            }
            Thread threadSend = new Thread(SendToServer);
            threadSend.Start();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            index = 12;
            if (!flagImage)
            {
                MessageBox.Show("You have not selected a photo !", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = defaultCursor;
            frmResize resize = new frmResize();
            if (resize.ShowDialog() == DialogResult.OK)
            {
                custom.Width = Int32.Parse(resize.tbWidth.Texts);
                custom.Height = Int32.Parse(resize.tbHeight.Texts);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            index = 13;
            Bitmap bitmap = new Bitmap(pic.Width, pic.Height);
            bm = bitmap.Clone() as Bitmap;
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            var thread = new Thread(SendToServer);
            thread.Start();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            index = 14;
            if (indexImage < 1) return;
            var thread = new Thread(SendSignalToServer);
            thread.Start("undo");
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            index = 15;
            if (indexImage == lstImage.Count - 1) return;
            var thread = new Thread(SendSignalToServer);
            thread.Start("redo");
        }

        #endregion
        #region button color
        private void btnBlack_Click(object sender, EventArgs e)
        {
            p.Color = btnBlack.BackColor;
            btnShowColor.BackColor = btnBlack.BackColor;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            p.Color = btnRed.BackColor;
            btnShowColor.BackColor = btnRed.BackColor;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            p.Color = btnBlue.BackColor;
            btnShowColor.BackColor = btnBlue.BackColor;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            p.Color = btnYellow.BackColor;
            btnShowColor.BackColor = btnYellow.BackColor;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            p.Color = btnGreen.BackColor;
            btnShowColor.BackColor = btnGreen.BackColor;
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            p.Color = btnPink.BackColor;
            btnShowColor.BackColor = btnPink.BackColor;
        }

        private void btnGrey_Click(object sender, EventArgs e)
        {
            p.Color = btnGrey.BackColor;
            btnShowColor.BackColor = btnGrey.BackColor;
        }

        private void btnCyan_Click(object sender, EventArgs e)
        {
            p.Color = btnCyan.BackColor;
            btnShowColor.BackColor = btnCyan.BackColor;
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            p.Color = btnOrange.BackColor;
            btnShowColor.BackColor = btnOrange.BackColor;
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            frmOnline onine = new frmOnline();
            onine.PassData(lstUserOnline);
            onine.Show();
        }

        private void frmWorkSpace_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            this.Cursor = defaultCursor;
            p.Color = btnBrown.BackColor;
            btnShowColor.BackColor = btnBrown.BackColor;
        }

        #endregion
        #region fill
        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 6)
            {
                Fill(bm, e.X, e.Y, bm.GetPixel(e.X, e.Y), p.Color);
            }
            if(index == 7)
            {
                lstPointCurve.Add(e.Location);
                bm = bmCurve.Clone() as Bitmap;
                g = Graphics.FromImage(bm);
            }
        }

        private void Validate(Bitmap bitmap, Stack<Point> points,
            int x, int y, Color oldColor, Color newColor)
        {
            Color color = bitmap.GetPixel(x, y);
            if (color == oldColor)
            {
                points.Push(new Point(x, y));
                bitmap.SetPixel(x, y, newColor);
            }
        }

        private void Fill(Bitmap bitmap, int x, int y, Color oldColor, Color newColor)
        {
            lock (obj2)
            {
                Stack<Point> points = new Stack<Point>();
                points.Push(new Point(x, y));
                bitmap.SetPixel(x, y, newColor);
                if (oldColor == newColor) return;
                while (points.Count != 0)
                {
                    Point point = (Point)points.Pop();
                    if (point.X > 0 && point.Y > 0 && point.X < bitmap.Width - 1 && point.Y < bitmap.Height - 1)
                    {
                        Validate(bitmap, points, point.X - 1, point.Y, oldColor, newColor);
                        Validate(bitmap, points, point.X + 1, point.Y, oldColor, newColor);
                        Validate(bitmap, points, point.X, point.Y - 1, oldColor, newColor);
                        Validate(bitmap, points, point.X, point.Y + 1, oldColor, newColor);
                    }
                }
            }
            Thread threadSend = new Thread(SendToServer);
            threadSend.Start();
        }
        #endregion
    }
}
