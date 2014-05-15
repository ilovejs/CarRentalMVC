using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SofiaCarRental.Tests
{
    public static class TestExtensions
    {
        public static T GetModel<T>(this ActionResult result)
            where T : class
        {
            ViewResult viewResult = IsViewResult(result);

            var model = viewResult.ViewData.Model as T;
            Assert.IsNotNull(model);

            return model;

        }

        private static ViewResult IsViewResult(ActionResult result)
        {
            ViewResult viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(viewResult.ViewData);
            return viewResult;
        }

        public static void AssertIsViewResult(this ActionResult result)
        {
            IsViewResult(result);
        }

        public static void AssertHasViewName(this ActionResult result, string viewName)
        {
            ViewResultBase viewResultBase = result as ViewResultBase;
            Assert.IsNotNull(viewResultBase);
            Assert.AreEqual(viewName, viewResultBase.ViewName);
        }

        public static void AssertRedirectTo(this ActionResult result, string action, string controller)
        {
            var redirectResult = result as RedirectToRouteResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual(action, redirectResult.RouteValues["action"]);
            Assert.AreEqual(controller, redirectResult.RouteValues["controller"]);
        }
    }
    
}
