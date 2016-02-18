using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FactorApp.AuthorizationLogic;

namespace FactorApp
{
    public partial class frmAuthorization : Form
    {
        private Authorization authorizeWorker;

        public frmAuthorization()
        {
            InitializeComponent();
            authorizeWorker = new Authorization("D:\\new.xml");
        }

        private void frmAuthorization_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    {
                        this.Close();
                    }break;
                case (char)Keys.Enter:
                    {
                        if ((sender as TextBox).Name == this.txtPassword.Name)
                        {
                            this.btnLogIn.PerformClick();
                        }
                    }break;
                default:
                    {
                        // На случай необходиомсти выполнения заглушки
                    } break;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Запуск проверки авторизации
            if (checkLogIn() && checkPassword())
            {
                switch (authorizeWorker.CheckPassword(this.txtLogIn.Text, this.txtPassword.Text))
                {
                    case LogInErrorType.Passed:
                        {
                            Form2 mainWindow = new Form2(authorizeWorker.UserRights);
                            this.Hide();
                            mainWindow.ShowDialog();
                            this.Close();
                        } break;
                    case LogInErrorType.WrongLogIn:
                        {
                            MessageBox.Show("Введен неверный логин.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtLogIn.Focus();
                        } break;
                    case LogInErrorType.WrongPassword:
                        {
                            MessageBox.Show("Введен неверный пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtPassword.Focus();
                        } break;
                    default:
                        {
                            MessageBox.Show("Ошибка авторизации.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }break;
                }
                if (authorizeWorker.Attepmpts == 3)
                {
                    MessageBox.Show("Превышено число попыток входа!\nПрограмма будет закрыта.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkLogIn()
        {
            bool result = false;
            if (string.IsNullOrEmpty(this.txtLogIn.Text))
            {
                MessageBox.Show("Не введен логин.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtLogIn.Focus();
            }
            else 
            {
                result = true;
            }
            return result;
        }

        private bool checkPassword()
        {
            bool result = false;
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Не введен пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPassword.Focus();
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
