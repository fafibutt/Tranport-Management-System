<%@ Page Title="Register Vehicle" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="RegisterVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--contact-->
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Vehicle <span>Registration</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>Vehicle ID</label>
                    <asp:TextBox ID="VehicleID" placeholder="Vehicle ID..." required="" runat="server"></asp:TextBox>
                    <label>Vehicle Name</label>
                    <asp:TextBox ID="VehicleName" placeholder="Vehicle name..." required="" runat="server"></asp:TextBox>
                    <label>Vehicle Number</label>
                    <asp:TextBox ID="VehicleNumber" placeholder="Vehicle number..." required="" runat="server"></asp:TextBox>
                    <label>Vehicle Chassis Number</label>
                    <asp:TextBox ID="VehicleChassisNumber" placeholder="Vehicle chassis number..." required="" runat="server"></asp:TextBox>
                    <label>Vehile Owner</label>
                    <asp:DropDownList ID="OwnerDropDown" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="VehicleRegistration" type="submit" runat="server" Text="Register Vehicle" />

                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <!--contact-->

</asp:Content>
