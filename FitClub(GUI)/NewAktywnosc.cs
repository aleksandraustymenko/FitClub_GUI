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
    public partial class NewAktywnosc : Form
    {
        public string Nazwa { get; set; }
        public decimal wartosc { get; set; }
        public NewAktywnosc()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if(textBox1.Text.Length==0)
            {
                MessageBox.Show("Uzupelnij nazwe","nazwa jest wymagana",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Nazwa = textBox1.Text;
            wartosc=numericUpDown1.Value;
            this.Close();
        }

    }
}
