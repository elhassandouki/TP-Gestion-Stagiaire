using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TD_Stagiaires
{
    public partial class ModifierFiliere : Form
    {
        public ModifierFiliere()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        private void ModifierFiliere_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Filiere Where CodeFiliere='" + textBox1.Text + "'", cn);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Aucun résultat!");
                }
                else
                {
                    Niveau.Enabled = true;
                    CodeFiliere.Enabled = true;
                    Secteur.Enabled = true;
                    Filiere.Enabled = true;
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Filiere Where CodeFiliere='" + textBox1.Text + "'", cn);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        CodeFiliere.Text = dr[0].ToString();
                        Filiere.Text = dr[1].ToString();
                        Niveau.Text = dr[2].ToString();
                        Secteur.Text = dr[3].ToString();
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Filiere SET CodeFiliere='" + CodeFiliere.Text + "',Filiere='" + Filiere.Text + "',Niveau='" + Niveau.Text + "',Secteur='" + Secteur.Text + "' WHERE CodeFiliere='" + textBox1.Text + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Groupe Modifié!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
