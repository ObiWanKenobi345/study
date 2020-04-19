<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWebUserControl.ascx.cs" Inherits="HtmlElements1.MyWebUserControl" %>

<p>
    Фамилия
    <asp:TextBox ID="SurnameTextBox" runat="server" CssClass="input" ValidationGroup="g1" />
    <asp:RequiredFieldValidator ID="SurnameRequiredValidator" runat="server" ControlToValidate="SurnameTextBox" Display="None"
        ErrorMessage="Введите фамилию" ValidationGroup="g1" />
</p>

<p>
    Имя
    <asp:TextBox ID="NameTextBox" runat="server" ValidationGroup="g1" CssClass="input" />
    <asp:RequiredFieldValidator ID="NameRequsetValidatot" runat="server" ControlToValidate="NameTextBox" Display="None"
        ErrorMessage="Введите имя" ValidationGroup="g1" />
</p>

<p>
    Отчество
    <asp:TextBox ID="MiddleNameTextBox" runat="server" CssClass="input" />
    <asp:RequiredFieldValidator ID="MiddleNameValidator" runat="server" ControlToValidate="MiddleNameTextBox" Display="None"
        ErrorMessage="Введите отчество" ValidationGroup="g1" />
</p>

<p>
    Дата рождения
    <asp:TextBox ID="DateOfBirthTextBox" runat="server" TextMode="Date" CssClass="input" />
    <asp:RequiredFieldValidator ID="DateOfBirthValidator" runat="server" ControlToValidate="DateOfBirthTextBox" Display="None"
        ErrorMessage="Введите дату рождения" ValidationGroup="g1" />
</p>

<p>
    Пол
    <asp:RadioButtonList ID="GenderList" runat="server">
        <asp:ListItem>М</asp:ListItem>
        <asp:ListItem>Ж</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ID="GenderValidator" runat="server" ControlToValidate="GenderList" Display="None"
        ErrorMessage="Выберите пол" ValidationGroup="g1" />
</p>

<p>
    Факультет
    <asp:DropDownList ID="FacultyList" runat="server" CssClass="input">
        <asp:ListItem>ФИТ</asp:ListItem>
        <asp:ListItem>ПИМ</asp:ListItem>
        <asp:ListItem>ХТиТ</asp:ListItem>
        <asp:ListItem>ТОВ</asp:ListItem>
    </asp:DropDownList>
</p>

<p>
    Группа
    <asp:TextBox ID="GroupTextBox" runat="server" TextMode="Number" CssClass="input" ValidationGroup="g1" />
    <asp:RangeValidator ID="GroupRangeValidator" runat="server" ControlToValidate="GroupTextBox" Display="None"
        ErrorMessage="Группа должна быть в пределах от 1 до 100" MinimumValue="1" MaximumValue="100" Type="Integer" ValidationGroup="g1" />
    <asp:RequiredFieldValidator ID="GroupValidator" runat="server" ControlToValidate="GroupTextBox" Display="None"
        ErrorMessage="Введите номер группы" ValidationGroup="g1" />
</p>

<p>
    Год поступления
    <asp:TextBox ID="StartYearTextBox" runat="server" TextMode="Number" CssClass="input" />
    <asp:RequiredFieldValidator ID="StartYearValidator" runat="server" ControlToValidate="StartYearTextBox" Display="None"
        ErrorMessage="Введите год поступления" ValidationGroup="g1" />
</p>
<br />

<p>
    <asp:Button ID="EnterButton" runat="server" Text="Ввод" ValidationGroup="g1" OnClick="EnterButton_Click" />
    &nbsp;
    <asp:Button ID="CancelButton" runat="server" Text="Отказаться" OnClick="CancelButton_Click" />
</p>

<p>
    <asp:ValidationSummary ID="StudentFormValidationSummary" runat="server" ValidationGroup="g1" HeaderText="<b>Пожалуйста, исправьте следующие ошибки: </b>"
        ShowSummary="true" ShowMessageBox="false" DisplayMode="BulletList" />
</p>