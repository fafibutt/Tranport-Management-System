<%@ Page Title="Route Change" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentRouteChange.aspx.cs" Inherits="TransportManagementSystemFYP.StudentRouteChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Route <span>Change</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>University ID</label>
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                    <asp:Button ID="LoadRouteDetail" type="submit" runat="server" Text="Route Detail" OnClick="LoadRouteDetail_Click" />
                    <br/>                 
                </div>
                <div class="col-lg-12 contact-grid agileinfo-5">
                    <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>
                </div>
                <div class="col-lg-12 contact-grid agileinfo-5">
                    <label>Select City</label>
                    <asp:DropDownList ID="StudentCity" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <label>Select Route</label>
                    <asp:DropDownList ID="StudentRoute" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <label>Select Stop</label>
                    <asp:DropDownList ID="StudentStop" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="RouteChange" type="submit" runat="server" Text="Change Route" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
