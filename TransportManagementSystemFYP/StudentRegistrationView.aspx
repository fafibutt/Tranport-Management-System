<%@ Page Title="View Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentRegistrationView.aspx.cs" Inherits="TransportManagementSystemFYP.StudentRegistrationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Your <span>Registration</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="UniID" HeaderText="UniID" ReadOnly="True" SortExpression="UniID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                        <asp:BoundField DataField="Route" HeaderText="Route" SortExpression="Route" />
                        <asp:BoundField DataField="Stop" HeaderText="Stop" SortExpression="Stop" />
                    </Columns>
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <PagerStyle CssClass="pager"></PagerStyle>

                    <RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
