namespace FactorApp
{
    partial class FormAdm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdm));
            this.admToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.admGroupBox = new System.Windows.Forms.GroupBox();
            this.cboRights = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPswChange = new System.Windows.Forms.CheckBox();
            this.admToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.admGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // admToolStrip
            // 
            this.admToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete});
            this.admToolStrip.Location = new System.Drawing.Point(0, 0);
            this.admToolStrip.Name = "admToolStrip";
            this.admToolStrip.Size = new System.Drawing.Size(395, 25);
            this.admToolStrip.TabIndex = 0;
            this.admToolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Tag = "Add";
            this.toolStripButtonAdd.Text = "Добавить";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEdit.Tag = "Edit";
            this.toolStripButtonEdit.Text = "Редактировать";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Tag = "Delete";
            this.toolStripButtonDelete.Text = "Удалить";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // usersGrid
            // 
            this.usersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.usersGrid.Location = new System.Drawing.Point(12, 218);
            this.usersGrid.Name = "usersGrid";
            this.usersGrid.Size = new System.Drawing.Size(299, 171);
            this.usersGrid.TabIndex = 3;
            // 
            // admGroupBox
            // 
            this.admGroupBox.Controls.Add(this.checkBoxPswChange);
            this.admGroupBox.Controls.Add(this.cboRights);
            this.admGroupBox.Controls.Add(this.txtPassword);
            this.admGroupBox.Controls.Add(this.txtLogin);
            this.admGroupBox.Controls.Add(this.buttonCancel);
            this.admGroupBox.Controls.Add(this.buttonApply);
            this.admGroupBox.Controls.Add(this.label3);
            this.admGroupBox.Controls.Add(this.label2);
            this.admGroupBox.Controls.Add(this.label1);
            this.admGroupBox.Location = new System.Drawing.Point(12, 28);
            this.admGroupBox.Name = "admGroupBox";
            this.admGroupBox.Size = new System.Drawing.Size(371, 171);
            this.admGroupBox.TabIndex = 4;
            this.admGroupBox.TabStop = false;
            this.admGroupBox.Text = "Данные пользователя";
            this.admGroupBox.Visible = false;
            // 
            // cboRights
            // 
            this.cboRights.FormattingEnabled = true;
            this.cboRights.Location = new System.Drawing.Point(125, 104);
            this.cboRights.Name = "cboRights";
            this.cboRights.Size = new System.Drawing.Size(156, 21);
            this.cboRights.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(125, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(125, 28);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(156, 20);
            this.txtLogin.TabIndex = 13;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(206, 147);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Выход";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(125, 147);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 11;
            this.buttonApply.Text = "Сохранить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Права доступа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Праоль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Логин";
            // 
            // checkBoxPswChange
            // 
            this.checkBoxPswChange.AutoSize = true;
            this.checkBoxPswChange.Location = new System.Drawing.Point(288, 68);
            this.checkBoxPswChange.Name = "checkBoxPswChange";
            this.checkBoxPswChange.Size = new System.Drawing.Size(77, 17);
            this.checkBoxPswChange.TabIndex = 16;
            this.checkBoxPswChange.Text = "Изменить";
            this.checkBoxPswChange.UseVisualStyleBackColor = true;
            this.checkBoxPswChange.CheckedChanged += new System.EventHandler(this.checkBoxPswChange_CheckedChanged);
            // 
            // FormAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 230);
            this.Controls.Add(this.admGroupBox);
            this.Controls.Add(this.usersGrid);
            this.Controls.Add(this.admToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdm";
            this.Text = "Администрирование";
            this.admToolStrip.ResumeLayout(false);
            this.admToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();
            this.admGroupBox.ResumeLayout(false);
            this.admGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip admToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.GroupBox admGroupBox;
        private System.Windows.Forms.ComboBox cboRights;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPswChange;
    }
}