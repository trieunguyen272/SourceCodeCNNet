using System.Web.Mvc;

namespace DMS_DTCK.Areas.User
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{id}",
                new { action = "HomePage", id = UrlParameter.Optional }
                
            );
            

        }
    }
}