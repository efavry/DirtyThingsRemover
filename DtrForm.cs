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
            this.O_processCaller= new ProcessCaller(this);
            this.O_paramReader = new ParamReader();
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
    }
}
