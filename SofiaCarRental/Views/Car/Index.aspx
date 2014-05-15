<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SofiaCarRental.Models.CarsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rent A Car
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box home">
        
        <div class="datePickers">
            <% using (Html.BeginForm("Search", "Car")) %>
            <% { %>
            <div class="picker">
                <dl>
                    <dt>Rental Pick-up</dt>
                    <dd>
                        <%= Html.LabelFor(x => x.DatePickerModelView.RentalPickUpDate) %>
                        <%= Html.Telerik().DatePickerFor(x => x.DatePickerModelView.RentalPickUpDate)%>
                    </dd>
                    <dd>
                        <%= Html.LabelFor(x => x.DatePickerModelView.RentalPickUpTime)%>
                        <%= Html.Telerik().TimePickerFor(x => x.DatePickerModelView.RentalPickUpTime)%>
                    </dd>
                </dl>
            </div>
            <div class="picker">
                <dl>
                    <dt>Rental Return</dt>
                    <dd>
                        <%= Html.LabelFor(x => x.DatePickerModelView.RentalReturnDate)%>
                        <%= Html.Telerik().DatePickerFor(x => x.DatePickerModelView.RentalReturnDate)%>
                    </dd>
                    <dd>
                        <%= Html.LabelFor(x => x.DatePickerModelView.RentalReturnTime)%>
                        <%= Html.Telerik().TimePickerFor(x => x.DatePickerModelView.RentalReturnTime)%>
                    </dd>
                </dl>
            </div>
            <div class="submitBut">
                <input type="submit" value="Search" class="t-button" />
                <span>or</span>
                <%= Html.ActionLink("View vehicles available today", "SearchToday", "Car") %>

                <%= 
                Html.ValidationSummary(false)
                %>
            </div>
        </div>
        <% } %>
        <div class="vehiclesBox">
            <h2>
                Vehicle Fleet</h2>
            <% 
                Html.Telerik()
                    .Grid(Model.Cars)
                        .Name("grid")
                        .Pageable()
                        .Pageable()
                        .Sortable()
                        .Groupable()
                        .Columns(columns =>
                            {



                                columns
                                    .Template(c =>
                                    {
            %>
            <img alt="<%= c.Model + ":" + c.Make %>" src="<%= Url.Content("~/Content/Images/Cars/Thumbs/" + c.ImageFileName) %>"
                width="60px" />
            <%
                });

                        columns.Bound(x => x.Make);
                        columns.Bound(x => x.Model);
                        columns.Bound(x => x.CarYear);
                        columns.Bound(x => x.Category.CategoryName).Groupable(true);
                        columns.Bound(x => x.AirConditioner).Template(c =>
                            {
            %>
            <%= c.AirConditioner ?? false %>
            <% 
                });
                        columns.Bound(x => x.CarID)
                            .Groupable(false)
                            .HeaderTemplate("&nbsp;")
                            .Template(o =>
                            { 
            %>
            <%= Html.ActionLink("View Car", "Details", "Car", new { carId = o.CarID }, new { @class = "t-button" }) %>
            <%
                });
                    }).Render();
            %>
        </div>
    </div>
</asp:Content>
