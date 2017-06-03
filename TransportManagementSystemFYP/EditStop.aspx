<%@ Page Title="Update Stop" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="EditStop.aspx.cs" Inherits="TransportManagementSystemFYP.EditStop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Update <span>Stop</span></h2>
				<div class="contact-grids">
                    <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter route to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchStop" CssClass="btn pull-right" runat="server" Text="Search Stop" OnClick="BtnSearchStop_Click"/>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div class="col-md-12 contact-grid agileinfo-5">
                        <asp:GridView ID="GridView" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView_SelectedIndexChanged"
                              runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>	
                         <br />
                        </div>     
					<div class="col-md-12 contact-grid agileinfo-5">
						<asp:TextBox ID="StopID" placeholder="Stop ID..." required="" runat="server"></asp:TextBox>
						<asp:TextBox ID="StopName" placeholder="Stop name..." required="" runat="server"></asp:TextBox>
						<asp:TextBox ID="StopLocation" placeholder="Stop location..." required="" runat="server"></asp:TextBox>
                        <asp:TextBox ID="StopRoute" placeholder="Stop Route..." required="" runat="server"></asp:TextBox>  
                        <asp:Button ID="UpdateStop" CssClass="btn pull-right" runat="server" Text="Update Stop" OnClick="UpdateStop_Click"/>
						
					</div>				
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
</asp:Content>
