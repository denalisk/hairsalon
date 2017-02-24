using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalonApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["index.cshtml"];
            };

            Get["/stylists"] = _ =>
            {
                return View["stylists.cshtml", Stylist.GetAll()];
            };
            Post["/stylists"] = _ =>
            {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                newStylist.Save();
                return View["stylists", Stylist.GetAll()];
            };
        }
    }
}
