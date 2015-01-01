using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMEI_No_Dogrulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Kontrol_Click(object sender, EventArgs e)
        {
            long sayi;
            int[] dizi = new int[15];
            sayi = long.Parse(textBox1.Text);

            if (textBox1.TextLength < 15)
            {
                MessageBox.Show("IMEI Numarası 0 ile 15 arasında olmalıdır");
            }
            else if(textBox1.TextLength == 15)
            {
                for (int i = 0; i < 15 ; i++)
                {
                    dizi[i] = Convert.ToInt32(sayi % 10);
                    sayi = sayi / 10;
                }

                int onluk, birlik;
                for (int i = 13; i >= 1; i-=2)
                {
                    dizi[i] = dizi[i] * 2;
                    onluk   = dizi[i] / 10;
                    birlik  = dizi[i] % 10;
                    dizi[i] = onluk + birlik;
                }


                int toplam = 0;
                for (int i = 1; i < 15; i++)
                {
                    toplam += dizi[i];
                }

                int sonuc = toplam % 10;

                if (10 - sonuc == dizi[0])
                    MessageBox.Show("IMEI NO GECERLİ");
                else
                    MessageBox.Show("GECERSİZ IMEI");
            }
       }
           
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //rakam sınırlaması
            if (textBox1.TextLength == 15)
                e.Handled = true;
            
            //Harf girişi kısıtlaması
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblBasamak.Text = Convert.ToString(15 - textBox1.TextLength);

            if (textBox1.TextLength > 15)
            {
                MessageBox.Show("15'ten fazla giremezsiniz.Lutfen Tekrar Deneyin ");
                textBox1.Text = "";
            }
            
        }

    }
}
