<%@ Page Title="Cancel Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentCancelRegistration.aspx.cs" Inherits="TransportManagementSystemFYP.StudentCancelRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Cancel <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>University ID</label>
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 contact-grid agileinfo-5">
                    <asp:Button ID="CancelRegistration" type="submit" runat="server" Text="Update Registration" />
                    </div>
                <div class="col-md-6 contact-grid agileinfo-5">
                    <asp:Button ID="CancelRequest" type="submit" runat="server" Text="Cancel" />
                    </div>

                <div class="clearfix"></div>
            </div>
            </div>
        </div>
</asp:Content>
