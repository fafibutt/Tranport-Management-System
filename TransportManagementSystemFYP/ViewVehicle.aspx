<%@ Page Title="Vehicle Record" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ViewVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.ViewVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Vehicle <span>Record</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="VehicleID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="VehicleID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="VehicleID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />
                        <asp:BoundField DataField="ChassisNumber" HeaderText="Chassis Number" SortExpression="ChassisNumber" />
                        <asp:BoundField DataField="OwnerName" HeaderText="Owner Name" SortExpression="OwnerName" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    </Columns>
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <PagerStyle CssClass="pager"></PagerStyle>

                    <RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [Vehicle] WHERE ([Status] = @Status)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="Active" Name="Status" QueryStringField="Status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
