<%@ Page Title="Register Stop" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="RegisterStop.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterStop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Stop <span>Registration</span></h2>
				<div class="contact-grids">
					<div class="col-md-6 contact-grid agileinfo-5">						
						<label>Select Route</label>
                        <asp:DropDownList ID="RouteDropDown" CssClass="form-control" runat="server"></asp:DropDownList>
						<label>Stop ID</label>
						<asp:TextBox ID="StopID" placeholder="Stop ID..." required="" runat="server"></asp:TextBox>
						<label>Stop Name</label>
						<asp:TextBox ID="StopName" placeholder="Stop name..." required="" runat="server"></asp:TextBox>
						<label>Stop Location</label>
						<asp:TextBox ID="StopLocation" placeholder="Stop location..." required="" runat="server"></asp:TextBox>                      
                        <asp:Button ID="AddStopToList" type="submit" runat="server" Text="Add Stop" />
						
					</div>
				<div class="col-lg-6 contact-grid agileinfo-5">
                    <label>Stops List</label>
                    <asp:ListBox ID="StopListBox" CssClass="form-control" runat="server"></asp:ListBox>
                    <asp:Button ID="StopRegistration" type="submit" runat="server" Text="Register Stop" />
				</div>
						<div class="clearfix"></div>
				</div>
		</div>
	</div>

<!--contact-->
</asp:Content>
