using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.BL;
using WindowsFormsApp4.DL;

namespace WindowsFormsApp4
{
    public partial class EditUserForm : Form
    {
        private MUser previous;
        public EditUserForm(MUser previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser updated = new MUser(txtUsername.Text, txtPassword.Text, txtRole.Text);
            MUserDL.EditUserFromList(previous, updated);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtUsername.Text = previous.UserName;
            txtPassword.Text = previous.UserPassword;
            txtRole.Text = previous.UserRole;
        }

    }
}
