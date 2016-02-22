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
        private bool isNew;
        private string prevoiusLogin;

        public FormAdm()
        {
            InitializeComponent();
            xWorker = new UsersBaseClass("D:\\new.xml");
            xWorker.CryptoWorker.onCannotDecrypt += CryptoWorker_onCannotDecrypt;
            FillUserBase();
            SetUsersGrid();
            cboRights.DataSource = EnvelopRightsType.CreateListOfRightType(Enum.GetValues(typeof(RightsType)));
            cboRights.DisplayMember = "Name";
            cboRights.ValueMember = "Right";
        }

        private void CryptoWorker_onCannotDecrypt(Exception ex)
        {
            ex.Data.Clear();
            MessageBox.Show("Err");
        }

        private void FillUserBase()
        {
            userBase = new DataTable();
            userBase.Columns.Add("Ид");
            userBase.Columns.Add("Логин");
            userBase.Columns.Add("Права доступа");
            userBase.Columns.Add("Password");
            userBase.Columns.Add("Rights");
            foreach (User usr in xWorker.GetAllUsers())
            {
                userBase.Rows.Add(usr.ID,usr.LogIN, EnumConverter.EnumToString<RightsType>(usr.Rights),usr.Password,usr.Rights);
            }
        }

        private void SetUsersGrid()
        {
            usersGrid.DataSource = userBase;
            for (int i = 3; i < userBase.Columns.Count; i++)
            {
                usersGrid.Columns[i].Visible = false;
            }
            usersGrid.Location = new Point(12, 28);
        }


        private void toolStripButton_Click(object sender, EventArgs e)
        {
            switch((string)(sender as ToolStripButton).Tag)
            {
                case "Add":
                    {
                        isNew = true;
                        admGroupBox.Visible = true;
                        usersGrid.Visible = false;
                    } break;
                case "Edit":
                    {
                        isNew = false;
                        prevoiusLogin = (string)usersGrid.CurrentRow.Cells[1].Value;
                        txtLogin.Text =(string)usersGrid.CurrentRow.Cells[1].Value;
                        txtPassword.Text = (string)usersGrid.CurrentRow.Cells[3].Value;
                        cboRights.SelectedValue = (RightsType)Enum.Parse(typeof(RightsType),usersGrid.CurrentRow.Cells[4].Value.ToString());
                        admGroupBox.Visible = true;
                        usersGrid.Visible = false;
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
            if (isNew)
            {
                AddNew();
            }
            else
            {
                Edit();
            }
            
        }

        private void AddNew()
        {
            int id;
            if (!xWorker.IsValidLogIn(txtLogin.Text))
            {
                id = xWorker.GetLastId();
                xWorker.Add(txtLogin.Text, txtPassword.Text, (RightsType)cboRights.SelectedValue);
                userBase.Rows.Add(id, txtLogin.Text, EnumConverter.EnumToString<RightsType>((RightsType)cboRights.SelectedValue));
                buttonCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Такой логин уже имеется!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Edit()
        {
            int id = int.Parse(usersGrid.CurrentRow.Cells[0].Value.ToString());
            if (prevoiusLogin == txtLogin.Text)
            {
                xWorker.Edit(id, txtLogin.Text, txtPassword.Text, (RightsType)cboRights.SelectedValue);
            }
            else
            {
                if (!xWorker.IsValidLogIn(txtLogin.Text))
                {
                    xWorker.Edit(id, txtLogin.Text, txtPassword.Text, (RightsType)cboRights.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Такой логин уже имеется!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            DataRow[] tmp = userBase.Select("Ид=" + id.ToString());
            tmp[0]["Логин"] = txtLogin.Text;
            tmp[0]["Права доступа"] = EnumConverter.EnumToString<RightsType>((RightsType)cboRights.SelectedValue);
            tmp[0]["Password"] = "***";
            tmp[0]["Rights"] = cboRights.SelectedValue;
            buttonCancel.PerformClick();
        }

    }
}
