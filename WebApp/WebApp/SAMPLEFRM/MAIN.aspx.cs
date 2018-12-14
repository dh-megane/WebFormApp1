﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SAMPLEFRM
{
    public partial class MAIN : System.Web.UI.Page
    {
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
    }
}