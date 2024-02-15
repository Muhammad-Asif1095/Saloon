using System;
using System.IO;

namespace Saloon.Common
{
    public class MakeLog
    {
        private string sLogFormat;
        private string sErrorTime;

        public MakeLog()
        {
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
        }

        public void ErrorLog(string rootPath, string sPathName, string sErrMsg)
        {
            string path = rootPath + "/Logs/" + sErrorTime + "/" + sPathName;
            CreatDirectory(path);
            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(sLogFormat + sErrMsg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
            }

        }
        private void CreatDirectory(string path)
        {
            var newPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
        }
    }
}
