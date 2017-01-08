<%@ Page Title="Добавить данные" Language="C#" MasterPageFile="~/Site.master" %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Инициализируем LINK SQL и таблицу Staff
        StaffdbDataContext db = new StaffdbDataContext();
        Staff staff = new Staff();
        // Присваиваем связь между столбцами таблицы и TextBox-ами
        staff.IdClinic = Convert.ToInt32(DropDownList1.Text);
        staff.Sername = Sername.Text;
        staff.Name = Name.Text;
        staff.MiddleName = MiddleName.Text;
        staff.Position = Position.Text;
        staff.TelNumber = TelNumber.Text;
        staff.PCNumber = PCNumber.Text;
        // Отображаем данные на таблице
        db.Staff.InsertOnSubmit(staff);
        db.SubmitChanges();
        // Обновляем страницу
        Response.Redirect("/AddData.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Инициализируем LINK SQL и таблицу Staff
        ClinicdbDataContext db = new ClinicdbDataContext();
        Clinic clinic = new Clinic();
        // Присваиваем связь между столбцами таблицы и TextBox-ами
        clinic.IdClinic = Convert.ToInt32(IdClinic.Text);
        clinic.ClinicName = ClinicName.Text;
        clinic.Adress = Adress.Text;
        // Отображаем данные на таблице
        db.Clinic.InsertOnSubmit(clinic);
        db.SubmitChanges();
        // Обновляем страницу
        Response.Redirect("/AddData.aspx");
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3 class="auto-style12">
        &nbsp;</h3>
<h3 class="auto-style12">
    <span class="auto-style12">Внесите данные в Таблицу сотрудников</span></h3>
    <%--<asp:Panel ID="Panel1" runat="server" CssClass="auto-style18" Width="504px" ForeColor="Red" HorizontalAlign="Left">
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorYear" runat="server" ErrorMessage="* Поле Год обязательно для заполнения!" ControlToValidate="Year"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCode" runat="server" ControlToValidate="Code" ErrorMessage="* Поле Код обязательно для заполнения!"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="Name" ErrorMessage="* Поле Наименование обязательно для заполнения!"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFinance" runat="server" ControlToValidate="Finance" ErrorMessage="* Поле Источник финансирования обязательно для заполнения!"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSavePlace" runat="server" ControlToValidate="SavePlace" ErrorMessage="* Поле Место хранения обязательно для заполнения!"></asp:RequiredFieldValidator>
    </asp:Panel>--%>
<p class="auto-style1">
    <asp:Label ID="Label1" runat="server" Text="Клиника"></asp:Label>

    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ClinicName" DataValueField="IdClinic" Width="400px">
    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TESTConnectionString1 %>" SelectCommand="SELECT DISTINCT * FROM [Clinic]">
    </asp:SqlDataSource>
</p>
    <p class="auto-style1">
    <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
        &nbsp;<asp:TextBox ID="Sername" runat="server" Width="289px">-</asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Имя"></asp:Label>
    &nbsp;<asp:TextBox ID="Name" runat="server" Width="406px" CssClass="auto-style8" ToolTip="Укажите Ваше имя">-</asp:TextBox>
</p>
    <p class="auto-style1">
    <asp:Label ID="Label4" runat="server" Text="Отчество"></asp:Label>
    &nbsp;<asp:TextBox ID="MiddleName" runat="server" Width="751px" CssClass="auto-style7" ToolTip="Укажите Ваше отчество">-</asp:TextBox>
&nbsp;&nbsp;&nbsp;
    </p>
    <p class="auto-style1">
    <asp:Label ID="Label5" runat="server" Text="Должность"></asp:Label>
    &nbsp;<asp:TextBox ID="Position" runat="server" Width="742px" CssClass="auto-style7" ToolTip="Укажите Вашу должность">-</asp:TextBox>

</p>
    <p class="auto-style1">

     <asp:Label ID="Label6" runat="server" Text="Телефон"></asp:Label>
    &nbsp;<asp:TextBox ID="TelNumber" runat="server" Width="754px" CssClass="auto-style7" ToolTip="Укажите Ваш рабочий номер телефона">-</asp:TextBox>

</p>
    <p class="auto-style1">

     <asp:Label ID="Label7" runat="server" Text="Номер ПК"></asp:Label>
    &nbsp;<asp:TextBox ID="PCNumber" runat="server" Width="751px" CssClass="auto-style7" ToolTip="Укажите номер Вашего персонального компьютера">-</asp:TextBox>
</p>
<p class="auto-style5">
   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ДОБАВИТЬ" BackColor="#7AC0DA" CssClass="auto-style3" Font-Size="Medium" ForeColor="White" Height="33px" Width="123px"/>
     <p class="auto-style5"></p>
         <h3 class="auto-style12">
         <span class="auto-style12">Внесите данные в Таблицу клиник</span></h3>
    <p class="auto-style12">
         <asp:Label ID="Label8" runat="server" Text="ID Клиники"></asp:Label>
         &nbsp;<asp:TextBox ID="IdClinic" runat="server" ToolTip="Внесите следующий ID номер Клиники" Width="128px">0</asp:TextBox>
    &nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label9" runat="server" Text="Полное название клиники"></asp:Label>
         &nbsp;<asp:TextBox ID="ClinicName" runat="server" Width="400px">-</asp:TextBox>
    </p>
    <p class="auto-style12">
         <asp:Label ID="Label10" runat="server" Text="Адрес"></asp:Label>
         &nbsp;<asp:TextBox ID="Adress" runat="server" Width="755px">-</asp:TextBox>
    </p>
    <p class="auto-style12">
         <asp:Button ID="Button2" runat="server" BackColor="#7AC0DA" CssClass="auto-style3" Font-Size="Medium" ForeColor="White" Height="33px" Text="ДОБАВИТЬ" Width="123px" OnClick="Button2_Click" />
    </p>
         </asp:Content>

