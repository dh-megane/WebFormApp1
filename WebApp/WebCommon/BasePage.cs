using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCommon;

namespace WebCommon
{
    public class BasePage : System.Web.UI.Page
    {

        protected void CreateConfirmReport(BasePrint print)
        {
            print.Print();

            print.FileDownload(Response);
        }
    }
}
