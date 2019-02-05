namespace nikolay_tashev_employess
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.prgFileImport = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.clmEmployeesGridEmployeeID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeesGridEmployeeID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeesGridProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeesGridDaysWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAllData = new System.Windows.Forms.TabPage();
            this.gridAllData = new System.Windows.Forms.DataGridView();
            this.lblLongestWorkingPair = new System.Windows.Forms.Label();
            this.clmAllDataGridEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAllDataGridProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAllDataGridDateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAllDataGridDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.tabPageAllData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 25);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(422, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(440, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(47, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // prgFileImport
            // 
            this.prgFileImport.Location = new System.Drawing.Point(12, 51);
            this.prgFileImport.Name = "prgFileImport";
            this.prgFileImport.Size = new System.Drawing.Size(475, 23);
            this.prgFileImport.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Imported File";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageEmployees);
            this.tabControl1.Controls.Add(this.tabPageAllData);
            this.tabControl1.Location = new System.Drawing.Point(15, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 338);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.gridEmployees);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(468, 312);
            this.tabPageEmployees.TabIndex = 0;
            this.tabPageEmployees.Text = "Employees";
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmployeesGridEmployeeID1,
            this.clmEmployeesGridEmployeeID2,
            this.clmEmployeesGridProjectID,
            this.clmEmployeesGridDaysWorked});
            this.gridEmployees.Location = new System.Drawing.Point(1, 0);
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.ReadOnly = true;
            this.gridEmployees.Size = new System.Drawing.Size(467, 312);
            this.gridEmployees.TabIndex = 7;
            // 
            // clmEmployeesGridEmployeeID1
            // 
            this.clmEmployeesGridEmployeeID1.HeaderText = "Employee ID #1";
            this.clmEmployeesGridEmployeeID1.Name = "clmEmployeesGridEmployeeID1";
            this.clmEmployeesGridEmployeeID1.ReadOnly = true;
            this.clmEmployeesGridEmployeeID1.Width = 110;
            // 
            // clmEmployeesGridEmployeeID2
            // 
            this.clmEmployeesGridEmployeeID2.HeaderText = "Employee ID #2";
            this.clmEmployeesGridEmployeeID2.Name = "clmEmployeesGridEmployeeID2";
            this.clmEmployeesGridEmployeeID2.ReadOnly = true;
            this.clmEmployeesGridEmployeeID2.Width = 110;
            // 
            // clmEmployeesGridProjectID
            // 
            this.clmEmployeesGridProjectID.HeaderText = "Project ID";
            this.clmEmployeesGridProjectID.Name = "clmEmployeesGridProjectID";
            this.clmEmployeesGridProjectID.ReadOnly = true;
            // 
            // clmEmployeesGridDaysWorked
            // 
            this.clmEmployeesGridDaysWorked.HeaderText = "Days Worked";
            this.clmEmployeesGridDaysWorked.Name = "clmEmployeesGridDaysWorked";
            this.clmEmployeesGridDaysWorked.ReadOnly = true;
            // 
            // tabPageAllData
            // 
            this.tabPageAllData.Controls.Add(this.gridAllData);
            this.tabPageAllData.Location = new System.Drawing.Point(4, 22);
            this.tabPageAllData.Name = "tabPageAllData";
            this.tabPageAllData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllData.Size = new System.Drawing.Size(468, 312);
            this.tabPageAllData.TabIndex = 1;
            this.tabPageAllData.Text = "All Data";
            this.tabPageAllData.UseVisualStyleBackColor = true;
            // 
            // gridAllData
            // 
            this.gridAllData.AllowUserToAddRows = false;
            this.gridAllData.AllowUserToDeleteRows = false;
            this.gridAllData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAllData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAllDataGridEmployeeID,
            this.clmAllDataGridProjectID,
            this.clmAllDataGridDateFrom,
            this.clmAllDataGridDateTo});
            this.gridAllData.Location = new System.Drawing.Point(0, 0);
            this.gridAllData.Name = "gridAllData";
            this.gridAllData.ReadOnly = true;
            this.gridAllData.Size = new System.Drawing.Size(467, 312);
            this.gridAllData.TabIndex = 6;
            // 
            // lblLongestWorkingPair
            // 
            this.lblLongestWorkingPair.AutoSize = true;
            this.lblLongestWorkingPair.Location = new System.Drawing.Point(12, 77);
            this.lblLongestWorkingPair.Name = "lblLongestWorkingPair";
            this.lblLongestWorkingPair.Size = new System.Drawing.Size(143, 13);
            this.lblLongestWorkingPair.TabIndex = 4;
            this.lblLongestWorkingPair.Text = "Longest project working pair:";
            // 
            // clmAllDataGridEmployeeID
            // 
            this.clmAllDataGridEmployeeID.HeaderText = "Employee ID";
            this.clmAllDataGridEmployeeID.Name = "clmAllDataGridEmployeeID";
            this.clmAllDataGridEmployeeID.ReadOnly = true;
            // 
            // clmAllDataGridProjectID
            // 
            this.clmAllDataGridProjectID.HeaderText = "Project ID";
            this.clmAllDataGridProjectID.Name = "clmAllDataGridProjectID";
            this.clmAllDataGridProjectID.ReadOnly = true;
            // 
            // clmAllDataGridDateFrom
            // 
            dataGridViewCellStyle1.Format = "MM.dd.yyyy г.";
            dataGridViewCellStyle1.NullValue = null;
            this.clmAllDataGridDateFrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmAllDataGridDateFrom.HeaderText = "From Date ";
            this.clmAllDataGridDateFrom.Name = "clmAllDataGridDateFrom";
            this.clmAllDataGridDateFrom.ReadOnly = true;
            // 
            // clmAllDataGridDateTo
            // 
            dataGridViewCellStyle2.Format = "MM.dd.yyyy г.";
            dataGridViewCellStyle2.NullValue = null;
            this.clmAllDataGridDateTo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmAllDataGridDateTo.HeaderText = "To Date";
            this.clmAllDataGridDateTo.Name = "clmAllDataGridDateTo";
            this.clmAllDataGridDateTo.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLongestWorkingPair);
            this.Controls.Add(this.prgFileImport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFilePath);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.tabPageAllData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar prgFileImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.TabPage tabPageAllData;
        private System.Windows.Forms.DataGridView gridAllData;
        private System.Windows.Forms.DataGridView gridEmployees;
        private System.Windows.Forms.Label lblLongestWorkingPair;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeesGridEmployeeID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeesGridEmployeeID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeesGridProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeesGridDaysWorked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAllDataGridEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAllDataGridProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAllDataGridDateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAllDataGridDateTo;
    }
}

