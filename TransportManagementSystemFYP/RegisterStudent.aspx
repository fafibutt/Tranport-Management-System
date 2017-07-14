<%@ Page Title="Register Student" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Register <span>Student</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateSelectButton="true"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="UniID" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="UniID" HeaderText="UniID" ReadOnly="True" SortExpression="UniID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC" />
                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Route" HeaderText="Route" SortExpression="Route" />
                            <asp:BoundField DataField="Stop" HeaderText="Stop" SortExpression="Stop" />
                            <asp:BoundField DataField="Expr1" HeaderText="Expr1" SortExpression="Expr1" Visible="False" />
                            <asp:BoundField DataField="Payment" HeaderText="Payment" SortExpression="Payment" Visible="False" />
                        </Columns>
                        <HeaderStyle CssClass="header"></HeaderStyle>

                        <PagerStyle CssClass="pager"></PagerStyle>

                        <RowStyle CssClass="rows"></RowStyle>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT StudentRegistration.*, Payment.UniID AS Expr1, Payment.Payment FROM Payment INNER JOIN StudentRegistration ON Payment.UniID = StudentRegistration.UniID AND Payment.Payment='OK'"></asp:SqlDataSource>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
