<%@ Page Title="Route Change" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentRouteChange.aspx.cs" Inherits="TransportManagementSystemFYP.StudentRouteChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Route <span>Change Request</span></h2>
            <div class="contact-grids">
                <div class="col-md-12 contact-grid agileinfo-5">
                    <asp:GridView ID="GridView" AutoGenerateColumns="false" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit"
                        OnRowUpdating="GridView_RowUpdating" OnRowDataBound="GridView_RowDataBound" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("UniID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_City" runat="server" Text='<%# Eval("City")%>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_city" AutoPostBack="true" OnSelectedIndexChanged="ddl_city_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Route">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Route" runat="server" Text='<%#Eval("Route") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_route" runat="server" OnSelectedIndexChanged="ddl_route_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stop">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Stop" runat="server" Text='<%#Eval("Stop") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_stop" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="Request Route Change" />
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>
            </div>
        </div></div>
</asp:Content>
