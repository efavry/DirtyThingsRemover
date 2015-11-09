using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DirtyThingsRemover
{

    //this class provide a simple way to call script or command
    class ProcessCaller
    {
        public DtrForm ui;
        public ProcessCaller(DtrForm ui)
        {
            this.ui = ui;
        }

        /// <summary>
        /// Call classical command line with a script given to him
        /// usage : test.bat if in same folder full path otherwise
        /// </summary>
        /// <param name="path">the path to the script to execute</param>
        public void callCmdByScript(String path)
        {
            Process process = Process.Start("cmd.exe", "/c" + path);
            process.WaitForExit();
            process.Close();
            return;
        }


        /// <summary>
        /// Call classical command line with an argument in parameter
        /// </summary>
        /// <param name="path">the argument given to cmd</param>
        public void callCmdByCommand(String command)
        {
            Process process = Process.Start("cmd.exe", command);
            process.WaitForExit();
            process.Close();
            return;
        }

        /// <summary>
        /// Launch the powershell script in an independent process 
        /// and not inside the soft with a script
        /// usage : .\test.bat if in same folder full path otherwise
        /// </summary>
        /// <param name="path">the path to the script to execute</param>
        public void callPowerShellByScript(String path)
        {
            this.callCmdByCommand("/k powershell -executionpolicy unrestricted " + path);  //replace by 
            //solution for the policy from http://stackoverflow.com/questions/13420799/enabling-execution-policy-for-powershell-from-c-sharp
            return;
        }

        /// <summary>
        /// Launch the powershell script in an independent process 
        /// and not inside the soft with a command
        /// </summary>
        /// <param name="path">the command to execute</param>
        public void callPowerShellByCommand(String command)
        {
            Process process = Process.Start("powershell.exe", command + Environment.NewLine + "pause");
            process.WaitForExit();
            process.Close();
            return;
        }
    }
}
