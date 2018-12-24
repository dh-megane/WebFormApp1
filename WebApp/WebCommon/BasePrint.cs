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
    #region 外部ファイルに定義
    public class EntOrderM
    {

    }

    public class EntOrderMB
    {

    }

    public class EntCorpInfo
    {
        public string COMPANY_NM { get; set; }
        public string TELNO { get; set; }
        public string FAXNO { get; set; }
    }
    #endregion

    /// <summary>
    /// 帳票作成クラス(処理順番を規定)
    /// </summary>
    public abstract class BasePrint
    {
        protected Creator creator = new Creator();

        protected string UketukeID { get; }
        protected string TEMPLATE_FILE_PATH;
        protected string DOWNLOAD_FILE_PATH;
        protected string DOWNLOAD_FILE_NAME;

        public string TEMPLATE_DIR_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/{0}");
        public string DOWNLOAD_DIR_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/{0}");

        public BasePrint(string uketukeID, string templateFileName, string downloadFileName)
        {
            this.UketukeID = uketukeID;
            this.TEMPLATE_FILE_PATH = string.Format(TEMPLATE_DIR_PATH, templateFileName);
            this.DOWNLOAD_FILE_PATH = string.Format(DOWNLOAD_FILE_PATH, downloadFileName);
            this.DOWNLOAD_FILE_NAME = downloadFileName;
        }

        abstract protected void GetPrintData();

        abstract protected void PrintHeader();

        abstract protected void PrintDetail();

        abstract protected void PrintFooter();

        public void Print()
        {
            // 印刷データ取得
            GetPrintData();

            // BOOKをオーバーレイオープン
            creator.OpenBook("", TEMPLATE_FILE_PATH);

            // ヘッダ部印刷
            PrintHeader();

            // 明細部印刷
            PrintDetail();

            // フッター部印刷
            PrintFooter();

            //【3】Excel ファイルクローズ、PDF出力
            creator.CloseBook(true, DOWNLOAD_FILE_PATH, true);

        }

        public void FileDownload(HttpResponse res)
        {
            // Response情報クリア
            res.ClearContent();
            // バッファリング
            res.Buffer = true;
            // HTTPヘッダー情報設定
            res.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", HttpUtility.UrlEncode(DOWNLOAD_FILE_NAME)));
            res.ContentType = "application/pdf";
            // ファイル書込
            res.WriteFile(DOWNLOAD_FILE_PATH);
            // フラッシュ
            res.Flush();

            File.Delete(DOWNLOAD_FILE_PATH);

            // レスポンス終了
            res.End();
        }
    }
}
