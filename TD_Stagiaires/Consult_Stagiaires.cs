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
using System.Data;

namespace TD_Stagiaires
{
    public partial class Consult_Stagiaires : Form
    {
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        
        public Consult_Stagiaires()
        {
            InitializeComponent();
        }
        DataSet myDS = new DataSet();
        SqlDataAdapter da;
       

        private void Consult_Stagiaires_Load(object sender, EventArgs e)
        {
            Charger();
        }

        private void Charger()
        {
            try
            {
                cn.Open();
                da = new SqlDataAdapter("SELECT * FROM Stagiaire", cn);
                da.Fill(myDS);
                dataGridView1.DataSource = myDS.Tables[0];
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ajout_stagiaire ast = new Ajout_stagiaire();
            ast.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Stagiaire WHERE NumCEF='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Stagiaire Supprimé!");
                    while (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                    }

                    Charger();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modifier_Stagiaire mdf = new Modifier_Stagiaire();
            mdf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                 while (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(0);
            }

            Charger();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
