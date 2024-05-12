using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//using Microsoft.Office.Interop.Excel;


namespace WindowsFormsApp1
{
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        string connectionString = "Server=DESKTOP-M9FBO47\\SQLEXPRESS;Database=BakkalOtomasyonu;Trusted_Connection=True;";
        
        void VeritabanınaBaglan ()
        {
            string connectionString = "Server=DESKTOP-M9FBO47\\SQLEXPRESS;Database=BakkalOtomasyonu;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Urunler";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    System.Data.DataTable table = new System.Data.DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    connection.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Panelin arka planını şeffaf yap
           

            // DataGrid Görünümü'nün BorderStyle özelliğini Solid olarak ayarlar
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
          
            //dataGridView1.DoubleBuffered = false;
            // DataGrid Görünümü opasitesini %50'ye ayarlar
            // DataGrid Görünümü opasitesini %50'ye ayarlar
           // dataGridView1.BackColor = Color.FromArgb(128, dataGridView1.BackColor);
            // DataGrid Görünümü'nün BackColor özelliğini şeffaf olmayan bir renge ayarlar
           


            this.BackColor = SystemColors.ControlDark;

            VeritabanınaBaglan();

            // ComboBox'a öğeleri ekleme
            comboBox1.Items.Add("Ürün Adına Göre Ara");
            comboBox1.Items.Add("Ürün Koduna Göre Ara");
            comboBox1.Items.Add("Ürün Fiyatına Göre Ara");
            comboBox1.Items.Add("Stok Miktarına Göre Ara");
            comboBox1.Items.Add("Üretici Firmaya Göre Ara");

            // ComboBox'ın varsayılan öğesini seçme
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Urunler (UrunAdi, UrunKodu, UrunFiyati, StokMiktari, UreticiFirma, Kategori) VALUES (@UrunAdi, @UrunKodu, @UrunFiyati, @StokMiktari, @UreticiFirma, @Kategori)", con);
                cmd.Parameters.AddWithValue("@UrunAdi", "");
                cmd.Parameters.AddWithValue("@UrunKodu", "");
                cmd.Parameters.AddWithValue("@UrunFiyati", 0);
                cmd.Parameters.AddWithValue("@StokMiktari", 0);
                cmd.Parameters.AddWithValue("@UreticiFirma", "");
                cmd.Parameters.AddWithValue("@Kategori", "");
                cmd.ExecuteNonQuery();

                con.Close();
                VeritabanınaBaglan(); // DataGridView'i yenileme işlemi
                MessageBox.Show("Yeni ürün başarıyla eklendi.", "Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        SqlConnection con = new SqlConnection("Server = DESKTOP-M9FBO47\\SQLEXPRESS; Database=BakkalOtomasyonu;Trusted_Connection=True");//");
        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source = "D:\bilişim dersi nesne tabanlı\frmProgramAcma\programlar.mdb"
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
               
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Urunler Set UrunAdi=@UrunAdi,UrunKodu=@UrunKodu,UrunFiyati=@UrunFiyati ,StokMiktari=@StokMiktari,UreticiFirma=@UreticiFirma,Kategori=@Kategori where UrunID=" + dataGridView1.CurrentRow.Cells[0].Value +"" ,  con);
                // cmd.Parameters.AddWithValue("@ProgramDosyasi", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@UrunAdi", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@UrunKodu", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("@UrunFiyati", dataGridView1.CurrentRow.Cells[3].Value);
            cmd.Parameters.AddWithValue("@StokMiktari", dataGridView1.CurrentRow.Cells[4].Value);
            cmd.Parameters.AddWithValue("@UreticiFirma", dataGridView1.CurrentRow.Cells[5].Value.ToString());
            cmd.Parameters.AddWithValue("@Kategori", dataGridView1.CurrentRow.Cells[6].Value.ToString());
            cmd.ExecuteNonQuery();

                con.Close();
                //con.Dispose();
                VeritabanınaBaglan();
                con.Close();
                MessageBox.Show("Ürün Güncellendi", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception hata)
            //{

            // textBox1.Text= hata.Message.ToString();
            //}
        }
        void Guncelle (int UrunID, string UrunAdi)
        {
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
             
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VeritabanınaBaglan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Silme işlemi için kullanıcıya onay sor
                DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Eğer kullanıcı evet derse
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Veritabanı bağlantısını aç
                        con.Open();

                        // Seçilen satırın ID'sini al
                        int selectedRowID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);

