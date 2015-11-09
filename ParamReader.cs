using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace DirtyThingsRemover
{
    //this class will find the kb noted in the database
    class ParamReader
    {
        private List<KBInfo> L_kbList=new List<KBInfo>();

        public ParamReader()
        {
            this.loadKB();
        }
        public void readKbDatabase()
        {

        }

        private void loadKB()
        {
            List<String> files = new List<string>();;
            //first we list the files available in the dir KB inside the database folder ("DB")
            //each file represents an update with some info inside it
            try
            {
                files = new List<String>(Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\DB\KB", "*.inf"));
            }
            catch (UnauthorizedAccessException UAE)
            {
                MessageBox.Show("This software don't have the right to acess his own database :" + UAE.Message);
            }
            catch (PathTooLongException PathEx)
            {
                MessageBox.Show("The path to the database seems to long  :" + PathEx.Message);
            }
            finally
            {
                foreach (String file in files)
                {
                    KBInfo tempKB;
                    tempKB = new KBInfo(file); //third param : return the substring minus the last 4 char (ie .inf) //,"",file.Substring(0,file.Length-4)
                    L_kbList.Add(tempKB);
                }
            }
        }

        /// <summary>
        /// Will reload all the kb available on the database
        /// </summary>
        public void reloadKB()
        {
            L_kbList.Clear();
            this.loadKB();
        }

    }
}
