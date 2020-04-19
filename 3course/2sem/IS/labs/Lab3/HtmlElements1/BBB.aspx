<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BBB.aspx.cs" Inherits="HtmlElements1.BBB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .input {
            position: absolute;
            left: 140px;
        }
    </style>
    <script>
        function validateDateOfBirth(control, args) {
            var today = new Date();

            var timeInMills = Date.parse(args.Value);
            var date = new Date(timeInMills);

            var currentDate = new Date(today.getFullYear(), today.getMonth(), today.getDate(), 0, 0, 0, 0);
            var selectedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate(), 0, 0, 0, 0);

            args.IsValid = currentDate.getTime() > selectedDate.getTime();
        }

        function checkPasswordLength(control, args) {
            var password = args.Value;
            if (password == null || password.length < 7)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        function isSymbolsUniqueInPassword(control, args) {
            var str = args.Value;
            if (str != null) {
                var obj = {};
                for (var z = 0; z < str.length; ++z) {
                    var ch = str[z];
                    if (obj[ch]) {
                        args.IsValid = false;
                        return;
                    } else
                        obj[ch] = true;
                }
                args.IsValid = true;
            } else
                args.IsValid = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                Фамилия
                <asp:TextBox ID="SurnameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="SurnameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SurnameTextBox" ErrorMessage="Введите фамилию" />
                <asp:RegularExpressionValidator ID="SurnameExpressionValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SurnameTextBox" ErrorMessage="Фамилия должна содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                Имя
                <asp:TextBox ID="NameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="NameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="NameTextBox" ErrorMessage="Введите имя" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="NameTextBox" ErrorMessage="Имя должно содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                Отчество
                <asp:TextBox ID="MiddleNameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="MiddleNameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="MiddleNameTextBox" ErrorMessage="Введите отчество" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="MiddleNameTextBox" ErrorMessage="Отчество должно содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                Дата Рождения
                <asp:TextBox ID="DateOfBirthTextBox" TextMode="Date" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:CustomValidator ID="DateOfBirthValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="DateOfBirthTextBox" ErrorMessage="Дата рождения не может быть больше текущей даты"
                    ClientValidationFunction="validateDateOfBirth" OnServerValidate="DateOfBirthValidator_ServerValidate" />
                <asp:RequiredFieldValidator ID="DateOfBirthRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="DateOfBirthTextBox" ErrorMessage="Введите Дату Рождения" />
            </p>

            <p>
                Email-адрес
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="input" ValidationGroup="g1" TextMode="Email" />
                <asp:RegularExpressionValidator ID="EmailExpressionValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="EmailTextBox" ErrorMessage="Email-адрес введён некорректно" ValidationExpression="\S+@\S+\.\S+" />
                <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="EmailTextBox" ErrorMessage="Введите Email-адрес" />
            </p>

            <p>
                Сумма
                <asp:TextBox ID="SumTextBox" runat="server" CssClass="input" ValidationGroup="g1" TextMode="Number" />
                <asp:RangeValidator ID="SumRangeValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SumTextBox" ErrorMessage="Сумма должна быть в промежутке от [1000, 2000]"
                    MinimumValue="1000" MaximumValue="2000" Type="Integer" />
                <asp:RequiredFieldValidator ID="SumRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SumTextBox" ErrorMessage="Введите сумму [1000, 2000]" />
            </p>

            <p>
                Пароль
                <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="input" ValidationGroup="g1" TextMode="Password" />
                <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Введите пароль" />
                <asp:CustomValidator ID="PasswordLengthCustomValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Длина пароля должна быть 7 и более символов"
                    ClientValidationFunction="checkPasswordLength" OnServerValidate="PasswordLengthCustomValidator_ServerValidate" />
                <asp:CustomValidator ID="UniqueSymbolsInPasswordValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Все символы в пароле должны быть уникальны"
                    ClientValidationFunction="isSymbolsUniqueInPassword" OnServerValidate="UniqueSymbolsInPasswordValidator_ServerValidate" />
            </p>
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Отправить данные" ValidationGroup="g1" />
            <br />

            <p>
                <asp:ValidationSummary ID="Summary" DisplayMode="BulletList" runat="server" ValidationGroup="g1"
                    HeaderText="<b>Пожалуйста, исправьте следующие ошибки: </b>" ShowSummary="true" ShowMessageBox="false" />
            </p>
        </div>
    </form>
</body>
</html>