                        // Silme sorgusu
                        SqlCommand cmd = new SqlCommand("DELETE FROM Urunler WHERE UrunID = @UrunID", con);
                        cmd.Parameters.AddWithValue("@UrunID", selectedRowID);
                        cmd.ExecuteNonQuery();

                        // Veritabanı bağlantısını kapat
                        con.Close();

                        // DataGridView'i yenileme işlemi
                        VeritabanınaBaglan();

                        // Kullanıcıya mesaj gösterme
                        MessageBox.Show("Kayıt başarıyla silindi!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda kullanıcıya mesaj gösterme
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Kullanıcı bir satır seçmemişse hata mesajı göster
                MessageBox.Show("Silinecek bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    AramaUrunAdi();
                    break;
                case 1:
                    AramaUrunKodu();
                    break;
                case 2:
                    AramaUrunFiyati();
                    break;
                case 3:
                    AramaStokMiktari();
                    break;
                case 4:
                    AramaUreticiFirma();
                    break;
                default:
                    break;
            }
        }
        void AramaUrunAdi()
        {
            try
            {
                con.Open();

                string urunAdi = textBoxArama.Text; // TextBox'tan ürün adını al

                string query = "SELECT * FROM Urunler WHERE UrunAdi LIKE @UrunAdi"; // Ürün adına göre sorgu
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UrunAdi", "%" + urunAdi + "%"); // Kısmi eşleşme için LIKE kullanılıyor
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AramaUrunKodu()
        {
            try
            {
                con.Open();

                string urunKodu = textBoxArama.Text; // TextBox'tan ürün kodunu al

                string query = "SELECT * FROM Urunler WHERE UrunKodu LIKE @UrunKodu"; // Ürün koduna göre sorgu
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UrunKodu", "%" + urunKodu + "%"); // Kısmi eşleşme için LIKE kullanılıyor
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AramaUrunFiyati()
        {
            try
            {
                con.Open();

                decimal urunFiyati = Convert.ToDecimal(textBoxArama.Text); // TextBox'tan ürün fiyatını al

                string query = "SELECT * FROM Urunler WHERE UrunFiyati = @UrunFiyati"; // Ürün fiyatına göre sorgu
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UrunFiyati", urunFiyati);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AramaStokMiktari()
        {
            try
            {
                con.Open();

                int stokMiktari = Convert.ToInt32(textBoxArama.Text); // TextBox'tan stok miktarını al

                string query = "SELECT * FROM Urunler WHERE StokMiktari = @StokMiktari"; // Stok miktarına göre sorgu
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StokMiktari", stokMiktari);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AramaUreticiFirma()
        {
            try
            {
                con.Open();

                string ureticiFirma = textBoxArama.Text; // TextBox'tan üretici firmayı al

                string query = "SELECT * FROM Urunler WHERE UreticiFirma LIKE @UreticiFirma"; // Üretici firmaya göre sorgu
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UreticiFirma", "%" + ureticiFirma + "%"); // Kısmi eşleşme için LIKE kullanılıyor
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxArama_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    AramaUrunAdi();
                    break;
                case 1:
                    AramaUrunKodu();
                    break;
                case 2:
                    AramaUrunFiyati();
                    break;
                case 3:
                    AramaStokMiktari();
                    break;
                case 4:
                    AramaUreticiFirma();
                    break;
                default:
                    break;
            }
        }

        private void button4_Clickwew(object sender, EventArgs e)
        {// Kullanıcıya Excel dosyasını kaydetme konumu için bir iletişim kutusu göster
         /* #region
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Yeni bir Excel uygulaması oluştur
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = true;

                    // Yeni bir çalışma kitabı oluştur
                    Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Worksheet worksheet = null;

                    // İlk sayfayı al
                    worksheet = (Worksheet)workbook.Sheets[1];
                    worksheet = workbook.ActiveSheet;

                    // Sütun başlıklarını ekle
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                        ((Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                    }

                    // Verileri hücrelere yerleştir
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value;
                        }
                    }

                    // Excel'i kaydet
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show("Excel dosyası başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dosya seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Excel uygulamasını kapat
                    excelApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
         */
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.FromArgb(int.Parse(((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row["colorColumn"].ToString()));
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //e.CellStyle.BackColor = Color.FromArgb(int.Parse(((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row["colorColumn"].ToString()));
        }
    }
}

