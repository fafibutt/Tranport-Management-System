<%@ Page Title="Edit Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentRegistrationEdit.aspx.cs" Inherits="TransportManagementSystemFYP.StudentRegistrationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Edit <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>University ID</label>
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                    <label>Name</label>
                    <asp:TextBox ID="StudentName" placeholder="Your name..." required="" runat="server"></asp:TextBox>
                    <label>CNIC</label>
                    <asp:TextBox ID="StudentCNIC" placeholder="Your CNIC..." required="" runat="server"></asp:TextBox>
                    <label>City</label>
                    <asp:TextBox ID="StudentCity" placeholder="Your City..." required="" runat="server"></asp:TextBox>
                    <label>Address</label>
                    <asp:TextBox ID="StudentAddress" placeholder="Your address..." required="" runat="server"></asp:TextBox>
                    <label>Number</label>
                    <asp:TextBox ID="StudentNumber" placeholder="Your number..." required="" runat="server"></asp:TextBox>
                    <label>Route</label>
                    <asp:DropDownList ID="StudentRoute" CssClass="form-control" runat="server"></asp:DropDownList>
                    <label>Stop</label>
                    <asp:DropDownList ID="StudentStop" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6 contact-grid agileinfo-5">
                    <asp:Button ID="UpadteRegistration" type="submit" runat="server" Text="Edit Registration" />
                    </div>
                <div class="col-md-6 contact-grid agileinfo-5">
                    <asp:Button ID="CancelUpadte" type="submit" runat="server" Text="Cancel Update" />
                    </div>

                <div class="clearfix"></div>
            </div>
            </div>
        </div>

</asp:Content>
