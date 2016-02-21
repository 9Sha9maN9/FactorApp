using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FactorApp.AuthorizationLogic;
using FactorApp.XML;

namespace FactorApp
{
    public partial class FormAdm : Form
    {
        private UsersBaseClass xWorker;
        private DataTable userBase;
        private string prewiousLogIn;
        private DataRow currentRow;
        public FormAdm()
        {
            InitializeComponent();
            xWorker = new UsersBaseClass("D:\\new.xml");
            xWorker.CryptoWorker.onCannotDecrypt += CryptoWorker_onCannotDecrypt;
            prewiousLogIn = "None";
            FillUserBase();
            usersGrid.DataSource = userBase;
            usersGrid.Location = new Point(12, 28);
            cboRights.DataSource = Enum.GetValues(typeof(RightsType));
        }

        private void CryptoWorker_onCannotDecrypt(Exception ex)
        {
            ex.Data.Clear();
            MessageBox.Show("Err");
        }

        private void FillUserBase()
        {
            userBase = new DataTable();
            userBase.Columns.Add("Логин");
            userBase.Columns.Add("Права доступа");
            foreach (User usr in xWorker.GetAllUsers())
            {
                userBase.Rows.Add(usr.LogIN, EnumConverter.EnumToString<RightsType>(usr.Rights));
            }
            currentRow = userBase.Rows[0];
            userBase.RowChanged += userBase_RowChanged;
        }

        void userBase_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            currentRow = e.Row;
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            switch((string)(sender as ToolStripButton).Tag)
            {
                case "Add":
                    {
                        admGroupBox.Visible = true;
                        usersGrid.Visible = false;
                    } break;
                case "Edit":
                    {
                        User tmp = xWorker.GetUserByLogin(currentRow[0].ToString());
                        if (tmp.LogIN != "None")
                        {
                            prewiousLogIn = tmp.LogIN;
                            txtLogin.Text = tmp.LogIN;
                            txtPassword.Text = tmp.Password;
                            admGroupBox.Visible = true;
                            usersGrid.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("empty");
                        }
                    } break;
                case "Delete":
                    {
                        DeleteUser();
                    }break;
                default:
                    {

                    }break;
            }
        }

        private void DeleteUser()
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            txtLogin.Text = string.Empty;
            txtPassword.Text = string.Empty;
            admGroupBox.Visible = false;
            usersGrid.Visible = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            xWorker.Add(txtLogin.Text, txtPassword.Text, (RightsType)cboRights.SelectedValue);
            userBase.Rows.Add(txtLogin.Text, EnumConverter.EnumToString<RightsType>((RightsType)cboRights.SelectedValue));
            buttonCancel.PerformClick();
        }


    }
}
