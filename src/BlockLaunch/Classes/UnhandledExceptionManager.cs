using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebKit.Properties;

namespace BlockLaunch.Classes
{
    public class UnhandledExceptionManager
    {

        public static ExceptionBase.ExceptionBase Tracker = new ExceptionBase.ExceptionBase("http://kaskadekingde.cloudza.org/software/blocklaunch/exceptions/api/addException", 1, Application.ProductVersion, Properties.Resources.MainIcon);

        public UnhandledExceptionManager()
        {
            throw new NotSupportedException("You can't create a new instance of UnhandledExceptionManager");
        }

    }
}
