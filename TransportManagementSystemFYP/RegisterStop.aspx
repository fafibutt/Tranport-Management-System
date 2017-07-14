<%@ Page Title="Register Stop" Language="C#" MasterPageFile="~/TransportManager.Master" ViewStateMode="Enabled" AutoEventWireup="true" CodeBehind="RegisterStop.aspx.cs" Inherits="TransportManagementSystemFYP.RegisterStop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function massege() {
            swal({
                title: 'Congratulation!',
                text: 'Your Data has been saved',
                type: 'success',
                confirmButtonText: 'ok'
            },
            function () {
                window.location.href = 'RegisterStop.aspx';
            });
        }
    </script>
    <div class="contact w3l-2">
		<div class="container">
			<h2 class="w3ls_head">Stop <span>Registration</span></h2>
				<div class="contact-grids">
					<div class="col-md-6 contact-grid agileinfo-5">						
						<label>Select Route</label>
                        <asp:DropDownList ID="RouteDropDown" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Wapda town" Value="1"></asp:ListItem>
                        </asp:DropDownList>
						<label>Stop Name</label>
						<asp:TextBox ID="StopName" placeholder="Stop name..." required="" runat="server"></asp:TextBox>
						<label>Stop Location</label>
						<asp:TextBox ID="StopLocation" placeholder="Stop location..." required="" runat="server"></asp:TextBox>                      
                        <asp:Button ID="AddStopToList" type="submit" runat="server" Text="Add Stop" OnClick="AddStopToList_Click" />
						
					</div>
				<div class="col-lg-6 contact-grid agileinfo-5">
                    <label>Stops List</label>
                    <asp:GridView ID="GridView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
                        </asp:GridView>	
                    <asp:Button ID="StopRegistration" type="submit" runat="server" Text="Register Stop" OnClick="StopRegistration_Click" />
				</div>
						<div class="clearfix"></div>
				</div>
		</div>
	</div>

<!--contact-->
</asp:Content>
