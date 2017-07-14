<%@ Page Title="Assign Route To Vehicle" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="AssignRouteToVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.AssignRouteToVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Assign <span>Route</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <label>Select Vehicle</label>
                    <asp:DropDownList ID="VehicleDropDown" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <label>Select Route</label>
                    <asp:DropDownList ID="RouteDropDown" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="AssignRoute" type="submit" CssClass="btn pull-right" runat="server" Text="Assign Route" OnClick="AssignRoute_Click" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
