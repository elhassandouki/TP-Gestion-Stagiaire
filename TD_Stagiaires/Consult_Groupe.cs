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
    public partial class Consult_Groupe : Form
    {
        public Consult_Groupe()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"server=.\SQLExpress; database=Etudiant; integrated security=true;");
        DataSet myDS = new DataSet();
        SqlDataAdapter da;
        private void Consult_Groupe_Load(object sender, EventArgs e)
        {
            Charger();
        }

        private void Charger()
        {
            try
            {
                cn.Open();
                da = new SqlDataAdapter("SELECT * FROM Groupes", cn);
                da.Fill(myDS);
                dataGridView1.DataSource = myDS.Tables[0];
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Groupes WHERE CodeGroupe='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Groupe Supprimé!");
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

        private void button4_Click(object sender, EventArgs e)
        {
            AjouterGroupe ajg = new AjouterGroupe();
            ajg.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            while (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(0);
            }

            Charger();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifierGroupe mdf = new ModifierGroupe();
            mdf.ShowDialog();
        }
    }
}
