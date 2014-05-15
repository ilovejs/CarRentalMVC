<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SofiaCarRental.DAL.Car>" %>

<h2><%: Model.Make %> <%: Model.Model %></h2>
<dl class="carInfo">
    <dt><%: Html.LabelFor(x=> Model.CarYear) %></dt>
    <dd><%: Model.CarYear %></dd>
    <dt><%: Html.LabelFor(x=> Model.Category) %></dt>
    <dd><%: Model.Category.CategoryName%></dd>
</dl>


