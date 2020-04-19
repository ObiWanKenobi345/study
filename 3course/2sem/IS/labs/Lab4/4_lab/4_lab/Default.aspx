<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_4_lab.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" CssClass="buttonStyle" runat="server" Text="Button" OnClick="Button1_Click"/>
            <asp:Label ID="Label1" CssClass="textStyle" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            
                <asp:Button ID="Button2"  runat="server" Text="Button"/>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
