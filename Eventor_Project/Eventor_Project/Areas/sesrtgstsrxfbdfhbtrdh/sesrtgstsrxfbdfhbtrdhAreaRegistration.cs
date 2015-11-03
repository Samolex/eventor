using System.Web.Mvc;

namespace Eventor_Project.Areas.sesrtgstsrxfbdfhbtrdh
{
    public class sesrtgstsrxfbdfhbtrdhAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "sesrtgstsrxfbdfhbtrdh";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "sesrtgstsrxfbdfhbtrdh_default",
                "sesrtgstsrxfbdfhbtrdh/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
