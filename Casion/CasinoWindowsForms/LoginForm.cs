using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Web;
namespace CasinoWindowsForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm rf = new RegisterForm();
            if (rf.ShowDialog() == DialogResult.OK)
            {
                string UserName = rf.UserName;
                tbxUsername.Text = UserName;
            }

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Domain.Player player = new Domain.Player()
            {
                UserName = tbxUsername.Text,
                Password = tbxPassword.Text
            };
            
            
            UserClient client = new UserClient();
            List<Domain.Player> playerList = client.LoadPersons();
            if(playerList.Contains(player))
            {
                WelcomeForm wf = new WelcomeForm();
                this.Close();
            }
            else
            {
                MessageBox.Show("User Does NOT Exist");
                return;
            }
            
        }
    }
}
