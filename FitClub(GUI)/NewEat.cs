using System;
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
    public partial class NewEat : Form
        
    {
        public string Nazwa { get; set; }

        public double Białko { get; set; }

        public double Tłuszcze { get; set; }

        public double Weglowodany { get; set; }
        public double Kalorie { get; set; }
        public double Waga { get; set; }
        public NewEat()
        {
            InitializeComponent();
        }

        private void NewEat_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Uzupelnij nazwe", "nazwa jest wymagana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Nazwa = textBox1.Text;
            Kalorie = Decimal.ToDouble(numericUpDown1.Value);
            Białko = Decimal.ToDouble(numericUpDown2.Value);
            Tłuszcze = Decimal.ToDouble(numericUpDown3.Value);
            Weglowodany = Decimal.ToDouble(numericUpDown4.Value);
            Waga = Decimal.ToDouble(numericUpDown5.Value);
            this.Close();
        }
    }
}
