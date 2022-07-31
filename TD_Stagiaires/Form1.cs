using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TD_Stagiaires
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Consult_Stagiaires))
                {
                    form.Activate();
                    DialogResult = MessageBox.Show("Une instance de cette fenêtre est déja en cours d'ouverture!\nVoulez vous fermer la fenêrtre ouverte?", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    return;
                }
            }
            Consult_Stagiaires frm = new Consult_Stagiaires();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consulterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Consult_Groupe))
                {
                    form.Activate();
                    DialogResult = MessageBox.Show("Une instance de cette fenêtre est déja en cours d'ouverture!\nVoulez vous fermer la fenêrtre ouverte?", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    return;
                }
            }
            Consult_Groupe frm = new Consult_Groupe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consulterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Consult_Filiere))
                {
                    form.Activate();
                    DialogResult = MessageBox.Show("Une instance de cette fenêtre est déja en cours d'ouverture!\nVoulez vous fermer la fenêrtre ouverte?", "Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    return;
                }
            }
            Consult_Filiere frm = new Consult_Filiere();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
