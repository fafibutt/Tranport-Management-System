<%@ Page Title="Register Complaint" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentComplaint.aspx.cs" Inherits="TransportManagementSystemFYP.StudentComplaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Complaint <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>University ID</label>
                    <asp:TextBox ID="UniID" placeholder="University ID..." required="" runat="server"></asp:TextBox>
                    <label>Complaint Description</label>
                    <asp:TextBox ID="StudentComplaintRegistration" placeholder="Your Complaint..." TextMode="MultiLine" required="" runat="server"></asp:TextBox>
                    <asp:Button ID="RegisterComplaint" type="submit" CssClass="btn pull-right" runat="server" Text="Register Complaint" OnClick="RegisterComplaint_Click"  />
                </div>
                <div class="clearfix"></div>
            </div>
            </div>
        </div>

</asp:Content>
