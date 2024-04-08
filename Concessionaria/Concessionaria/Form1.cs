using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concessionaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Veicolo> lista = new List<Veicolo>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Concessionaria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auto a1 = new Auto(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text));
            Concessionaria.Items.Add(a1.Stampa());
            PulisciTextBox();
            
        }

        private void motoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Moto m1 = new Moto(Convert.ToInt32(textBox3.Text), portacasco.Checked, textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text));
            Concessionaria.Items.Add(m1.Stampa());
            PulisciTextBox();
        }
        public void PulisciTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            portacasco.Checked = false;
        }

        private void portacasco_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rimuoviVeicoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se è stato selezionato un elemento nella ListBox
            if (Concessionaria.SelectedItem != null)
            {
                // Chiedi conferma all'utente
                DialogResult result = MessageBox.Show("Sei sicuro di voler rimuovere il veicolo?", "Conferma Rimozione", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Se l'utente conferma la rimozione
                if (result == DialogResult.Yes)
                {
                    // Rimuovi l'elemento selezionato dalla ListBox
                    Concessionaria.Items.Remove(Concessionaria.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Seleziona un veicolo da rimuovere.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
