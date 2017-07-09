using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessLayer.Events
{
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs pEventArgs);

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
