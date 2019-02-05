using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nikolay_tashev_employess.BussinessLogic;
using nikolay_tashev_employess.Models;
using nikolay_tashev_employess.Base.LogSystem;

namespace nikolay_tashev_employess
{
    public partial class MainForm : Form
    {
        private List<Employee> employees = null;
        private List<EmployeesWorkingPair> employeesWorkingPair = null;
        private static readonly string longestWorkingPairText = "Longest project working pair:";

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Employees Form";
            this.MaximizeBox = false;

            this.txtFilePath.ReadOnly = true;
            this.btnImport.Text = "Import";

            SetEmployeesWorkingPairLable();

            InitializeProgressBar();
            InitializeAllEmployeesDataGrid();
            InitializeEmployeesWorkingPairsGrid();
        }

        /// <summary> Initializes the grid with all employees data </summary>
        void InitializeAllEmployeesDataGrid()
        {
            gridAllData.AutoGenerateColumns = false;
            clmAllDataGridEmployeeID.DataPropertyName = "EmployeeID";
            clmAllDataGridProjectID.DataPropertyName = "ProjectID";
            clmAllDataGridDateFrom.DataPropertyName = "DateFrom";
            clmAllDataGridDateTo.DataPropertyName = "DateTo";
        }

        /// <summary> Initializes the grid with working days data </summary>
        void InitializeEmployeesWorkingPairsGrid()
        {
            gridEmployees.AutoGenerateColumns = false;
            clmEmployeesGridEmployeeID1.DataPropertyName = "FirstEmployeeID";
            clmEmployeesGridEmployeeID2.DataPropertyName = "SecondEmployeeID";
            clmEmployeesGridProjectID.DataPropertyName = "ProjectID";
            clmEmployeesGridDaysWorked.DataPropertyName = "DaysWorked";
        }

        void InitializeProgressBar(bool running = false)
        {
            if (running)
            {
                this.prgFileImport.Style = ProgressBarStyle.Marquee;
                this.prgFileImport.MarqueeAnimationSpeed = 50;
            }
            else
            {
                this.prgFileImport.MarqueeAnimationSpeed = 0;
                this.prgFileImport.Style = ProgressBarStyle.Blocks;
                this.prgFileImport.Value = this.prgFileImport.Minimum;
            }
        }

        /// <summary> Initializes the source for the grid with all employees data </summary>
        private void SetEmployeesGrid()
        {
            gridAllData.DataSource = employees;
            gridAllData.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            gridAllData.Invalidate();
        }

        /// <summary> Initializes the source for the grid with working days </summary>
        private void SetEmployeesWorkingPairGrid()
        {
            gridEmployees.DataSource = employeesWorkingPair;
            gridEmployees.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            gridEmployees.Invalidate();
        }

        /// <summary> Sets the text of the summary label </summary>
        private void SetEmployeesWorkingPairLable()
        {
            String labelText = longestWorkingPairText;
            if (employeesWorkingPair != null && employeesWorkingPair.Count > 0)
            {
                var mostWoringDaysRecord = employeesWorkingPair[0];
                labelText += String.Format(" Employee IDs {0} and {1} at Project ID {2} - {3} working days", mostWoringDaysRecord.FirstEmployeeID, mostWoringDaysRecord.SecondEmployeeID, mostWoringDaysRecord.ProjectID, mostWoringDaysRecord.DaysWorked);
            }

            lblLongestWorkingPair.Text = labelText;
        }

        /// <summary> Button Import handle </summary>
        private async void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            if (!openFileDialog.CheckFileExists)
            {
                MessageBox.Show("The specified file does not exists.");
                return;
            }

            txtFilePath.Text = openFileDialog.FileName;
            btnImport.Enabled = false;

            employees = null;
            employeesWorkingPair = null;

            SetEmployeesWorkingPairLable();
            SetEmployeesGrid();
            SetEmployeesWorkingPairGrid();

            try
            {
                InitializeProgressBar(true);

                employees = await EmployeeHelper.LoadEmployeesFromFileAsync(openFileDialog.FileName);
                employeesWorkingPair = await EmployeeHelper.LoadEmployeesWorkingPairAsync(employees);
                employeesWorkingPair.Sort((record1, record2) => record2.DaysWorked.CompareTo(record1.DaysWorked));

                SetEmployeesWorkingPairLable();
                SetEmployeesWorkingPairGrid();
                SetEmployeesGrid();
            }
            catch (nikolay_tashev_employess.Base.Common.Exceptions.BaseSystemException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch(Exception exception)
            {
                FileLogger.Instance.LogException(exception);
                MessageBox.Show(exception.Message);
            }
            finally
            {
                btnImport.Enabled = true;
                InitializeProgressBar();
            }
        }
    }
}
