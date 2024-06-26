﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils.Extensions;
using static Vanara.PInvoke.User32;
namespace WindowsFormsApp1
{
    public partial class Giriş : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Giriş()
        {
            InitializeComponent();
            this.panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            this.panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
            this.panel1.MouseMove += new MouseEventHandler(panel1_MouseMove);
            this.pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            this.pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the ExcelDataSource asynchronously
            excelDataSource2.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the ExcelDataSource asynchronously
            excelDataSource3.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the ExcelDataSource asynchronously
            excelDataSource2.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the ExcelDataSource asynchronously
            excelDataSource4.FillAsync();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {
                    }

        private void Giriş_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void UpdateCsvFile(string filePath, string searchText, string replaceText)
        {
            // Dosyayı satır satır oku
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                // Her satırı virgüllerle böl
                var values = lines[i].Split(',');

                // İlk sütundaki değeri kontrol et (sütun 0)
                if (values[0] == searchText)
                {
                    // Değer eşleşiyorsa, yeni değerle değiştir
                    values[0] = replaceText;
                    // Değiştirilmiş değerleri geri birleştir
                    lines[i] = string.Join(",", values);
                }
            }

            // Değiştirilmiş satırları dosyaya yaz
            File.WriteAllLines(filePath, lines);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string searchText = textBoxSearch.Text; // Aranacak eski değer
            //string replaceText = textBoxReplace.Text; // Yeni değer
            //string filePath = @"C:\path\to\your\file.csv"; // CSV dosya yolu

            //UpdateCsvFile(filePath, searchText, replaceText);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
        
                this.Close();
                Environment.Exit(0);
           

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void labelControl2_MouseMove(object sender, MouseEventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl1.BackColor = myColor;
        }

        private void labelControl3_MouseMove(object sender, MouseEventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl2.BackColor = myColor;
        }

        private void labelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl2_MouseLeave(object sender, EventArgs e)
        {
            int red = 33; // Kırmızı
            int green = 33; // Yeşil
            int blue = 33; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl1.BackColor = myColor;
        }

        private void labelControl3_MouseLeave(object sender, EventArgs e)
        {
            int red = 33; // Kırmızı
            int green = 33; // Yeşil
            int blue = 33; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl2.BackColor = myColor;
        }

        private void labelControl1_MouseLeave(object sender, EventArgs e)
        {
            int red = 33; // Kırmızı
            int green = 33; // Yeşil
            int blue = 33; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl2_MouseEnter(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl3_MouseHover(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl3_MouseEnter(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl1_MouseEnter(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl3.BackColor = myColor;
        }

        private void labelControl2_MouseHover(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl2.BackColor = myColor;
        }

        private void labelControl1_MouseHover(object sender, EventArgs e)
        {
            int red = 45; // Kırmızı
            int green = 45; // Yeşil
            int blue = 45; // Mavi
            Color myColor = Color.FromArgb(red, green, blue);
            labelControl1.BackColor = myColor;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "4545")
            {
                panel1.Hide();
                timer1.Start();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
                AnaSayfa newForm = new AnaSayfa();
                newForm.Show();
                this.Hide();
           
            timer1.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
                AnaSayfa newForm = new AnaSayfa();
                newForm.Show();
                this.Hide();
           
            timer1.Stop();
        }
    }
}
