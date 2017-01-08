<%@ Page Title="Клиники" Language="C#" MasterPageFile="~/Site.master" %>

<script runat="server">

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <center>
        <h1>Поликлиники Москвы</h1>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdClinic" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IdClinic" HeaderText="ID Клиники" ReadOnly="True" SortExpression="IdClinic">
                <HeaderStyle Font-Size="Medium" />
                <ItemStyle Font-Size="Medium" />
                </asp:BoundField>
                <asp:BoundField DataField="ClinicName" HeaderText="Полное название клиники" SortExpression="ClinicName">
                <HeaderStyle Font-Size="Medium" />
                <ItemStyle Font-Size="Medium" />
                </asp:BoundField>
                <asp:BoundField DataField="Adress" HeaderText="Адрес" SortExpression="Adress">
                <HeaderStyle Font-Size="Medium" />
                <ItemStyle Font-Size="Medium" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView><asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelecting="SqlDataSource1_Selecting" ConnectionString="<%$ ConnectionStrings:TESTConnectionString1 %>" DeleteCommand="DELETE FROM [Clinic] WHERE [IdClinic] = @IdClinic" InsertCommand="INSERT INTO [Clinic] ([IdClinic], [ClinicName], [Adress]) VALUES (@IdClinic, @ClinicName, @Adress)" SelectCommand="SELECT [IdClinic], [ClinicName], [Adress] FROM [Clinic]" UpdateCommand="UPDATE [Clinic] SET [ClinicName] = @ClinicName, [Adress] = @Adress WHERE [IdClinic] = @IdClinic">
            <DeleteParameters>
                <asp:Parameter Name="IdClinic" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="IdClinic" Type="Int32" />
                <asp:Parameter Name="ClinicName" Type="String" />
                <asp:Parameter Name="Adress" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ClinicName" Type="String" />
                <asp:Parameter Name="Adress" Type="String" />
                <asp:Parameter Name="IdClinic" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </center>
</asp:Content>

