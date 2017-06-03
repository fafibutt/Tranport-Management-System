<%@ Page Title="" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ViewRoute.aspx.cs" Inherits="TransportManagementSystemFYP.ViewRoute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Route <span>Record</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="RouteID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="RouteID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="RouteID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                        <asp:BoundField DataField="Road" HeaderText="Road" SortExpression="Road" />
                    </Columns>
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <PagerStyle CssClass="pager"></PagerStyle>

                    <RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [Route]"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
