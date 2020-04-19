<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlausibilityСheck.aspx.cs" Inherits="HtmlElements1.PlausibilityСheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function isSimpleNumber(ctrl, args) {
            for (var i = 2; i < args.Value; i++)
                if (args.Value % i === 0) {
                    args.IsValid = false;
                    return;
                }
            args.IsValid = (args.Value !== 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Task 1</h3>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator runat="server" ID="TextBox1Validator" ForeColor="Red" ControlToValidate="TextBox1"
                    ErrorMessage="Введите данные в TextBox1" ValidationGroup="g1" />
            </p>

            <p>
                <asp:DropDownList ID="DropDownList1" ValidationGroup="g1" runat="server" />
                <asp:RequiredFieldValidator ID="DropDownList1Validator" ControlToValidate="DropDownList1" ForeColor="Red" runat="server"
                    ErrorMessage="Выберите значение из списка" ValidationGroup="g1" />
            </p>

            <p>
                <asp:Button ID="Button1" Text="Button 1" ValidationGroup="g1" runat="server" />
            </p>
            <br />

            <h3>Task 2</h3>
            <p>
                <asp:TextBox runat="server" ID="TextBox21" ValidationGroup="g2" />
                <asp:RangeValidator ID="IntValueValidator" ControlToValidate="TextBox21" runat="server"
                    ForeColor="Red" ValidationGroup="g2" MinimumValue="100" MaximumValue="200"
                    Type="Integer" ErrorMessage="Значение не входит в диапазон [100, 200]" />
            </p>
            <p>
                <asp:TextBox runat="server" ID="TextBox22" ValidationGroup="g2" />
                <asp:RangeValidator runat="server" ID="DateRangeValidator" ControlToValidate="TextBox22"
                    ForeColor="Red" ValidationGroup="g2" MinimumValue="01.01.2011" MaximumValue="12.31.2011"
                    Type="Date" ErrorMessage="Значение даты не входит в диапазон 01/01/2011 - 31/12/2011" />
            </p>

            <p>
                <asp:Button runat="server" ID="Button2" ValidationGroup="g2" Text="Button 2" />
            </p>
            <br />

            <h3>Task 3</h3>
            <p>
                <asp:TextBox runat="server" TextMode="Date" ID="TextBox31" ValidationGroup="g3" />
                <asp:CompareValidator ID="DateCompareValidator" runat="server" Type="Date" ControlToValidate="TextBox31" ControlToCompare="TextBox32"
                    ValidationGroup="g3" ForeColor="Red" Operator="LessThan" ErrorMessage="Значение даты должно быть меньше, чем во втором TextBox'е" />
            </p>

            <p>
                <asp:TextBox runat="server" TextMode="Date" ID="TextBox32" ValidationGroup="g3" />
            </p>

            <p>
                <asp:Button runat="server" ID="Button3" ValidationGroup="g3" Text="Button 3" />
            </p>
            <br />

            <h3>Task 4</h3>
            <p>
                <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="g4" />
                <asp:RegularExpressionValidator ID="EmailExpressionValidator" runat="server" ValidationGroup="g4"
                    ControlToValidate="TextBox4" ValidationExpression="\S+@\S+\.\S+"
                    ErrorMessage="Введён некорректный email-адрес" ForeColor="Red" />
            </p>

            <p>
                <asp:Button ID="Button4" runat="server" Text="Button 4" ValidationGroup="g4" />
            </p>
            <br />

            <h3>Task 5</h3>
            <p>
                <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="g5" TextMode="Number" />
                <asp:CustomValidator ID="SimpleNumberValidator" ValidationGroup="g5" runat="server" ControlToValidate="TextBox5"
                    ClientValidationFunction="isSimpleNumber" OnServerValidate="SimpleNumberValidator_ServerValidate"
                    ErrorMessage="Число не является простым" ForeColor="Red" />
            </p>
            <p>
                <asp:Button ID="Button5" runat="server" Text="Button 5" ValidationGroup="g5" />
            </p>
        </div>
    </form>
</body>
</html>
