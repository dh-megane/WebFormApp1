using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvanceSoftware.ExcelCreator;

namespace WebApp.SAMPLEFRM
{
    public partial class MAIN : System.Web.UI.Page
    {
        string C_TEMPLATE_FILE_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/TemplateTotalInvoice.xlsx");
        string C_SAVE_DIR_PATH = HttpContext.Current.Server.MapPath("../TEMPLATE/{0}");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // JavaScriptを登録
                BtnDialogOpen.OnClientClick = $"showSubWindow('./FORM1.aspx?parentBtnId={ BtnDataSet.ClientID }'); return false;";
            }
        }

        protected void BtnDataSet_Click(object sender, EventArgs e)
        {
            // セッションから情報を取得する
            txtAddress1.Text = Session["Address1"].ToString();
            txtAddress2.Text = Session["Address2"].ToString();
            txtAddress3.Text = Session["Address3"].ToString();
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            var creator1 = new Creator();
            creator1.OpenBook(C_TEMPLATE_FILE_PATH + "SAMPLE.xlsx", C_TEMPLATE_FILE_PATH);

            //【2】値の設定
            creator1.Cell("B4").Value = "ExcelCreator 2016";
            creator1.Cell("H4").Value = 10;
            creator1.Cell("K4").Value = 64000;
            creator1.Cell("O4").Func("=H4*K4", 640000);
            creator1.Cell("B5").Value = "VB-Report 8";
            creator1.Cell("H5").Value = 8;
            creator1.Cell("K5").Value = 85000;
            creator1.Cell("O5").Func("=H5*K5", 680000);
            creator1.Cell("B6").Value = "ExcelWebForm";
            creator1.Cell("H6").Value = 5;
            creator1.Cell("K6").Value = 70000;
            creator1.Cell("O6").Func("=H6*K6", 350000);
            creator1.Cell("O10").Func("=SUM(O4:R8)", 1670000);
            creator1.Cell("O11").Func("=O10*0.08", 133600);
            creator1.Cell("O12").Func("=O10+O11", 1803600);

            //【3】Excel ファイルクローズ、PDF 出力d
            var save_file_name = $"SAMPLE_{ DateTime.Now.ToString("yyyyMMddhhmmss") }.pdf";
            creator1.CloseBook(true, string.Format(C_SAVE_DIR_PATH, save_file_name), true);
                
            // Response情報クリア
            Response.ClearContent();
            // バッファリング
            Response.Buffer = true;
            // HTTPヘッダー情報設定
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", HttpUtility.UrlEncode(save_file_name)));
            Response.ContentType = "application/pdf";
            // ファイル書込
            Response.WriteFile(string.Format(C_SAVE_DIR_PATH, save_file_name));
            // フラッシュ
            Response.Flush();

            File.Delete(string.Format(C_SAVE_DIR_PATH, save_file_name));

            // レスポンス終了
            Response.End();   
        }
    }
}