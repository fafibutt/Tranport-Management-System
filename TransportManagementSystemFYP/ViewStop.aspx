<%@ Page Title="Stop Record" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ViewStop.aspx.cs" Inherits="TransportManagementSystemFYP.ViewStop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Stop <span>Record</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="StopID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="StopID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="StopID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                        <asp:BoundField DataField="RouteID" HeaderText="Route ID" SortExpression="RouteID" />
                    </Columns>
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <PagerStyle CssClass="pager"></PagerStyle>

                    <RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [Stop]"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
