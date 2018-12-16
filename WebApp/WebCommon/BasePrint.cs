using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceSoftware.ExcelCreator;

namespace WebCommon
{
    public abstract class BasePrint
    {
        protected Creator creator = new Creator();

        abstract protected void PrintHeader();

        abstract protected void PrintDetail();

        abstract protected void PrintFooter();

        public string Print()
        {
            string TEMPLATE_FILE_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/TemplateTotalInvoice.xlsx");
            string SAVE_DIR_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/{0}");

            // BOOKをオーバーレイオープン
            creator.OpenBook(TEMPLATE_FILE_PATH + "SAMPLE.xlsx", TEMPLATE_FILE_PATH);

            // ヘッダ部印刷
            PrintHeader();

            // 明細部印刷
            PrintDetail();

            // フッター部印刷
            PrintFooter();

            //【3】Excel ファイルクローズ、PDF出力
            var save_file_name = $"SAMPLE_{ DateTime.Now.ToString("yyyyMMddhhmmss") }.pdf";
            creator.CloseBook(true, string.Format(SAVE_DIR_PATH, save_file_name), true);

            return string.Format(SAVE_DIR_PATH, save_file_name);
        }

    }
}
