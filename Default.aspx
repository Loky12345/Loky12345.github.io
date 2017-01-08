<%@ Page Title="Сотрудники" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <center>
        <h1>Поликлиники Москвы</h1>
        <p class="lead">Здесь представлены данные сотрудников поликлиник города Москвы.</p>

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdStaff" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="IdClinic" HeaderText="ID Клиники" SortExpression="IdClinic">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sername" HeaderText="Фамилия" SortExpression="Sername">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MiddleName" HeaderText="Отчество" SortExpression="MiddleName">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Position" HeaderText="Должность" SortExpression="Position">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TelNumber" HeaderText="Телефон" SortExpression="TelNumber">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PCNumber" HeaderText="Номер ПК" SortExpression="PCNumber">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdStaff" HeaderText="ID Сотрудника" InsertVisible="False" ReadOnly="True" SortExpression="IdStaff">
                    <HeaderStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>

                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TESTConnectionString1 %>" DeleteCommand="DELETE FROM [Staff] WHERE [IdStaff] = @IdStaff" InsertCommand="INSERT INTO [Staff] ([IdClinic], [Sername], [Name], [MiddleName], [Position], [TelNumber], [PCNumber]) VALUES (@IdClinic, @Sername, @Name, @MiddleName, @Position, @TelNumber, @PCNumber)" SelectCommand="SELECT [IdStaff], [IdClinic], [Sername], [Name], [MiddleName], [Position], [TelNumber], [PCNumber] FROM [Staff]" UpdateCommand="UPDATE [Staff] SET [IdClinic] = @IdClinic, [Sername] = @Sername, [Name] = @Name, [MiddleName] = @MiddleName, [Position] = @Position, [TelNumber] = @TelNumber, [PCNumber] = @PCNumber WHERE [IdStaff] = @IdStaff">
                <DeleteParameters>
                    <asp:Parameter Name="IdStaff" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="IdClinic" Type="Int32" />
                    <asp:Parameter Name="Sername" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="MiddleName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="TelNumber" Type="String" />
                    <asp:Parameter Name="PCNumber" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="IdClinic" Type="Int32" />
                    <asp:Parameter Name="Sername" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="MiddleName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="TelNumber" Type="String" />
                    <asp:Parameter Name="PCNumber" Type="String" />
                    <asp:Parameter Name="IdStaff" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>

            <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <strong>Кол-во единиц ПК во всех поликлиниках:</strong> <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
            <br />

        </center>
    </div>

</asp:Content>
