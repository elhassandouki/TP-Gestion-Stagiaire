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
    public partial class ModifierGroupe : Form
    {
        public ModifierGroupe()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Groupes Where CodeGroupe='" + textBox1.Text + "'", cn);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Aucun résultat!");
                }
                else
                {
                    CodeGroupe.Enabled = true;
                    CodeFiliere.Enabled = true;
                    Année.Enabled = true;
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Groupes Where CodeGroupe='" + textBox1.Text + "'", cn);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        CodeGroupe.Text = dr[0].ToString();
                        CodeFiliere.Text = dr[1].ToString();
                        Année.Text = dr[2].ToString();
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
                SqlCommand cmd = new SqlCommand("UPDATE Groupes SET CodeGroupe='" + CodeGroupe.Text + "',CodeFiliere='" + CodeFiliere.Text + "',Annee='" + Année.Text + "' WHERE CodeGroupe='" + textBox1.Text + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Groupe Modifié!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void ModifierGroupe_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet myDS = new DataSet();
                SqlDataAdapter da;
                da = new SqlDataAdapter("SELECT * FROM Filiere", cn);
                da.Fill(myDS);
                CodeFiliere.DataSource = myDS.Tables[0];
                CodeFiliere.ValueMember = "CodeFiliere";
                CodeFiliere.DisplayMember = "CodeFiliere";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }
    }
}
