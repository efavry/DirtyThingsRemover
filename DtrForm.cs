using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirtyThingsRemover
{
    public partial class DtrForm : Form
    {
        ProcessCaller O_processCaller;
        ParamReader O_paramReader;
        public DtrForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.O_processCaller= new ProcessCaller(/*this*/);
            this.O_paramReader = new ParamReader();
            this.O_paramReader.readKbDatabase();
            this.dataGridView1.MultiSelect = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;





            DataGridViewTextBoxColumn explainColumn = new DataGridViewTextBoxColumn();
            explainColumn.HeaderText = "Info";
            //explainColumn.ReadOnly = true;
            explainColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            explainColumn.FillWeight = 75;
            this.dataGridView1.Columns.Add(explainColumn);

            this.dataGridView1.Rows.Add("First Line" + "\n" + "AAAA");

            DataGridViewCheckBoxColumn chkToFix = new DataGridViewCheckBoxColumn();
            chkToFix.HeaderText = "Fix ?";
            chkToFix.Name = "chk";
            chkToFix.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            chkToFix.FillWeight = 5;
            chkToFix.ReadOnly = false;
            this.dataGridView1.Columns.Insert(0, chkToFix);
            this.dataGridView1.Rows[0].Cells[0].Value = true;
        }

        public void writeLineInUI(String toWrite)
        {
            consoleOut.Text = consoleOut.Text + Environment.NewLine + toWrite;
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            //KBInfo kbi = new KBInfo(16, "lol", "lol");
            //Console.WriteLine(kbi.description);
            //this.writeLineInUI(kbi.description);
            //O_processCaller.callPowerShellByCommand("pause");/*Get-Process*/ //work
            //O_processCaller.callCmdByScript("test.bat");
            //O_processCaller.callPowerShellByScript(".\\test.ps1");
        }

        /// <summary>
        /// Rather obvious : quit the app
        /// </summary>
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This fuction will take in charge the behaviour of the check box in the datagridview
        /// This function is shameful for me but i was not able to find a better way for the checkbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((Boolean)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                else
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }
    }
}
