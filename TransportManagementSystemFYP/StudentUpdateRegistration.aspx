<%@ Page Title="Update Registration" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentUpdateRegistration.aspx.cs" Inherits="TransportManagementSystemFYP.StudentUpdateRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Edit <span>Registration</span></h2>
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
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CNIC">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CNIC" runat="server" Text='<%#Eval("CNIC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_CNIC" runat="server" Text='<%#Eval("CNIC") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Address" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Address" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_NO" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_NO" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_City" runat="server" Text='<%# Eval("City")%>' Visible = "false"></asp:Label>
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
                                    <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("Stop") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_stop" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
