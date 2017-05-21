<%@ Page Title="Update Vehicle" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="EditVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.EditVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Update <span>Vehicle</span></h2>
				<div class="contact-grids">
                    <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter vehicle to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchVehicle" CssClass="btn pull-right" runat="server" Text="Search Vehicle" OnClick="BtnSearchVehicle_Click" />
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div class="col-md-12 contact-grid agileinfo-5">
                        <asp:GridView ID="GridView" AutoGenerateSelectButton="true"
                             OnSelectedIndexChanged="GridView_SelectedIndexChanged"
                              runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>	
                         <br />
                        </div>                 
					<div class="col-md-12 contact-grid agileinfo-5">
                    <asp:TextBox ID="VehicleID" placeholder="Vehicle ID..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="VehicleName" placeholder="Vehicle name..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="VehicleNumber" placeholder="Vehicle number..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="VehicleChassisNumber" placeholder="Vehicle chassis number..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="VehicleOwner" placeholder="Owner name..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="VehicleStatus" placeholder="Vehicle status..." required="" runat="server"></asp:TextBox>
                    <asp:Button ID="UpdateVehicle" type="submit" runat="server" Text="Update Vehicle" OnClick="UpdateVehicle_Click" />					
					</div>				
						<div class="clearfix"></div>
				</div>
		</div>
	</div>

</asp:Content>
