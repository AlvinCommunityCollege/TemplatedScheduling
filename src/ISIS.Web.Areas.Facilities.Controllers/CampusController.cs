﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Campus.ViewModels;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class CampusController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            Campus.DetailsLinkFormat = Url.Action("Details", "Campus", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Building.DetailsLinkFormat = Url.Action("Details", "Building", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Map.DetailsLinkFormat = Url.Action("Details", "Map", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Room.DetailsLinkFormat = Url.Action("Details", "Room", new { Id = "asdf" })
                .Replace("asdf", "{0}");

            var campusLoadChildrenUrlFormat = Url.Action("Data", "Building", new { campusId = "asdf" })
                .Replace("asdf", "{0}");
            var buildingLoadChildrenUrlFormat = Url.Action("Data", "Map", new { buildingId = "asdf" })
                .Replace("asdf", "{0}");
            var mapLoadChildrenUrlFormat = Url.Action("Data", "Room", new { mapId = "adsf" })
                .Replace("asdf", "{0}");

            var tree = FacilitiesSource.GetTree(Id,
                                                mapLoadChildrenUrlFormat,
                                                buildingLoadChildrenUrlFormat,
                                                campusLoadChildrenUrlFormat);
            return View(tree);
        }
        [HttpGet]
        public ViewResult Index()
        {
            Campus.DetailsLinkFormat = Url.Action("Details", "Campus", new { Id = "asdf" })
                .Replace("asdf","{0}");
            Building.DetailsLinkFormat = Url.Action("Details", "Building", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Map.DetailsLinkFormat = Url.Action("Details", "Map", new {Id = "asdf"})
                .Replace("asdf", "{0}");
            Room.DetailsLinkFormat = Url.Action("Details", "Room", new {Id = "asdf"})
                .Replace("asdf", "{0}");
            return View(new Index(GetCampuses()));
        }

        [HttpGet]
        public JsonResult Data()
        {
                return Json(GetCampuses(), JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public IEnumerable<Campus> GetCampuses()
        {
            return FacilitiesSingleton.Facilities.GetChildren(Guid.Empty)
                .Select(tuple => new Campus(
                                     tuple.Item1,
                                     tuple.Item2,
                                     tuple.Item3,
                                     Url.Action("Data", "Building", new {campusId = tuple.Item1})));
        }

    }
}
