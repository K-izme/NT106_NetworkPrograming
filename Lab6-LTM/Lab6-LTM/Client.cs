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

            // Connect to the server
            client = new TcpClient();
            client.Connect("127.0.0", 1234); // Replace with your server IP address and desired port number

            // Set up network stream and readers/writers
            stream = client.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            // Start a new thread to continuously receive drawing data from the server
            receiveThread = new Thread(ReceiveDrawingData);
            receiveThread.Start();
        }

        void CreateCanvas()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            pictureBox1.BackgroundImage = bmp;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
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
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCanvas();

            // Send a clear canvas event to the server
            writer.WriteLine("CLEAR_CANVAS");
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files| *.png|jpeg files| *.jpg|bitmaps | *.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Disconnect from the server and close the application
            DisconnectFromServer();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReceiveDrawingData()
        {
            while (client.Connected)
            {
                try
                {
                    string data = reader.ReadLine();

                    // Parse the received data and update the local canvas accordingly
                    string[] tokens = data.Split('|');
                    string eventType = tokens[0];

                    if (eventType == "MOUSE_DOWN")
                    {
                        int x = int.Parse(tokens[1]);
                        int y = int.Parse(tokens[2]);
                        start = new Point(x, y);
                    }
                    else if (eventType == "MOUSE_MOVE")
                    {
                        int x = int.Parse(tokens[1]);
                        int y = int.Parse(tokens[2]);
                        end = new Point(x, y);
                        graphics.DrawLine(p, start, end);
                        start = end;
                        pictureBox1.Invalidate();
                    }
                    else if (eventType == "MOUSE_UP")
                    {
                        draw = false;
                    }
                    else if (eventType == "CLEAR_CANVAS")
                    {
                        CreateCanvas();
                    }
                    else if (eventType == "COLOR_CHANGE")
                    {
                        color = tokens[1];
                        textBox1.Text = color;
                    }
                }
                catch (IOException)
                {
                    // An error occurred while reading data from the stream
                    // Handle the error or gracefully terminate the application
                    break;
                }
            }
        }

        private void DisconnectFromServer()
        {
            // Close all network resources
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();

            // Join the receive thread (wait for it to finish) before closing the form
            receiveThread.Join();
        }
    }
}
