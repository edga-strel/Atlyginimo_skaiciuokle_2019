using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlyginimo_skaičiuoklė_2019
{
    public partial class Form1 : Form
    {
        double Bruto, Neto, NPD, GPM, PSD, SOC, VSD, Pensija, Islaidos;

        public Form1()
        {
            InitializeComponent();
        }


        private void Calcbutton_Click(object sender, EventArgs e) //Is Bruto i Neto skaiciavimas
        {
            try
            {
                //Ivedamas atlyginimas bruto
                Bruto = double.Parse(BrutotextBox.Text);
                AntPopieriaustextBox.Text = Bruto.ToString();

                //NPD = 300 EUR - 0,15 x("Mėnesinis darbo užmokestis" - 555 EUR)
                if (Bruto < 2555)
                {
                    NPD = 300 - 0.15 * (Bruto - 555);

                    if (Bruto <= 555)
                    {
                        NPD = 300;
                    }
                }
                else NPD = 0;
                NPD = Math.Round(NPD, 2);
                NPDtextBox.Text = NPD.ToString();


                //Pajamų mokestis (GPM) 20%
                if (Bruto >= 300)
                {
                    GPM = (Bruto - NPD) * 0.20;
                }
                else GPM = 0;
                GPM = Math.Round(GPM, 2);
                GPMtextBox.Text = GPM.ToString();

                //Sveikatos draudimas(PSD) 6,98 %
                PSD = Bruto * 0.0698;
                PSD = Math.Round(PSD, 2);
                PSDtextBox.Text = PSD.ToString();

                //Pensijų ir soc. Draudimas 12,52%
                SOC = Bruto * 0.1252;
                SOC = Math.Round(SOC, 2);
                SOCtextBox.Text = SOC.ToString();

                //"Sodros" įmoka (VSD) 1,77%	
                VSD = Bruto * 0.0177;
                VSD = Math.Round(VSD, 2);
                VSDtextBox.Text = VSD.ToString();

                //II-pakopos pensijai kaupti
                if (radioButton1.Checked == true)
                {
                    Pensija = Bruto * 0.03;
                }
                else if (radioButton2.Checked == true)
                {
                    Pensija = Bruto * 0.018;
                }
                else
                    Pensija = 0;
                Pensija = Math.Round(Pensija, 2);
                PensijatextBox.Text = Pensija.ToString();

                //Užmokestis "į rankas"
                Neto = Bruto - GPM - PSD - SOC - Pensija;
                Neto = Math.Round(Neto, 2);
                NetotextBox.Text = Neto.ToString();

                //Darbdavio išlaidos
                Islaidos = Bruto + VSD;
                Islaidos = Math.Round(Islaidos, 2);
                IslaidostextBox.Text = Islaidos.ToString();        
            }
            catch (Exception) 
            {
                MessageBox.Show("Turite įvesti skaičių į atlyginimo lauką"); 
            }
        }

        private void Isvalytibutton_Click(object sender, EventArgs e)
        {
            BrutotextBox.Clear();
            NPDtextBox.Clear();
            GPMtextBox.Clear();
            PSDtextBox.Clear();
            SOCtextBox.Clear();
            VSDtextBox.Clear();
            AntPopieriaustextBox.Clear();
            PensijatextBox.Clear();
            NetotextBox.Clear();
            IslaidostextBox.Clear();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void button5_Click(object sender, EventArgs e) //Is Neto i Bruto skaiciavimas
        {
            try
            {
                //Ivedemas atlyginimas Neto
                Neto = double.Parse(NetotextBox2.Text);

                // Jei suma nevirsija 395,77 €, NPD = 300;
                if (Neto <= 395.77) 
                {
                    NPD = 300;
                    NPD = Math.Round(NPD, 2);
                    NPDtextBox2.Text = NPD.ToString();


                    //Atliekamas skaiciavimas, Kol suma nevirsija 241,5 €,  GPM = 0;
                    if (Neto <= 241.5) 
                    {
                        GPM = 0;
                        GPMtextBox2.Text = GPM.ToString();

                        //Apskaiciuojamas Bruto
                        Bruto = Neto / 0.805;
                        Bruto = Math.Round(Bruto, 2);
                        BrutotextBoxas.Text = Bruto.ToString();

                        //Sveikatos draudimas(PSD) 6,98 %
                        PSD = Bruto * 0.0698;
                        PSD = Math.Round(PSD, 2);
                        PSDtextBox2.Text = PSD.ToString();

                        //Pensijų ir soc. Draudimas 12,52%
                        SOC = Bruto * 0.1252;
                        SOC = Math.Round(SOC, 2);
                        SOCtextBox2.Text = SOC.ToString();

                        //"Sodros" įmoka (VSD) 1,77%	
                        VSD = Bruto * 0.0177;
                        VSD = Math.Round(VSD, 2);
                        VSDtextBox2.Text = VSD.ToString();
                        
                        //Darbdavio išlaidos
                        Islaidos = Bruto + VSD;
                        Islaidos = Math.Round(Islaidos, 2);
                        IslaidostextBox2.Text = Islaidos.ToString();
                        
                        //II-pakopos pensijai kaupti
                        if (radioButton4.Checked == true)
                        {
                            Pensija = Bruto * 0.03;
                        }
                        else if (radioButton5.Checked == true)
                        {
                            Pensija = Bruto * 0.018;
                        }
                        else
                            Pensija = 0;
                        Pensija = Math.Round(Pensija, 2);
                        PensijatextBox2.Text = Pensija.ToString();

                        
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Turite įvesti skaičių į atlyginimo lauką");
            }
        }

        private void ClearButton2_Click_1(object sender, EventArgs e)
        {
            BrutotextBoxas.Clear();
            NPDtextBox2.Clear();
            GPMtextBox2.Clear();
            PSDtextBox2.Clear();
            SOCtextBox2.Clear();
            VSDtextBox2.Clear();
            PensijatextBox2.Clear();
            NetotextBox2.Clear();
            IslaidostextBox2.Clear();
        }

        private void Exitbutton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region insert

        private void NPDtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }

}








