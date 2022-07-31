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
    public partial class AjouterGroupe : Form
    {
        public AjouterGroupe()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        DataSet myDS = new DataSet();
        SqlDataAdapter da;
        private void AjouterGroupe_Load(object sender, EventArgs e)
        {
            try
            {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Groupes VALUES('" + CodeGroupe.Text + "','" + CodeFiliere.SelectedValue + "','" + Année.Text + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Groupe Ajouté!");
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
