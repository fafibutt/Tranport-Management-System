<%@ Page Title="Driver Record" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ViewDriver.aspx.cs" Inherits="TransportManagementSystemFYP.ViewDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Driver <span>Record</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="DriverID,CNIC" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="DriverID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="DriverID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="CNIC" HeaderText="CNIC" ReadOnly="True" SortExpression="CNIC" />
                        <asp:BoundField DataField="LicenceNumber" HeaderText="Licence Number" SortExpression="LicenceNumber" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    </Columns>
<HeaderStyle CssClass="header"></HeaderStyle>

<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [Driver] WHERE ([Status] = @Status)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="Active" Name="Status" QueryStringField="Status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
