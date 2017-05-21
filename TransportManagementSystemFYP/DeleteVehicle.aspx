﻿<%@ Page Title="Delete Vehicle" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="DeleteVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.DeleteVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Delete <span>Vehicle</span></h2>
				<div class="contact-grids">
                    <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter Vehicle to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchVehicle" CssClass="btn pull-right" runat="server" Text="Search Vehicle" OnClick="BtnSearchVehicle_Click" />
                         </div>
                    <div class="clearfix"></div>
                      <br />
                    <div class="col-md-12 contact-grid agileinfo-5">
                        <asp:GridView ID="GridView" DataKeyNames="VehicleID" AutoGenerateDeleteButton="true" OnRowDeleting="GridView_RowDeleting"
                             OnRowDataBound="GridView_RowDataBound" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>	
                         <br />
                        </div>					
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
</asp:Content>