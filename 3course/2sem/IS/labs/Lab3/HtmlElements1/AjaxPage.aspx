<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPage.aspx.cs" Inherits="HtmlElements1.AjaxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function pageLoad() {
            var pageManager = Sys.WebForms.PageRequestManager.getInstance();
            pageManager.add_endRequest(endRequest);
        }

        function endRequest(sender, args) {
            if (args.get_error() != null) {
                alert(args.get_error().message);
                args.set_errorHandled(true);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />

            <p>
                <b>Task 1</b>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Button 1" OnClick="Button1_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            </p>
            <br />


            <p>
                <b>Task 2</b>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox1" AutoPostBack="true" runat="server" />
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="RadioButton1" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                </ContentTemplate>
            </asp:UpdatePanel>
            </p>
            <br />

            <p>
                <b>Task 3</b>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button2" runat="server" Text="Generate error" OnClick="Button2_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <br />

            <p>
                <b>Task 4</b>
                <br />
                <asp:Button ID="AsyncPostBackButton" runat="server" Text="AsyncPostBack" OnClick="AsyncPostBackButton_Click" />
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="Label2" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="AsyncPostBackButton" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </p>
            <br />

            <p>
                <b>Task 5</b>
                <asp:Timer ID="Timer1" runat="server" Interval="1500" OnTick="Timer1_Tick" />
                <asp:Timer ID="Timer2" runat="server" Interval="3000" OnTick="Timer2_Tick" />
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        Counter 1:
                        <asp:Label ID="Counter1Label" runat="server" Text="0" />
                        <br />
                        Counter 2:
                        <asp:Label ID="Counter2Label" runat="server" Text="0" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
            </p>
            <br />

            <p>
                <b>Tasks 7, 8</b>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="TimeLabel" runat="server" Text="Click to refresh" />
                        <br />
                        <asp:Button ID="RefreshTime" runat="server" Text="Refresh time" OnClick="RefreshTime_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                    <ProgressTemplate>
                        <br />
                        <br />
                        <img src="loading.gif" width="50px" height="50px" alt="Loading" />
                        <input type="button" id="CancelLoading" value="Cancel" onclick="AbortPostBack()" /> 
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </p>
        </div>
        <script>
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);

            function InitializeRequest(sender, args) {
                if (prm.get_isInAsyncPostBack()) {
                    args.set_cancel(true);
                }
            }

            function AbortPostBack() {
                if (prm.get_isInAsyncPostBack()) {
                    prm.abortPostBack();
                }
            }
</script>
    </form>
</body>
</html>