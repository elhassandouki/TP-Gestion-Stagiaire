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
    public partial class AjouterFiliere : Form
    {
        public AjouterFiliere()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        DataSet myDS = new DataSet();
        SqlDataAdapter da;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Filiere VALUES('" + CodeFiliere.Text + "','" + Filiere.Text + "','" + Niveau.Text + "','" + Secteur.Text + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Filiere Ajouté!");
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

        private void AjouterFiliere_Load(object sender, EventArgs e)
        {

        }
    }
}
