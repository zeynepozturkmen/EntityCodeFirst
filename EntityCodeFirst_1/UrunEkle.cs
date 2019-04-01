using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCodeFirst_1.DAL.ORM.Entity;
using EntityCodeFirst_1.DAL.ORM.Context;

namespace EntityCodeFirst_1
{
    public partial class UrunEkle : Form
    {
        FormGiris mainForm;

        public UrunEkle(FormGiris f1)
        {
            mainForm = f1;
            InitializeComponent();
        }

        ProjeContext db = new ProjeContext();

    

        //Ürün ekle sayfasının kapatınca giriş sayfasına dönüyor.
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
           // mainForm.Show();
            Product p = new Product();
            {
                p.Name = txtUrunAdi.Text;
                p.Added_Date = DateTime.Now;
                p.UnitPrice = decimal.Parse(txtUrunFiyati.Text);
                p.UnitInStock = short.Parse(txtStokMiktari.Text);
                p.QuantityPerUnit = txtBirimi.Text;
                p.CategoryID = (int)cmbCategoryName.SelectedValue; 
                p.isActive = true;
                db.Products.Add(p);
                db.SaveChanges();

                FillDataGrid();


            }

        }

   

        private void FillDataGrid()
        {
            var FillProduct = db.Products.Select(x => new
            {
                ProductID=x.ID,
               ProductName= x.Name,
                x.UnitInStock,
                x.UnitPrice,
                CategoryName = x.category.Name,

            }).ToList();

            dataGridView1.DataSource = FillProduct;

        }

        private void FillCmbCategory()
        {
            var FillCmbCategory = db.Categories.Select(x => new
            {
                x.Name,
                x.ID
            }).ToList();

            cmbCategoryName.DisplayMember = "Name";
            cmbCategoryName.ValueMember = "ID";
            cmbCategoryName.DataSource = FillCmbCategory;
          

        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\mine-\Desktop\Githuba Atılacaklar\EntityCodeFirst_1\EntityCodeFirst_1\Images\iconfinder_box_196757.png";

            FillDataGrid();
            FillCmbCategory();

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int FindProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var FindProduct = db.Products.Find(FindProductID);
            txtUrunAdi.Text = FindProduct.Name;
            txtUrunFiyati.Text = FindProduct.UnitPrice.ToString();
            txtStokMiktari.Text = FindProduct.UnitInStock.ToString();
            txtBirimi.Text = FindProduct.QuantityPerUnit.ToString();

            cmbCategoryName.SelectedValue = (int)FindProduct.CategoryID;


        }


        //tek bir kayıt silme
        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int FindProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var FindProduct = db.Products.Find(FindProductID);
                db.Products.Remove(FindProduct);
                db.SaveChanges();
                MessageBox.Show("Seçilen kayıt silindi.");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Birden fazla kayıt seçtiniz.Lütfen 'çoklu kayıt silme' butonunu kullanınız ya da tek bir kayıt seçip tekrar deneyiniz.");
            }

        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            int FindProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var FindProduct = db.Products.Find(FindProductID);
            FindProduct.Name = txtUrunAdi.Text;
            FindProduct.UnitPrice = Convert.ToDecimal(txtUrunFiyati.Text);
            FindProduct.UnitInStock = Convert.ToInt16(txtStokMiktari.Text);
            FindProduct.CategoryID = (int)cmbCategoryName.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Kayıt Güncellendi.");
            FillDataGrid();
            



        }


        //Çoklu kayıt silme
        private void btnCokluUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    int FindProductID = Convert.ToInt32(item.Cells[0].Value);
                    var FindProduct = db.Products.Find(FindProductID);
                    db.Products.Remove(FindProduct);
                    db.SaveChanges();
                }
                MessageBox.Show("Seçilen kayıtlar silindi.");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Bir kayıt seçtiniz.Lütfen 'sil' butonunu kullanınız ya da birden fazla kayıt seçip tekrar deneyiniz.");
            }

        }
    }
}
