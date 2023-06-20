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

namespace Lab6_LTM
{
    public partial class Client : Form
    {
        public Point end = new Point();
        public Point start = new Point();
        public Pen p;
        bool draw = false;
        string color;
        Graphics graphics;
        Bitmap bmp;
        TcpClient client;
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
        Thread receiveThread;

        public Client()
        {
            InitializeComponent();
            GenerateVariables();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        void GenerateVariables()
        {
            graphics = pictureBox1.CreateGraphics();
            comboBox1.Text = "8";
            color = "#000000";
            textBox1.Text = color;
            CreateCanvas();

            // initialize the Pen object
            int size;
            if (comboBox1.Text == "")
            {
                size = 8;
            }
            else
            {
                size = Convert.ToInt32(comboBox1.Text);
            }
            Color newColor = ColorTranslator.FromHtml(color);
            p = new Pen(newColor, size);
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            // Connect to the server
            client = new TcpClient();
            client.Connect("127.0.0.1", 5432);

            stream = client.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            receiveThread = new Thread(ReceiveDrawingData);
            receiveThread.Start();
        }

        //bmp
        void CreateCanvas()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            pictureBox1.BackgroundImage = bmp;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            start = e.Location;

            int size;
            if (comboBox1.Text == "")
            {
                size = 8;
            }
            else
            {
                size = Convert.ToInt32(comboBox1.Text);
            }

            Color newColor = ColorTranslator.FromHtml(color);
            p = new Pen(newColor, size);
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            // Send the mouse down event to the server
            writer.WriteLine($"MOUSE_DOWN|{start.X}|{start.Y}");
            writer.Flush();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    end = e.Location;
                    graphics.DrawLine(p, start, end);
                    start = end;
                    pictureBox1.Invalidate();

                    // Send the mouse move event to the server
                    writer.WriteLine($"MOUSE_MOVE|{end.X}|{end.Y}");
                    writer.Flush();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

            // Send the mouse up event to the server
            writer.WriteLine("MOUSE_UP");
            writer.Flush();

            writer.WriteLine($"LINE_CHANGE|{comboBox1.Text}");
            writer.Flush();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCanvas();

            // Send a clear canvas event to the server
            writer.WriteLine("CLEAR_CANVAS|");
            writer.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                color = "#" + (cd.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                textBox1.Text = color;

                // Send the color change event to the server
                writer.WriteLine($"COLOR_CHANGE|{color}");
                writer.Flush();
            }
        }

        //save img
        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog s = new SaveFileDialog())
            {
                s.Filter = "Png files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|Bitmaps (*.bmp)|*.bmp";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(s.FileName))
                        {
                            File.Delete(s.FileName);
                        }

                        string fileExtension = Path.GetExtension(s.FileName).ToLower();
                        System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                        if (fileExtension == ".png")
                        {
                            imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        }
                        else if (fileExtension == ".bmp")
                        {
                            imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                        }

                        bmp.Save(s.FileName, imageFormat);
                        MessageBox.Show("Image saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}");
                    }
                }
            }
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Disconnect from the server and close the application
            DisconnectFromServer();
            Application.Exit();
        }


        private void ReceiveDrawingData()
        {
            try
            {
                while (true)
                {
                    string data = reader.ReadLine();
                    if (data != null)
                    {
                        // Process the received drawing data and update the local canvas
                        string[] parts = data.Split('|');
                        if (parts.Length >= 2)
                        {
                            string command = parts[0];
                            switch (command)
                            {
                                case "MOUSE_DOWN":
                                    int startX = Convert.ToInt32(parts[1]);
                                    int startY = Convert.ToInt32(parts[2]);
                                    start = new Point(startX, startY);
                                    break;

                                case "MOUSE_MOVE":
                                    int endX = Convert.ToInt32(parts[1]);
                                    int endY = Convert.ToInt32(parts[2]);
                                    end = new Point(endX, endY);
                                    graphics.DrawLine(p, start, end);
                                    start = end;
                                    pictureBox1.Invalidate();
                                    break;

                                case "CLEAR_CANVAS":
                                    CreateCanvas();
                                    break;

                                case "COLOR_CHANGE":
                                    string newColor = parts[1];
                                    color = newColor;
                                    textBox1.Text = color;
                                    break;
                                case "IMAGE":
                                    string base64Image = parts[1];
                                    byte[] imageBytes = Convert.FromBase64String(base64Image);
                                    using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                                    {
                                        pictureBox1.Image = Image.FromStream(memoryStream);
                                    }
                                    break;
                                case "CLIENTS_COUNT":
                                    string connectedClients = parts[1].Substring(0, 1);
                                    textBox5.Text = connectedClients;
                                    break;
                                case "LINE_CHANGE":
                                    string lineSize = parts[1];
                                    int newSize;
                                    if (int.TryParse(lineSize, out newSize))
                                    {
                                        p.Width = newSize;
                                        comboBox1.Text = lineSize;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectFromServer()
        {
            receiveThread.Abort();
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //import img part
        private void button3_Click(object sender, EventArgs e)
        {
            string imageUrl = textBox2.Text;
            int desiredWidth = Convert.ToInt32(textBox4.Text);
            int desiredHeight = Convert.ToInt32(textBox3.Text);

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);
                    using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                    {
                        Image originalImage = Image.FromStream(memoryStream);
                        Image resizedImage = ResizeImage(originalImage, desiredWidth, desiredHeight);
                        string base64Image = ImageToBase64(resizedImage);
                        writer.WriteLine($"IMAGE|{base64Image}");
                        writer.Flush();
                        pictureBox1.Image = resizedImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing image from URL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private string ImageToBase64(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        
    }
}
