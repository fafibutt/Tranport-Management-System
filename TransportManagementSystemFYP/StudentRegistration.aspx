<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="TransportManagementSystemFYP.StudentRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Transportation <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>University ID</label>
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                    <label>Name</label>
                    <asp:TextBox ID="StudentName" placeholder="Your name..." required="" runat="server"></asp:TextBox>
                    <label>CNIC</label>
                    <asp:TextBox ID="StudentCNIC" placeholder="Your CNIC..." required="" runat="server"></asp:TextBox>
                    <label>Address</label>
                    <asp:TextBox ID="StudentAddress" placeholder="Your address..." required="" runat="server"></asp:TextBox>
                    <label>Number</label>
                    <asp:TextBox ID="StudentNumber" placeholder="Your number..." required="" runat="server"></asp:TextBox>
                    <label>City</label>
                    <asp:DropDownList ID="StudentCity" CssClass="form-control" runat="server"></asp:DropDownList>
                    <label>Route</label>
                    <asp:DropDownList ID="StudentRoute" CssClass="form-control" runat="server"></asp:DropDownList>
                    <label>Stop</label>
                    <asp:DropDownList ID="StudentStop" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="RegistrationStudent" type="submit" runat="server" Text="Register" />

                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
