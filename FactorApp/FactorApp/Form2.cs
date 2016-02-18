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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(RightsType rights): this()
        {
            switch (rights)
            {
                case RightsType.Administration:
                    {
                        this.mnuAdmin.Visible = true;
                    }break;
            }
        }

        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            FormAdm adm = new FormAdm();
            adm.ShowDialog();
        }
    }
}
