<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SofiaCarRental.DAL.RentalOrder>" %>

   
<% using(Html.BeginForm("CreateOrder", "Car", FormMethod.Post)) %>
<% { %>
        <%: Html.ValidationSummary(false) %>

        <div class="floated">
            <%: Html.LabelFor(x => x.RentStartDate) %> 
            <%: Html.Telerik().DatePickerFor(x => x.RentStartDate)
                                .Name("newRentStartDate") %>
            
        </div>
        <div class="floated">
            <%: Html.LabelFor(x => x.RentEndDate) %> 
            <%: Html.Telerik().DatePickerFor(x => x.RentEndDate) 
                                .Name("newRentEndDate") %>
        </div>
        <%: Html.HiddenFor(x => x.CarID) %>

        
        <input type="submit" class="t-button" value="Book" />
<% } %>