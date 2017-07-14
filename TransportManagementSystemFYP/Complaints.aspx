<%@ Page Title="Complaint" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="Complaints.aspx.cs" Inherits="TransportManagementSystemFYP.Complaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Student <span>Complaints</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" AutoGenerateSelectButton="True"
                    OnSelectedIndexChanged="GridView_SelectedIndexChanged" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ComplaintID">
                    <Columns>
                        <asp:BoundField DataField="ComplaintID" HeaderText="ComplaintID" SortExpression="ComplaintID" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="UniID" HeaderText="UniID" SortExpression="UniID" />
                        <asp:BoundField DataField="Complaint" HeaderText="Complaint" SortExpression="Complaint" />
                    </Columns>
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <PagerStyle CssClass="pager"></PagerStyle>

                    <RowStyle CssClass="rows"></RowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="SELECT * FROM [StudentComplaint]"></asp:SqlDataSource>
            </div>
            <br />
            <div class="col-md-12 contact-grid agileinfo-5">
                <asp:TextBox ID="CID" placeholder="Complaint ID..." required="" runat="server"></asp:TextBox>
                <asp:TextBox ID="UniID" placeholder="Uni ID..." required="" runat="server"></asp:TextBox>
                <asp:TextBox ID="StudentComplaint" placeholder=" Student Complaint..." required="" runat="server"></asp:TextBox>
                <asp:TextBox ID="ComplaintDecision" placeholder="Complaint Decision..." required="" runat="server"></asp:TextBox>
                <asp:Button ID="SendDecision" CssClass="btn pull-right" runat="server" Text="Decision" OnClick="SendDecision_Click" />
            </div>
        </div>
    </div>
</asp:Content>
