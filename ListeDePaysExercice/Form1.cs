using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListeDePaysExercice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string ligne;
            Char caractere = ';';

            System.IO.StreamReader fichier = new System.IO.StreamReader
                (@"C:\Users\dell-optilex-3010\Desktop\Pays_Capitale.csv", Encoding.GetEncoding("iso-8859-1"));

            while ((ligne = fichier.ReadLine()) != null)
            {
                String[] substrings = ligne.Split(caractere);

                pays.Items.Add(substrings[0]);
                capitale.Items.Add(substrings[1]);
            }

            fichier.Close();
        }

        private void pays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pays.SelectedIndex >= 0)
            {
                String listePays = pays.SelectedItem.ToString();
                int index = pays.SelectedIndex;
                capitale.SetSelected(index, true);
                textPays.Text = pays.SelectedItem.ToString();
                textCapitale.Text = capitale.SelectedItem.ToString();
            }           
        }

        private void capitale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textPays_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCapitale_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if (textPays.Text != "" && textCapitale.Text != "")
            {
                Boolean existant = false;
                foreach (string str in pays.Items)
                {
                    if (textPays.Text == str)
                    {
                        existant = true;
                        MessageBox.Show("Le pays est déjà existant dans la liste");
                    }
                }
                foreach (string str2 in capitale.Items)
                {
                    if (textCapitale.Text == str2)
                    {
                        existant = true;
                    }
                }
                if (!existant)
                {
                    pays.Items.Add(textPays.Text);
                    capitale.Items.Add(textCapitale.Text);
                    MessageBox.Show("Veuillez sauvegarder pour valider la mise à jour!!");
                }
            }
        }

        private void sauvegarder_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter fichier = new System.IO.StreamWriter
               (@"C:\Users\dell-optilex-3010\Desktop\Pays_Capitale.csv", true, Encoding.GetEncoding("iso-8859-1"));
            for (int i = 02; i < pays.Items.Count; i++)
            {
                fichier.WriteLine(pays.Items[i] + ";" + capitale.Items[i]);
            }
            fichier.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            pays.Items.Remove(textPays.Text);
            capitale.Items.Remove(textCapitale.Text);
            textPays.Text = " ";
            textCapitale.Text = " ";
            MessageBox.Show("Selection supprimé");
        }
    }
}
