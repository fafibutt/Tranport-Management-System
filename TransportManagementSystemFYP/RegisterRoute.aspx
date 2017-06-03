<%@ Page Title="RegisterRoute" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="RegisterRoute.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Route <span>Registration</span></h2>
				<div class="contact-grids">
					<div class="col-md-12 contact-grid agileinfo-5">
						<label>Route Name</label>
						<asp:TextBox ID="RouteName" placeholder="Route name..."  required="" runat="server"></asp:TextBox>
						<label>Route City</label>
						<asp:TextBox ID="RouteCity" placeholder="Route city..."  required="" runat="server"></asp:TextBox>
						<label>Route Road</label>
						<asp:TextBox ID="RouteRoad" placeholder="Route road..."  required="" runat="server"></asp:TextBox>
                        <asp:Button ID="RouteRegistration" type="submit" runat="server" CssClass="btn pull-right" Text="Register Route" OnClick="RouteRegistration_Click" />
						
					</div>
				
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
<!--contact-->
</asp:Content>
