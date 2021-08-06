<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Math.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>乘法對照產生器</h1>
            <table>
                <tr>
                    <td>基數</td>
                    <td>
                        <asp:TextBox ID="txtBaseNum" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>係數</td>
                    <td>
                        <asp:TextBox ID="txtCoefficientNum" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" ></asp:Label></td>
                    <td align="right">
                        <asp:Button ID="btnSent" runat="server" Text="產生" OnClick="btnSent_Click" />
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>
