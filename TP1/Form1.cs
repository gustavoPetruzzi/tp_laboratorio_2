using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        private void CC_Click(object sender, EventArgs e)
        {
            Calculadora.Limpiar(txtNumero1, txtNumero2, cmbOperacion, lblResultado);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            double resultado;

            resultado = Calculadora.Operar(numero1, numero2, cmbOperacion.Text);
            lblResultado.Text = resultado.ToString();
        }
 
    }
}
