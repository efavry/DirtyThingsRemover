using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DirtyThingsRemover
{
    class KBInfo
    {
        public Int64 number { get; private set; }
        public String description { get; private set; }
        public String title { get; private set; }

        /// <summary>
        /// Construct a KBInfo object from usual parameter
        /// </summary>
        /// <param name="number">The Kb number (found in KNXXXXXXX)</param>
        /// <param name="description">The description given by the db can differ from the official</param>
        /// <param name="title">the official title of the KB</param>
        public KBInfo(Int64 number, String description, String title)
        {
            this.number = number;
            this.description = description;
            this.title = title;
        }

        /// <summary>
        /// Construct a KBInfo object from a file in the db
        /// </summary>
        /// <param name="path">the path to a file in the db/param>
        public KBInfo(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    decomposeNumber(sr.ReadLine());
                    decomposeDescription(sr.ReadLine());
                    decomposeTitle(sr.ReadLine());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The File : \n" + path + " was not read\nThe message was :\n" + e.Message);
            }
        }

        /// <summary>
        /// Read the first line of the file, if it is effectivly the correct line assign it to the value, exception otherwise
        /// </summary>
        /// <param name="toDec">string to decode</param>
        private void decomposeNumber(String toDec)
        {
            //TODO
            if (toDec.StartsWith("number=", StringComparison.InvariantCultureIgnoreCase))
            {
                toDec = toDec.Substring(7);
                MessageBox.Show(toDec);
                this.number = Int64.Parse(toDec);
            }
            else
                throw new Exception("Bad KB NUmber was read \nEither the markup is bad or the file is not in correct order");
        }


        /// <summary>
        /// Read the first line of the file, if it is effectivly the correct line assign it to the value, exception otherwise
        /// </summary>
        /// <param name="toDec">string to decode</param>
        private void decomposeDescription(String toDec)
        {
            //TODO
            if(toDec.StartsWith("description=",StringComparison.InvariantCultureIgnoreCase))
            {
                toDec = toDec.Substring(12);
                this.description = toDec;
            }
            else
                throw new Exception("Bad Description was read \nEither the markup is bad or the file is not in correct order");
        }

        /// <summary>
        /// Read the first line of the file, if it is effectivly the correct line assign it to the value, exception otherwise
        /// </summary>
        /// <param name="toDec">string to decode</param>
        private void decomposeTitle(String toDec)
        {
            //TODO
            if (toDec.StartsWith("title=", StringComparison.InvariantCultureIgnoreCase))
            {
                toDec = toDec.Substring(6);
                this.title = toDec;
            }
            else
                throw new Exception("Bad KB Title was read \nEither the markup is bad or the file is not in correct order");
        }
    }
}
