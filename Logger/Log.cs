using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    /*
        Sealed restricts the inharitance     
    */
    public sealed class Log : ILog
    {
        public static int counter = 0;
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        private static readonly object obj = new object();

        /*
         Private constructor ensure that object is not
         instantiated other than with in the class itself
         */
        private Log()
        {
        }

        /*
         Public property is used to return only one instance of the class
         leceraging on the private property
        */
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.Day);
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
