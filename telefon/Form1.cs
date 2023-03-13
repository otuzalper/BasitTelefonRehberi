using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telefon
{
    public partial class Form1 : Form
    {

        List<String> isimler_list = new List<string>();
        List<String> telefon_list = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 180;
            button4.Visible = false;
            button5.Visible = false;
        }
        void DiziAktar()
        {
            listBox1.Items.Clear();
            foreach (var item in isimler_list)
            {
                listBox1.Items.Add(item);
            }
        }
        void EkranAc()
        {
            listBox1.Enabled = !listBox1.Enabled;
            button1.Enabled = !button1.Enabled;
            button3.Enabled = !button3.Enabled;
            textBox1.Focus();
            for (int i = 0; i < 20; i++)
            {
                this.Width += 10;
            }
        }
        void EkranKapat()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Width -= 10;
            }
            listBox1.Enabled = !listBox1.Enabled;
            button1.Enabled = !button1.Enabled;
            button3.Enabled = !button3.Enabled;
        }
        void KayitEkle()
        {
            isimler_list.Add(textBox1.Text);
            telefon_list.Add(textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            DiziAktar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button5.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            EkranAc();
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EkranAc();
            button5.Visible = true;
            button4.Visible = false;
            textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            textBox2.Text = telefon_list[isimler_list.IndexOf(textBox1.Text)];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KayitEkle();
            button4.Visible = false;
            EkranKapat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                isimler_list[listBox1.SelectedIndex] = textBox1.Text;
                telefon_list[listBox1.SelectedIndex] = textBox2.Text;
                DiziAktar();
                EkranKapat();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isimler_list.Remove(listBox1.SelectedItem.ToString());
            telefon_list.RemoveAt(listBox1.SelectedIndex);
            DiziAktar();
        }
    }
}
