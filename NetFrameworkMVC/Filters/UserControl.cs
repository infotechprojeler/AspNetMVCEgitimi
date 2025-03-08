using System.Web.Mvc;

namespace NetFrameworkMVC.Filters
{
	public class UserControl : ActionFilterAttribute
	{
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // bir action çalıştırılacağı zaman kontrol yapmamızı sağlar
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userguid = filterContext.HttpContext.Request.Cookies["userguid"];
            
            var UserGuid = filterContext.HttpContext.Session["userguid"];
            if (UserGuid == null)
                filterContext.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(filterContext);
        }
    }
}