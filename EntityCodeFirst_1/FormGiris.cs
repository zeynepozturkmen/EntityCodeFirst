using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCodeFirst_1.DAL.ORM.Context;
using EntityCodeFirst_1.DAL.ORM.Entity;

namespace EntityCodeFirst_1
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        ProjeContext db = new ProjeContext();

        //Login butonu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               

                    if (db.Users.Any(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text))
                    {
                        UrunEkle f2 = new UrunEkle(this);
                        f2.Show();
                        Hide();
                    }
                    else
                    {

                        lblMessage.Visible = true;
                        lblMessage.Text = "Bilgileri hatalı girdiniz.";
                    }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }


        //Sign Up
        private void btnInsert_Click(object sender, EventArgs e)
        {
            AppUser user = new AppUser();
            user.Name = txtName.Text;
            user.Lastname = txtLastname.Text;
            user.UserName = (txtName.Text + txtLastname.Text).ToLower();
            user.Password = (txtName.Text + txtLastname.Text).ToLower();
            user.Birth_Date = dtPckrBirthDate.Value;
            user.Gender = Convert.ToString(cmbGender.SelectedItem);
            user.Added_Date = DateTime.Now;
            user.isActive = true;

            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Kayıt başarılı.");
            MessageBox.Show("UserName :  " +user.UserName+ " ve Password: "+user.Password);


        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @" C:\Users\mine-\Desktop\Githuba Atılacaklar\EntityCodeFirst_1\EntityCodeFirst_1\Images\customer.png";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
