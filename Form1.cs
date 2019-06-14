using System;
using System.Windows.Forms;

namespace Termo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //prueba fallida de show dialog para form2
            // Form2 frm2 = new Form2();
            // frm2.ShowDialog();

            DialogResult result;
            result = MessageBox.Show("Ajustar nivel y temperatura?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);


            if (result == DialogResult.OK)
            {
                decimal temperaturaDeseo = this.numericUpDown2.Value;
                string temperatura = this.label3.Text;
                string litros = this.label1.Text;
                int litrosDeseo = 250;


                int numTdeseo = Convert.ToInt32(temperaturaDeseo);
                int numTemp = Convert.ToInt32(temperatura);
                int numLitros = Convert.ToInt32(litros);


                if (litrosDeseo > numLitros)
                {
                    do
                    {
                        numLitros++;

                    } while (litrosDeseo != numLitros);

                    this.label1.Text = Convert.ToString(numLitros);
                }


                if (numTdeseo > numTemp)
                {
                    do
                    {
                        numTemp++;

                    } while (numTdeseo != numTemp);

                    this.label3.Text = Convert.ToString(numTemp);
                }

                if (numTemp > numTdeseo)
                {
                    do
                    {
                        numTemp--;

                    } while (numTdeseo != numTemp);

                    this.label3.Text = Convert.ToString(numTemp);
                }


                if (numTemp >= -10 && numTemp < 25)
                { this.animationTermo.ImageIndex = 1; }

                if (numTemp > 25 && numTemp < 60)
                { this.animationTermo.ImageIndex = 2; }

                if (numTemp >= 60 && numTemp <= 65)
                { this.animationTermo.ImageIndex = 3; }

                if (numTemp > 65 && numTemp <= 90)
                { this.animationTermo.ImageIndex = 4; }


                if (numLitros == 250)
                { this.animationTanque.ImageIndex = 3; }


            }
            if (result == DialogResult.Cancel)
            { }


        }

        private void Button2_Click(object sender, EventArgs e)

        {
            Random rnd = new Random();

            int temperatura = rnd.Next(-10, 90);
            this.label3.Text = Convert.ToString(temperatura);

            int litros = rnd.Next(0, 250);
            this.label1.Text = Convert.ToString(litros);



            if (litros >= 0 && litros < 62)
            { this.animationTanque.ImageIndex = 0; }

            if (litros > 62 && litros < 125)
            { this.animationTanque.ImageIndex = 1; }

            if (litros > 125 && litros < 187)
            { this.animationTanque.ImageIndex = 2; }

            if (litros > 187 && litros <= 250)
            { this.animationTanque.ImageIndex = 3; }

            /////////////////////////////////////////////

            if (temperatura >= -10 && temperatura < 25)
            { this.animationTermo.ImageIndex = 1; }

            if (temperatura > 25 && temperatura < 60)
            { this.animationTermo.ImageIndex = 2; }

            if (temperatura > 60 && temperatura <= 65)
            { this.animationTermo.ImageIndex = 3; }

            if (temperatura > 65 && temperatura <= 90)
            { this.animationTermo.ImageIndex = 4; }

        }

    }
}