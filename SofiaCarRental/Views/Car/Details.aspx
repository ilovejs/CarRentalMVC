<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SofiaCarRental.Models.CarDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Car Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box">
    <div class="detailsBox">
        <div class="details">
            <div class="infoBox">
                
                <img class="carImage"
                    alt="<%= Model.Car.Model + ":" + Model.Car.Make %>" 
                    src="<%= Url.Content("~/Content/Images/Cars/" + Model.Car.ImageFileName) %>" 
                />

                <div class="carInfo">
                    <% Html.RenderPartial("CarDetails", Model.Car); %>

                    <button class="t-button" id="toggle-button">Book this car</button>
                    <% 
                        string newItemVisible = "none";
                        if (this.ViewData["sentForEdit"] != null)
                        {
                            newItemVisible = "block";
                        }
                           
                    %>
                    <div class="toggle-visibility" style="display: <%= newItemVisible %>">
                        <% Html.RenderPartial("RentalOrderForm", Model.NewRentalOrder); %>
                    </div>
        
                    <script type="text/javascript">
                    $("#toggle-button").click(function () {
                            $('div.toggle-visibility').toggle();
                        });
                    </script>
                </div>
                
            </div>
            <div class="ordersInfo">

                <h2>Rental Orders</h2>
                <%: Html.ValidationSummary(false) %>
                <%
                    string formatString = "{0:d}";
                    int carId = Model.Car.CarID;
                    
                    Html.Telerik()
                        .Grid(Model.Car.RentalOrders)
                        .Name("rentalOrders")
                        .DataKeys(keys => keys.Add(x => x.RentalOrderID))
                        .DataBinding(dataBinding => dataBinding
                            .Server()
                                .Select("Details", "Car",new { carId })
                                .Update("EditOrder", "Car", new { carId })
                                .Delete("DeleteOrder", "Car", new { carId }))
                        .Columns(columns =>
                        {
                            columns.Bound(x => x.RentStartDate).Format(formatString).Width(200);
                            columns.Bound(x => x.RentEndDate).Format(formatString).Width(200);
                            columns.Bound(x => x.Days).ReadOnly();
                            columns.Command(commands =>
                            {
                                commands.Edit();
                                commands.Delete();
                            }).Width(200);

                        })
                        .Editable(editable => editable.Mode(GridEditMode.InLine))
                        .Render();
                %>

                <%: Html.ActionLink("Back to All Vehicles", "Index", "Car", null, new { @class = "t-button back" })%> 

            </div>

        </div>
    </div>
    </div>
</asp:Content>
