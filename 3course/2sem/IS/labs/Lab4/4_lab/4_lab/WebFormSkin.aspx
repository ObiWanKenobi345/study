<%@ Page Language="C#" AutoEventWireup="true" Theme="Skin1" CodeBehind="WebFormSkin.aspx.cs" Inherits="_4_lab.WebFormSkin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:TextBox ID="TextBox1" runat="server">dfdd</asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button2" EnableTheming="false" runat="server" Text="Button" />
            <asp:Label ID="Label2" runat="server" SkinID="lab2" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
