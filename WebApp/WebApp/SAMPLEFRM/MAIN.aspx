<%@ Page Title="" Language="C#" MasterPageFile="~/SAMPLEFRM/SAMPLE.Master" AutoEventWireup="true" CodeBehind="MAIN.aspx.cs" Inherits="WebApp.SAMPLEFRM.MAIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="BtnDialogOpen" runat="server" Text="ダイアログ" />
        <asp:Button ID="BtnDataSet" runat="server" Text="内容反映" style="display:none" OnClick="BtnDataSet_Click"  />
        <div id="contents">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAddress3" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
