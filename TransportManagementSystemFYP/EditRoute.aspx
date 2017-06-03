<%@ Page Title="Update Route" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="EditRoute.aspx.cs" Inherits="TransportManagementSystemFYP.EditRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Update <span>Route</span></h2>
				<div class="contact-grids">
                    <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter route to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchRoute" CssClass="btn pull-right" runat="server" Text="Search Route" OnClick="BtnSearchRoute_Click" />
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
                        <asp:TextBox ID="RouteID" placeholder="Route Id..." required="" runat="server"></asp:TextBox>
						<asp:TextBox ID="RouteName" placeholder="Route name..." required="" runat="server"></asp:TextBox>
						<asp:TextBox ID="RouteCity" placeholder="Route city..." required="" runat="server"></asp:TextBox>
						<asp:TextBox ID="RouteRoad" placeholder="Route road..." required="" runat="server"></asp:TextBox>
                        <asp:Button ID="UpdateRoute" CssClass="btn pull-right" runat="server" Text="Update Route" OnClick="UpdateRoute_Click"   />
						
					</div>				
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
</asp:Content>
