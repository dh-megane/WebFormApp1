using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SAMPLEFRM
{
    public partial class FORM1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var parentBtnId = Request.QueryString["parentBtnId"].ToString();
                // 親画面の隠しボタンをセッションに保存
                Session["parentBtnId"] = parentBtnId;

            }
        }

        protected void BtnDataReturn_Click(object sender, EventArgs e)
        {
            // セッション変数で情報を渡す
            Session["Address1"] = lblAddress1.Text;
            Session["Address2"] = lblAddress2.Text;
            Session["Address3"] = lblAddress3.Text;

            // ダイアログクローズ後、親画面の隠しボタンを実行する
            var parentBtnId = (string)Session["parentBtnId"];
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script>");
            sb.AppendLine("window.parent.$('#subWindow').dialog('close');");
            sb.AppendLine($"$('#{ parentBtnId }', parent.document).click();");
            sb.AppendLine("</script>");

            ClientScript.RegisterStartupScript(GetType(), "", sb.ToString());
        }
    }
}