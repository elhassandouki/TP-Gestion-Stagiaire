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
    public partial class Modifier_Stagiaire : Form
    {
        public Modifier_Stagiaire()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Stagiaire Where NumCEF='" + textBox1.Text + "'", cn);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Aucun résultat!");
                }
                else
                {
                    NumCEF.Enabled = true;
                    NumCIN.Enabled = true;
                    Nom.Enabled = true;
                    Prenom.Enabled = true;
                    NomArb.Enabled = true;
                    PrenomArb.Enabled = true;
                    dateNaissance.Enabled = true;
                    LieuNaissance.Enabled = true;
                    Adresse.Enabled = true;
                    CodePostal.Enabled = true;
                    Ville.Enabled = true;
                    Telephone.Enabled = true;
                    comboBox1.Enabled = true;
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Stagiaire Where NumCEF='" + textBox1.Text + "'", cn);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        NumCEF.Text = dr[0].ToString();
                        NumCIN.Text = dr[1].ToString();
                        Nom.Text = dr[2].ToString();
                        Prenom.Text = dr[3].ToString();
                        NomArb.Text = dr[4].ToString();
                        PrenomArb.Text = dr[5].ToString();
                        dateNaissance.Value = (DateTime)dr[6];
                        LieuNaissance.Text = dr[7].ToString();
                        Adresse.Text = dr[8].ToString();
                        CodePostal.Text = dr[9].ToString();
                        Ville.Text = dr[10].ToString();
                        Telephone.Text = dr[11].ToString();
                        comboBox1.Text = dr[12].ToString();
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
                SqlCommand cmd = new SqlCommand("UPDATE Stagiaire SET NumCEF='" + NumCEF.Text + "',NumCIN='" + NumCIN.Text + "',Nom='" + Nom.Text + "',Prenom='" + Prenom.Text + "',NomArb='" + NomArb.Text + "',PrenomArb='" + PrenomArb.Text + "',DateNaissance='" + dateNaissance.Value.ToShortDateString() + "',LieuNaissance='" + LieuNaissance.Text + "',Adresse='" + Adresse.Text + "',CodePostal='" + CodePostal.Text + "',Ville='" + Ville.Text + "',Tel='" + Telephone.Text + "',CodeGroupe='" + comboBox1.SelectedValue + "' WHERE NumCEF='" + textBox1.Text + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Stagiaire Modifié!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void Modifier_Stagiaire_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet myDS = new DataSet();
                SqlDataAdapter da;
                da = new SqlDataAdapter("SELECT * FROM Groupes", cn);
                da.Fill(myDS);
                comboBox1.DataSource = myDS.Tables[0];
                comboBox1.ValueMember = "CodeGroupe";
                comboBox1.DisplayMember = "CodeGroupe";
                NumCEF.Enabled = false;
                NumCIN.Enabled = false;
                Nom.Enabled = false;
                Prenom.Enabled = false;
                NomArb.Enabled = false;
                PrenomArb.Enabled = false;
                dateNaissance.Enabled = false;
                LieuNaissance.Enabled = false;
                Adresse.Enabled = false;
                CodePostal.Enabled = false;
                Ville.Enabled = false;
                Telephone.Enabled = false;
                comboBox1.Enabled = false;
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
