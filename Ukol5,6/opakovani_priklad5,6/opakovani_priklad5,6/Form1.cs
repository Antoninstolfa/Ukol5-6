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

namespace opakovani_priklad5_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Vek(string rc, out string rok) 
        {
            string[] vstup = rc.Split('/'); 
            rok = vstup[0].Substring(0, 2);
            rok += 2000;
            int mesic = Convert.ToInt32(vstup[0].Substring(2,2)); // nevím co s tím....
            int den = Convert.ToInt32(vstup[0].Substring(4,2));
            DateTime rokNarozeni = new DateTime(Convert.ToInt32(rok), mesic, den);
            TimeSpan vek = (rokNarozeni - DateTime.Now);
            return vek.ToString();
            if(mesic > 12)
            {
                mesic = mesic - 50;
            }
            mesic = mesic % 100;
            switch(mesic)
            {
                case 1: return "leden";
                case 2: return "únor";
                case 3: return "březen";
                case 4: return "duben";
                case 5: return "květen";
                case 6: return "červen";
                case 7: return "červenec";
                case 8: return "srpen";
                case 9: return "září";
                case 10: return "říjen";
                case 11: return "listopad";
                case 12: return "prosinec";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string rok;
            OpenFileDialog otevirac = new OpenFileDialog();
            double soucet = 0, pocitadlo = 0;
            double prumer = 0;
            if(otevirac.ShowDialog() == DialogResult.OK)
            { 
                StreamReader ctenar = new StreamReader(otevirac.FileName);
                while (!ctenar.EndOfStream)
                {
                    string zaznam = ctenar.ReadLine();
                    listBox1.Items.Add(zaznam);
                    string[] vstup = zaznam.Split(';');
                    listBox2.Items.Add("Mesic: " + Vek(zaznam, out rok) + " - Vek: " + rok);
                    soucet += Convert.ToInt32(vstup[1]);
                    pocitadlo++; 
                    SaveFileDialog ukladac = new SaveFileDialog();
                    if (ukladac.ShowDialog() == DialogResult.OK && Convert.ToInt32(vstup[1]) < 3)
                    {
                        StreamWriter zapisovac2 = new StreamWriter(ukladac.FileName, true);
                        zapisovac2.WriteLine("\n" + prumer.ToString());
                        zapisovac2.Close();
                    }
                }
                ctenar.Close();
                prumer = soucet / pocitadlo;
                StreamWriter zapisovac = new StreamWriter(otevirac.FileName, true);
                zapisovac.WriteLine("\n" + prumer.ToString());
                zapisovac.Close();
                MessageBox.Show(prumer.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LawnGreen;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            button2.ForeColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.LawnGreen;
        }
    }
}
