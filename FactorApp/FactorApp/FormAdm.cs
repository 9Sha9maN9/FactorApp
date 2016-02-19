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
        public FormAdm()
        {
            InitializeComponent();
            xWorker = new UsersBaseClass("D:\\new.xml");
            FillUserBase();
            usersGrid.DataSource = userBase;
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
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            switch((string)(sender as ToolStripButton).Tag)
            {
                case "Add":
                    {
                        usersGrid.Visible = false;
                    } break;
                case "Edit":
                    {
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

    }
}
