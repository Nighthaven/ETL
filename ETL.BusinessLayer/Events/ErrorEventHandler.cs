using System;

namespace ETL.BusinessLayer.Events
{
    #region Delegates

    public delegate void ErrorEventHandler(object sender, ErrorEventArgs pEventArgs);

    #endregion

    #region Event Arguments

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    #endregion
}
