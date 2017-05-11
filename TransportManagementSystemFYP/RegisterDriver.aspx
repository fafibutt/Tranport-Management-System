<%@ Page Title="Register Driver" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="RegisterDriver.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterDriver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Driver <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>Driver ID</label>
                    <asp:TextBox ID="DriverID" placeholder="Driver ID..." required="" runat="server"></asp:TextBox>
                    <label>Driver Name</label>
                    <asp:TextBox ID="DriverName" placeholder="Driver name..." required="" runat="server"></asp:TextBox>
                    <label>Driver City</label>
                    <asp:TextBox ID="DriverCity" placeholder="Driver City..." required="" runat="server"></asp:TextBox>
                    <label>Driver Address</label>
                    <asp:TextBox ID="DriverAddress" placeholder="Driver address..." required="" runat="server"></asp:TextBox>
                    <label>Driver Number</label>
                    <asp:TextBox ID="DriverNumber" placeholder="Driver number..." required="" runat="server"></asp:TextBox>
                    <label>Driver CNIC</label>
                    <asp:TextBox ID="DriverCNIC" placeholder="Driver CNIC..." required="" runat="server"></asp:TextBox>
                    <label>Driver Licence Number</label>
                    <asp:TextBox ID="LicenceNumber" placeholder="Driver licenec number..." required="" runat="server"></asp:TextBox>          
                    <asp:Button ID="DriverRegistration" type="submit" runat="server" Text="Register Driver" />

                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
