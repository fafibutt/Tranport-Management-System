<%@ Page Title="Students Details" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ViewStudent.aspx.cs" Inherits="TransportManagementSystemFYP.ViewStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Student <span>Detail</span></h2>
            <div class="contact-grids">
               <div class="col-md-12 contact-grid agileinfo-5">
                    <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="UniID" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="UniID" HeaderText="UniID" ReadOnly="True" SortExpression="UniID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC" />
                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Route" HeaderText="Route" SortExpression="Route" />
                            <asp:BoundField DataField="Stop" HeaderText="Stop" SortExpression="Stop" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        </Columns>
<HeaderStyle CssClass="header"></HeaderStyle>

<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
                    </asp:GridView>
                    <br />
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [Student] WHERE ([Status] = @Status)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="Active" Name="Status" QueryStringField="Status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
