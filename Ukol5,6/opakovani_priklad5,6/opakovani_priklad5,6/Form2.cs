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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog otevirac = new OpenFileDialog();
            if (otevirac.ShowDialog() == DialogResult.OK)
            {
                int[] delky = new int[4];
                int i = 0;
                StreamReader ctenar = new StreamReader(otevirac.FileName);
                while(!ctenar.EndOfStream)
                {
                    listBox1.Items.Add(ctenar.ReadLine());
                    string radek = ctenar.ReadLine();
                    string[] slova = radek.Split(';');//nevim
                    int delkaslova = slova[0].Count();
                    foreach(string slovo in slova)
                    {
                        if(delkaslova < slovo.Count())
                        {
                            delky[i] = (slovo.Count()/10);
                            i++;
                        }     
                    }
                }
                ctenar.Close();
                FileStream tok = new FileStream("Cisla.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter zapisovac = new BinaryWriter(tok);
                foreach(int cislo in delky)
                {
                    zapisovac.Write(cislo + "\n");
                }
                tok.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream tok2 = new FileStream("Cisla.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader ctenar = new BinaryReader(tok2);
            ctenar.BaseStream.Position = 0;
            while(ctenar.BaseStream.Length < ctenar.BaseStream.Position)
            {
                listBox2.Items.Add(ctenar.ReadInt32());
            }
            tok2.Close();
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Gold;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.LawnGreen;
        }
    }
}
