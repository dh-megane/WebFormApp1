<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FORM1.aspx.cs" Inherits="WebApp.SAMPLEFRM.FORM1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script type="text/javascript" src="../JS/jquery.js"></script>
<script type="text/javascript" src="../JS/jquery-ui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="title">ダイアログ画面内容</div>
        <div>
            <table>
                <tr>
                    <td>
                        住所1:
                    </td>
                    <td>
                        <asp:label id="lblAddress1" runat="server" text="東京都"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        住所2:
                    </td>
                    <td>
                        <asp:label id="lblAddress2" runat="server" text="渋谷区"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        住所3:
                    </td>
                    <td>
                        <asp:label id="lblAddress3" runat="server" text="XXX町"></asp:label><br />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="BtnDataReturn" runat="server" Text="セット" OnClick="BtnDataReturn_Click" />
        </div>
    </form>
</body>
</html>
