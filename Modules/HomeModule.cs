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
                return View["index.cshtml", ModelMaker()];
            };

            Post["/update/{id}"] = data =>
            {
                Client currentClient = Client.Find(data.id);
                currentClient.Update(Request.Form["new-client-name"], Request.Form["new-client-haircolor"], Request.Form["new-stylist-name"]);
                return View["stylist-singular.cshtml", Stylist.Find(currentClient.GetStylistId())];
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

            Get["/clients"] = _ =>
            {
                return View["clients", Client.GetAll()];
            };
            Post["/clients"] = _ =>
            {
                Client newClient = new Client(Request.Form["client-name"], int.Parse(Request.Form["stylist-id"]), Request.Form["client-hair-color"], System.DateTime.Now);
                newClient.Save();
                return View["clients", Client.GetAll()];
            };

            Get["/stylist_clients/{id}"] = data =>
            {
                return View["stylist-singular.cshtml", Stylist.Find(data.id)];
            };

            Post["/stylist_clients/{id}"] = data =>
            {
                Client newClient = new Client(Request.Form["client-name"], data.id, Request.Form["client-hair-color"], System.DateTime.Now);
                newClient.Save();
                return View["stylist-singular.cshtml", Stylist.Find(data.id)];
            };

            Get["/new-client/{id}"] = data =>
            {
                return View["create-client.cshtml", Stylist.Find(data.id)];
            };

            Get["/update-client/{id}"] = data =>
            {

                return View["update-client.cshtml", Client.Find(data.id)];
            };

            Post["/delete_client/{id}"] = data =>
            {
                Client targetClient = Client.Find(data.id);
                Stylist current = Stylist.Find(targetClient.GetStylistId());
                targetClient.Delete();
                return View["stylist-singular.cshtml", current];
            };

        }

        public static Dictionary<string, object> ModelMaker()
        {
            Dictionary<string, object> model = new Dictionary<string, object> {
                {"stylists", Stylist.GetAll()},
                {"clients", Client.GetAll()}
            };
            return model;
        }












    }
}
