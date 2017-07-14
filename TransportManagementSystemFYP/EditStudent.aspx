<%@ Page Title="Update Student" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="TransportManagementSystemFYP.EditStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Update <span>Student</span></h2>
            <div class="contact-grids">
                <div class="col-lg-12 contact-grid agileinfo-5">
                    <asp:TextBox ID="SearchTextBox" placeholder="Enter Student to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSearchVehicle" CssClass="btn pull-right" runat="server" Text="Search Vehicle" OnClick="BtnSearchVehicle_Click" />
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="col-md-12 contact-grid agileinfo-5">
                    <asp:GridView ID="GridView" AutoGenerateSelectButton="true"
                        OnSelectedIndexChanged="GridView_SelectedIndexChanged"
                        runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                    </asp:GridView>
                    <br />
                </div>
                <div class="col-md-12 contact-grid agileinfo-5">
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="StudentName" placeholder="Your name..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="StudentCNIC" placeholder="Your CNIC..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="StudentAddress" placeholder="Your address..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="StudentNumber" placeholder="Your number..." required="" runat="server"></asp:TextBox>
                    <asp:Button ID="UpdateStudent" type="submit" runat="server" Text="Update Student" OnClick="UpdateStudent_Click"/>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
