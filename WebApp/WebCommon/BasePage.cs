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

        protected string ExecPrint(BasePrint clsPrint)
        {
            return clsPrint.Print();
        }

        protected void FileDownload(string fileName)
        {
            // Response情報クリア
            Response.ClearContent();
            // バッファリング
            Response.Buffer = true;
            // HTTPヘッダー情報設定
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", HttpUtility.UrlEncode(fileName)));
            Response.ContentType = "application/pdf";
            // ファイル書込
            Response.WriteFile(fileName);
            // フラッシュ
            Response.Flush();

            File.Delete(fileName);

            // レスポンス終了
            Response.End();
        }
    }
}
