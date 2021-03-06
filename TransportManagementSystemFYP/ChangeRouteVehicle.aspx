﻿<%@ Page Title="Change Route Of Vehicle" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="ChangeRouteVehicle.aspx.cs" Inherits="TransportManagementSystemFYP.ChangeRouteVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Change <span>Route</span></h2>
            <div class="contact-grids">
                <div class="col-lg-12 contact-grid agileinfo-5">               
                        <asp:TextBox ID="SearchTextBox" placeholder="Enter route to search..." CssClass="form-control" type="search" required="" runat="server"></asp:TextBox> 
                        <asp:Button ID="BtnSearchRoute" CssClass="btn pull-right" runat="server" Text="Search Route" OnClick="BtnSearchRoute_Click" />
                         </div>
                    <div class="clearfix"></div>
                      <br />
                <div class="col-lg-12 contact-grid agileinfo-5" >
                    <div class="col-md-12 contact-grid agileinfo-5">
                        <asp:GridView ID="GridView" AutoGenerateSelectButton="true"
                             OnSelectedIndexChanged="GridView_SelectedIndexChanged"
                              runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>	
                         <br />
                        </div>     
                </div>
                <div class="col-md-12 contact-grid agileinfo-5">
                    <div class="row">
                        <div class="col-md-6 contact-grid agileinfo-5"><asp:TextBox ID="RouteId" ReadOnly="true" runat="server"></asp:TextBox></div>
                        <div class="col-md-6 contact-grid agileinfo-5"><asp:TextBox ID="RouteName" ReadOnly="true" runat="server"></asp:TextBox></div>
                    </div>
                    <asp:DropDownList ID="VehicleDropDown" CssClass="form-control" runat="server">
                    </asp:DropDownList>                  
                    <asp:Button ID="UpdateVehicle" type="submit" CssClass="btn pull-right" runat="server" Text="Update Vehicle" OnClick="UpdateVehicle_Click" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
