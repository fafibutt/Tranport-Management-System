﻿<%@ Page Title="Delete Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentDeleteRegistration.aspx.cs" Inherits="TransportManagementSystemFYP.StudentDeleteRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
     <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Delete <span>Registration</span></h2>
				<div class="contact-grids">
                    <div class="col-md-12 contact-grid agileinfo-5">
                        <asp:GridView ID="GridView" DataKeyNames="UniID" AutoGenerateDeleteButton="true"
                             OnRowDeleting="GridView_RowDeleting" 
                              runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>
                         <br />
                        </div>					
						<div class="clearfix"></div>
				</div>
		</div>
	</div>
</asp:Content>