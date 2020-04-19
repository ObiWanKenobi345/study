<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControlPage.aspx.cs" Inherits="HtmlElements1.UserControlPage" %>

<%@ Register Src="~/MyWebUserControl.ascx" TagPrefix="uc1" TagName="MyWebUserControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User control</title>
    <style>
        .input {
            position: absolute;
            left: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:MyWebUserControl runat="server" ID="MyWebUserControl" EnterButtonText="Отправить данные" />
        </div>
    </form>
</body>
</html>