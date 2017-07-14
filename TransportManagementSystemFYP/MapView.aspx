<%@ Page Title="Vehicle Map" Language="C#" MasterPageFile="~/TransportManager.Master" AutoEventWireup="true" CodeBehind="MapView.aspx.cs" Inherits="TransportManagementSystemFYP.MapView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact w3l-2">
        <div class="container">
            <h2 class="w3ls_head">Vehicle <span>Map</span></h2>
            <div class="col-md-12 contact-grid agileinfo-5">
                <div id="map" style="height: 800px; width: 100%;"></div>
                <script>
                    function initMap() {
                        var uluru = { lat: 32.2049, lng: 74.1924 };
                        var map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 4,
                            center: uluru
                        });
                        var marker = new google.maps.Marker({
                            position: uluru,
                            map: map
                        });
                    }
                </script>
                <script async="async" defer="defer" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBZfcs2f4etjyRKrPoWWyPAGu80qmaZmkw&callback=initMap" type="text/javascript"></script>
            </div>
        </div>
    </div>
</asp:Content>
