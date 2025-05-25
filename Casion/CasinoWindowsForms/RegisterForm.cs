using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoWindowsForms
{
    public partial class RegisterForm : Form
    {
        public string UserName { get; set; }
        public RegisterForm()
        {
            InitializeComponent();
            tbxUsername.Text = UserName;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private bool IsOldEnough(DateTime birthDate)
        {
             if(birthDate.Year - 18 <= DateTime.Today.Year)
             {
                return true;
             }
            return false;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            /*Domain.Player player = new Domain.Player()
            {
                UserName = tbxUsername.Text,
                Password = tbxPassword.Text
            };
            if(IsOldEnough(dateTimePicker1.Value))
            {
                UserClient client = new UserClient();
                List<Domain.Player> playerList = new List<Domain.Player>();
                playerList = client.LoadPersons();
                if (playerList.Contains(player))
                {
                    MessageBox.Show("User already Exists!");
                    return;
                }
                else
                {
                    UserName = tbxUsername.Text;
                    playerList.Add(player);
                    client.SavePersons(playerList);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }*/
            UserClient client = new UserClient();
            bool registrationSuccess = client.Register(tbxUsername.Text, tbxPassword.Text);

            if (registrationSuccess)
            {
                MessageBox.Show("Registrierung erfolgreich!");
                this.DialogResult = DialogResult.OK;
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registrierung fehlgeschlagen!");
            }

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
