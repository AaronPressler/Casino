using System;
using System.Windows.Forms;
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


            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            UserClient client = new UserClient();
            bool loginSuccess = client.Login(username, password);
            
            if (loginSuccess)
            {
                WelcomeForm wf = new WelcomeForm();
                wf.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Benutzername oder Passwort ist falsch.");
            }
            
        }

    }
}

