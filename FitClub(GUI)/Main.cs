using FitClub.Controller;
using System;
using FitClub.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FitClub_GUI_
{
    public partial class Main : Form
    {
        private UżytkownikController użytkownikController;// = new UżytkownikController("");
        JeśćControler jescControler;//;= new JeśćControler(użytkownikController);
        CwiczeniaControler cwiczeniaControler;//= new CwiczeniaControler(użytkownikController.Aktualny);
        public Main()
        {
            InitializeComponent();
            listView1.View = View.Details;

            listView1.Columns.Add("Nazwa",-2,HorizontalAlignment.Left);
            listView1.Columns.Add("KalorieNaMin", -2, HorizontalAlignment.Left);

            listView2.Columns.Add("Nazwa", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Kalorie", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Bialko", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Tluszcze", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Weglowodany", -2, HorizontalAlignment.Left);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                użytkownikController = new UżytkownikController("");
                użytkownikController.OtrzymacUżytkownika();
            }
            catch(ArgumentNullException e1)
            {
                NewUserForm NU = new NewUserForm();
                NU.ShowDialog();
                if(string.IsNullOrEmpty(NU.imie))
                {
                    Application.Exit();
                    return;
                }
                użytkownikController = new UżytkownikController(NU.imie);

                użytkownikController.UstawNowegoUżytkownika("kobieta", DateTime.Now, 0.00, 0.00);

            }
            catch(Exception ef)
            {
                MessageBox.Show("Skontaktuj się z autorem programu,jest nieprzewiedzane",ef.Message, MessageBoxButtons.OK);
             //
            }

            ImieaktualnegoUser.Text = użytkownikController.Aktualny.Imie;
            jescControler = new JeśćControler(użytkownikController.Aktualny);

             cwiczeniaControler = new CwiczeniaControler(użytkownikController.Aktualny);
            if(cwiczeniaControler==null)
            {
                MessageBox.Show("POpsuta");
            }
            RefreshListJedzenie();
            RefreshListAktywnosc();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewAktywnosc newAktywnosc = new NewAktywnosc();
            newAktywnosc.ShowDialog();
            Aktywnosc aktywnosc = new Aktywnosc(newAktywnosc.Nazwa,newAktywnosc.wartosc);
            cwiczeniaControler.Dodaj(aktywnosc, DateTime.Now, DateTime.Now); ;
            RefreshListAktywnosc();
        }
        private void RefreshListAktywnosc()
        {
            listView1.Items.Clear();
            foreach(var item in cwiczeniaControler.cwiczenia)
            {
                ListViewItem viewItem = new ListViewItem(item.Aktywnosc.Nazwa);
                viewItem.SubItems.Add(item.Aktywnosc.KalorieNaMin.ToString());
                listView1.Items.Add(viewItem);
            }
        }
        private void RefreshListJedzenie()
        {
            listView2.Items.Clear();
            foreach(var item in jescControler.Jedzenie)
            {
                ListViewItem listViewItem = new ListViewItem(item.Nazwa);
                listViewItem.SubItems.Add(item.Kalorie.ToString());
                listViewItem.SubItems.Add(item.Białko.ToString());
                listViewItem.SubItems.Add(item.Tłuszcze.ToString());
                listViewItem.SubItems.Add(item.Weglowodany.ToString());
                listView2.Items.Add(listViewItem);
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                użytkownikController.Zapisz();
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewEat newEat = new NewEat();
            newEat.ShowDialog();

            Jedzenia jedzenia = new Jedzenia(newEat.Nazwa,newEat.Kalorie,newEat.Białko,newEat.Tłuszcze,newEat.Weglowodany);
            jescControler.Dodaj(jedzenia,1.00);
            RefreshListJedzenie();

        }
    }
}
