<%@ Page Title="Update Driver" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="EditDriver.aspx.cs" Inherits="TransportManagementSystemFYP.EditDriver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Update <span>Driver</span></h2>
				<div class="contact-grids">
                    <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter driver to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchDriver" CssClass="btn pull-right" runat="server" Text="Search Driver" OnClick="BtnSearchDriver_Click" />
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
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-4"></div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2"></div>
                        </div>                                     
                    <asp:TextBox ID="DriverID" placeholder="Driver ID..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverName" placeholder="Driver name..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverCity" placeholder="Driver City..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverAddress" placeholder="Driver address..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverNumber" placeholder="Driver number..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverCNIC" placeholder="Driver CNIC..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="LicenceNumber" placeholder="Driver licenec number..." required="" runat="server"></asp:TextBox>
                    <asp:TextBox ID="DriverStatus" placeholder="Driver Status..." required="" runat="server"></asp:TextBox> 
                    <asp:Button ID="UpdateDriver" CssClass="btn pull-right" runat="server" Text="Update Route" OnClick="UpdateDriver_Click"/>
						
					</div>				
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
</asp:Content>
