using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {

        char[] isaret = new char[100];
        char[] islemler = new char[100];
        string aktarma;
        string[] ikinci = new string[100];

        int sayac = 0;
        int deger = 0;
        double sayiUs;
        double us;
        double yuzde;
        string yuzdesi;
        int q = 0;

        double toplamCarpi = 1;
        double toplamNormal = 0;

        char islem;


        public Form1()
        {


            InitializeComponent();
            this.txtCikti.AutoSize = false;

            

            txtCikti.Multiline = true;
            txtCikti.Height = 60;
            txtCikti.Width = 349;
        }

        


        private void btnSifir_Click(object sender, EventArgs e)
        {
            txtCikti.Text = (txtCikti.Text + "0");


        }

        private void btnCiftSifir_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "00";


        }

        private void btnVirgul_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + ",";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "2";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "3";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "8";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "9";

        }

        private void btnArti_Click(object sender, EventArgs e)
        {

            txtCikti.Text = txtCikti.Text + "+";



        }

        private void btnEksi_Click(object sender, EventArgs e)
        {


            txtCikti.Text = txtCikti.Text + "-";


        }

        private void btnCarpi_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "*";
        }

        private void btnBolme_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "/";
        }

        private void txtCikti_TextChanged(object sender, EventArgs e)
        {



        }

        private void btnEsittir_Click(object sender, EventArgs e)
        {
            txtCikti.Text = txtCikti.Text + "=";

            int i = 0;
            int x = 0;
            int b = 0;  // i'yi tutan eleman
            int z = 0;
            int y = 0; //islem onceligi
           


            //Text okuma islemi.

            aktarma = txtCikti.Text;

            foreach (char c in aktarma)
            {

                islemler[i] = c;


                if (islemler[i] == 42 || islemler[i] == 43 || islemler[i] == 45 || islemler[i] == 47 || islemler[i] == 61)
                {
                    isaret[z] = islemler[i];

                    for (int j = b; j < i; j++)
                    {

                        ikinci[x] = ikinci[x] + islemler[j].ToString();



                    }

                    x++;

                    z++; //isaretleri tutan dizinin sayacı

                    b = i + 1;

                }


                i++;

            }


            //Carpma ve bolme islemleri

            foreach (char c in isaret)   // islem onceligi
            {
                if (isaret[y] == 42)
                {

                    toplamCarpi = Convert.ToDouble(ikinci[y]) * Convert.ToDouble(ikinci[y + 1]);

                    ikinci[y + 1] = toplamCarpi.ToString();

                    ikinci[y] = null;

                }
                else if (isaret[y] == 47)
                {
                    toplamCarpi = Convert.ToDouble(ikinci[y]) / Convert.ToDouble(ikinci[y + 1]);

                    ikinci[y + 1] = toplamCarpi.ToString();

                    ikinci[y] = null;
                }


                y++;


            }

            // Toplama ve cikarma islemleri.

            for (int h = 0; h < isaret.Length; h++)
            {
                if (isaret[h] == 43)
                {

                    if (ikinci[h] != null)
                    {
                        if (ikinci[h + 1] == null)
                        {


                            for (int r = 0; r < ikinci.Length; r++)
                            {
                                if (r + 1 + h < ikinci.Length)
                                {
                                    if (ikinci[h + 1 + r] != null)
                                    {
                                        toplamNormal = Convert.ToDouble(ikinci[h]) + Convert.ToDouble(ikinci[h + 1 + r]);

                                        ikinci[h + 1 + r] = toplamNormal.ToString();

                                        ikinci[h] = null;

                                    }
                                }



                            }


                        }
                        else
                        {
                            toplamNormal = Convert.ToDouble(ikinci[h]) + Convert.ToDouble(ikinci[h + 1]);

                            ikinci[h + 1] = toplamNormal.ToString();

                            ikinci[h] = null;

                        }



                    }



                }
                else if (isaret[h] == 45)
                {

                    if (ikinci[h] != null)
                    {
                        if (ikinci[h + 1] == null)
                        {


                            for (int r = 0; r < ikinci.Length; r++)
                            {
                                if (r + 1 + h < ikinci.Length)
                                {
                                    if (ikinci[h + 1 + r] != null)
                                    {
                                        toplamNormal = Convert.ToDouble(ikinci[h]) - Convert.ToDouble(ikinci[h + 1 + r]);

                                        ikinci[h + 1 + r] = toplamNormal.ToString();

                                        ikinci[h] = null;

                                    }
                                }



                            }


                        }
                        else
                        {
                            toplamNormal = Convert.ToDouble(ikinci[h]) - Convert.ToDouble(ikinci[h + 1]);

                            ikinci[h + 1] = toplamNormal.ToString();

                            ikinci[h] = null;

                        }



                    }

                }






            }



            for (int l = 0; l < ikinci.Length; l++)
            {
                if (ikinci[l] != null)
                {
                    txtCikti.Text = ikinci[l];

                    ikinci[l] = null;

                    break;

                }
            }




            if (deger == 1)    // Üs Bölümlü olursa error veriyor,üs çift haneli olursa hata
            {
                char v = txtCikti.Text[txtCikti.Text.Length - 1];
                string yeni = v.ToString();

                us = Convert.ToDouble(yeni);

                txtCikti.Text = Math.Pow(sayiUs, us).ToString();

                deger = 0;
            }

            if (q == 1)
            {
                int sayma = 0;
                double pay;
                double payda = 100;


                foreach (char oku in txtCikti.Text)
                {
                    sayma++;

                    if (oku == 37)
                    {
                        for (int t = sayma; t < txtCikti.Text.Length; t++)
                        {
                            yuzdesi += txtCikti.Text[t];
                        }


                        pay = Convert.ToDouble(yuzdesi);
                        yuzdesi = null;
                        pay = pay / payda;

                        txtCikti.Text = (yuzde * pay).ToString();
                    }
                }

                q = 0;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)   
        {
            
            if(txtCikti.Text != "")
            {
                txtCikti.Text = txtCikti.Text.Remove(txtCikti.Text.Length - 1, 1);
            }
            


        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < islemler.Length; i++)
            {
                islemler[i] = Convert.ToChar(0);
            }

            for (int i = 0; i < ikinci.Length; i++)
            {
                ikinci[i] = null;
            }


            txtCikti.Text = null;
        }

        private void btnKarakok_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());


            txtCikti.Text = Math.Sqrt(Convert.ToDouble(txtCikti.Text)).ToString();
        }

        private void btnKaresi_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());


            txtCikti.Text = (Convert.ToDouble(txtCikti.Text) * Convert.ToDouble(txtCikti.Text)).ToString();

        }

        private void btnKupkok_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());

            double w = 1;
            double p = 3;

            p = w / p;

            txtCikti.Text = Math.Pow(Convert.ToInt32(txtCikti.Text), p).ToString();



        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());

            txtCikti.Text = Math.Pow(Convert.ToInt32(txtCikti.Text), 3).ToString();
        }

        private void btnUssu_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());

            sayiUs = Convert.ToDouble(txtCikti.Text);


            txtCikti.Text += "^";



            deger = 1;



        }

        private void btnYuzde_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());


            yuzde = Convert.ToDouble(txtCikti.Text);

            txtCikti.Text += "%";

            q = 1;

        }

        private void btnFaktoriyel_Click(object sender, EventArgs e)
        {
            btnEsittir_Click(btnEsittir, new EventArgs());

            int faktoriyel = Convert.ToInt32(txtCikti.Text);
            int sonuc1 = 1;
            string ilkDeger = txtCikti.Text + "!";

            for (int i = 2; i <= faktoriyel; i++)
            {
                sonuc1 *= i;
            }

            txtCikti.Text = ilkDeger + "=" + sonuc1.ToString();
        }
    }

}
