using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TD_Stagiaires
{
    public partial class Ajout_stagiaire : Form
    {
        public Ajout_stagiaire()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        DataSet myDS = new DataSet();
        SqlDataAdapter da;
        private void Ajout_stagiaire_Load(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM Groupes", cn);
                da.Fill(myDS);
                comboBox1.DataSource = myDS.Tables[0];
                comboBox1.ValueMember = "CodeGroupe";
                comboBox1.DisplayMember = "CodeGroupe";
            }
            catch (Exception ex) {
                MessageBox.Show("Erreur: "+ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Stagiaire VALUES('" + NumCEF.Text + "','" + NumCIN.Text + "','" + Nom.Text + "','" + Prenom.Text + "','" + NomArb.Text + "','" + PrenomArb.Text + "','" + dateNaissance.Value.ToShortDateString() + "','" + LieuNaissance.Text + "','" + Adresse.Text + "','" + CodePostal.Text + "','" + Ville.Text + "','" + Telephone.Text + "','" + comboBox1.SelectedValue + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Stagiaire Ajouté!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
