﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;
using ISIS.Web.Areas.Schedule.Models.Section.InputModels;
using ISIS.Web.Areas.Schedule.Models.Section.ViewModels;
using Microsoft.Web.Mvc;
using ChangeInstructor = ISIS.Web.Areas.Schedule.Models.Section.ViewModels.ChangeInstructor;
using ChangeRoom = ISIS.Web.Areas.Schedule.Models.Section.ViewModels.ChangeRoom;
using ChangeTerm = ISIS.Web.Areas.Schedule.Models.Section.ViewModels.ChangeTerm;

namespace ISIS.Web.Areas.Schedule.Controllers
{
    public class SectionController : ControllerBase
    {

        [HttpGet]
        public ActionResult Index()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult)Json(GetSectionList(), JsonRequestBehavior.AllowGet)
                       : View(GetSectionList());
        }

        [HttpGet]
        public ActionResult Details(Guid Id)
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult)Json(GetSectionDetails(Id), JsonRequestBehavior.AllowGet)
                       : View(GetSectionDetails(Id));
        }

        [HttpGet]
        public ActionResult ChangeRoom(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetChangeRoom(Id), JsonRequestBehavior.AllowGet);
            return View(GetChangeRoom(Id));
        }

        [HttpGet]
        public ActionResult RoomAvailability(Guid id, string map)
        {
            return Json(GetRoomAvailability(id, map), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ChangeInstructor(Guid Id)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            if (!Request.IsAjaxRequest())
                return HttpNotFound("Not a JSON request");
            return Json(GetChangeInstructor(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangeTerm(Guid Id)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            if (!Request.IsAjaxRequest())
                return HttpNotFound("Not a JSON request");
            return Json(GetChangeTerm(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangeInstructorEquipment(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetInstructorEquipment(Id), JsonRequestBehavior.AllowGet);
            return View(GetInstructorEquipment(Id));
        }

        [HttpGet]
        public ActionResult ChangeSchedule(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetChangeSchedule(Id), JsonRequestBehavior.AllowGet);
            return View(GetChangeSchedule(Id));
        }

        [HttpGet]
        public ActionResult ChangeStudentEquipment(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetStudentEquipment(Id), JsonRequestBehavior.AllowGet);
            return View(GetStudentEquipment(Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeRoom(Models.Section.InputModels.ChangeRoom model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeInstructor(Models.Section.InputModels.ChangeInstructor model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeCapacity(ChangeCapacity model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeTerm(Models.Section.InputModels.ChangeTerm model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveInstructorEquipment(RemoveInstructorEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeInstructorEquipment(model.SectionId));
        }

        [HttpPost]
        public RedirectToRouteResult AddInstructorEquipment(AddInstructorEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeInstructorEquipment(model.SectionId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveStudentEquipment(RemoveStudentEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeStudentEquipment(model.SectionId));
        }

        [HttpPost]
        public RedirectToRouteResult AddStudentEquipment(AddStudentEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeStudentEquipment(model.SectionId));
        }

        [HttpPost]
        public RedirectToRouteResult SetStandardSchedule(SetStandardSchedule model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult SetNonstandardSchedule(SetNonstandardSchedule model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult CancelSection(CancelSection model)
        {
            return this.RedirectToAction(c => c.Index());
        }

        [HttpPost]
        public RedirectToRouteResult CreateTemplate(CreateTemplate model)
        {
            var templateId = Guid.NewGuid();
            return this.RedirectToAction<TemplateController>(c => c.Details(templateId));
        }

        [HttpPost]
        public RedirectToRouteResult AddNote(AddNote model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [NonAction]
        public Index GetSectionList()
        {
            return new Index(
                new[]
                    {
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "02 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "03 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "M1 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "IM1 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1302 Trigonometry", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "02 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2302 Calculus 2", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0309 Developmental Math 3",
                                             "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0308 Developmental Math 2",
                                             "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0307 Developmental Math 1",
                                             "01 John Smith")
                    });
        }

        [NonAction]
        public Details GetSectionDetails(Guid id)
        {
            var sections = GetSectionList().Sections;
            return new Details(
                sections,
                id,
                "MATH 2301.02 Calculus 1",
                "MATH 2301 Calculus 1",
                "Mini 1",
                25,
                "D105",
                "Jane Smith",
                "MW 8:00 a.m. to 9:30 a.m.",
                new[] {"1 Whiteboard", "1 PC", "1 Projector"},
                new string[0],
                true,
                Url.Action("ChangeInstructor", new {Id = id}),
                true,
                Url.Action("ChangeTerm", new {Id = id}),
                true,
                new []
                    {
                        new Note(Guid.NewGuid(), DateTime.Now.AddMonths(-1), "Patty Balderas", "Should this section be cancelled? It never makes, and we need a bigger room for DevEd Math."), 
                        new Note(Guid.NewGuid(), DateTime.Now.AddMonths(-1).AddDays(2), "Jennifer Hopkins", "I'll teach it online."), 
                        new Note(Guid.NewGuid(), DateTime.Now.AddMonths(-1).AddDays(2).AddHours(1), "Patty Balderas", "Okay.")
                    });
        }

        [NonAction]
        private ChangeInstructor GetChangeInstructor(Guid Id)
        {
            var instructors = new Dictionary<Guid, string>()
                                  {
                                      {Guid.NewGuid(), "John Smith"},
                                      {Guid.NewGuid(), "Joe Smith"},
                                      {Guid.NewGuid(), "Jim Smith"},
                                      {Guid.NewGuid(), "James Smith"},
                                      {Guid.NewGuid(), "Jane Smith"},
                                      {Guid.NewGuid(), "Juan Smith"}
                                  };
            return new ChangeInstructor(Id, instructors);
        }

        [NonAction]
        private ChangeTerm GetChangeTerm(Guid Id)
        {
            var terms = new Dictionary<Guid, string>()
                                  {
                                      {Guid.NewGuid(), "Spring 2012"},
                                      {Guid.NewGuid(), "Spring 2012 Mini 1"},
                                      {Guid.NewGuid(), "Spring 2012 Mini 2"},
                                      {Guid.NewGuid(), "Spring 2012 Mini 3"}
                                  };
            return new ChangeTerm(Id, terms);
        }

        [NonAction]
        private ChangeInstructorEquipment GetInstructorEquipment(Guid Id)
        {
            var sections = GetSectionList().Sections;
            return new ChangeInstructorEquipment(
                sections,
                Id,
                "MATH 2301 Calculus 1",
                "MATH 2301.02 Calculus 1",
                GetEquipmentList().ToDictionary(
                    i => Guid.NewGuid(),
                    i => i),
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "1 Whiteboard"},
                        {Guid.NewGuid(), "1 PC"},
                        {Guid.NewGuid(), "1 Projector"}
                    });
        }

        [NonAction]
        private ChangeStudentEquipment GetStudentEquipment(Guid Id)
        {
            var sections = GetSectionList().Sections;
            return new ChangeStudentEquipment(
                sections,
                Id,
                "MATH 2301 Calculus 1",
                "MATH 2301.02 Calculus 1",
                GetEquipmentList().ToDictionary(
                    i => Guid.NewGuid(),
                    i => i),
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "1 PC per student"}
                    });
        }

        [NonAction]
        private IEnumerable<string> GetEquipmentList()
        {
            return new[]
                       {
                           "Whiteboard",
                           "PC",
                           "Projector",
                           "Chalkboard",
                           "Lab Sink"
                       }.OrderBy(s => s);
        }

        [NonAction]
        private ChangeSchedule GetChangeSchedule(Guid id)
        {
            var sections = GetSectionList().Sections;

            var days = new[] {"MW", "TTh", "MWF"};
            var times = new Dictionary<string, IEnumerable<string>>()
                            {
                                {
                                    "MW", new[]
                                              {
                                                  "8:00 a.m. to 9:30 a.m.",
                                                  "9:30 a.m. to 11:00 a.m.",
                                                  "11:00 a.m. to 12:30 p.m.",
                                                  "1:00 p.m. to 2:30 p.m.",
                                                  "2:30 p.m. to 4:00 p.m.",
                                                  "4:00 p.m. to 5:30 p.m."
                                              }
                                    },
                                {
                                    "TTh", new[]
                                               {
                                                   "8:00 a.m. to 9:30 a.m.",
                                                   "9:30 a.m. to 11:00 a.m.",
                                                   "11:00 a.m. to 12:30 p.m.",
                                                   "1:00 p.m. to 2:30 p.m.",
                                                   "2:30 p.m. to 4:00 p.m.",
                                                   "4:00 p.m. to 5:30 p.m."
                                               }
                                    },
                                {
                                    "MWF", new[]
                                               {
                                                   "8:00 a.m. to 9:00 a.m.",
                                                   "9:00 a.m. to 10:00 a.m.",
                                                   "10:00 a.m. to 11:00 a.m.",
                                                   "11:00 a.m. to 12:00 p.m.",
                                                   "12:00 p.m. to 1:00 p.m.",
                                                   "1:00 p.m. to 2:00 p.m.",
                                                   "2:00 p.m. to 3:00 p.m.",
                                                   "3:00 p.m. to 4:00 p.m.",
                                                   "4:00 p.m. to 5:00 p.m.",
                                               }
                                    }
                            };


            return new ChangeSchedule(
                sections,
                id,
                "MATH 2301 Calculus 1",
                "MATH 2301.02 Calculus 1",
                new StandardScheduleData(days, times)
                );
        }

        [NonAction]
        private ChangeRoom GetChangeRoom(Guid Id)
        {
            var sections = GetSectionList().Sections;

            return new ChangeRoom(
                sections,
                Id,
                "MATH 2301 Calculus 1",
                "MATH 2301.01 Calculus 1",
                new[]
                    {
                        new Campus("Main Campus",
                                   new[]
                                       {
                                           new Building("A",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=A1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=A2",
                                                                                    Id)))
                                                            }),
                                           new Building("B",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=B1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=B2",
                                                                                    Id)))
                                                            }),
                                           new Building("C",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=C1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=C2",
                                                                                    Id)))
                                                            }),
                                           new Building("D",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=D1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=D2",
                                                                                    Id)))
                                                            }),
                                           new Building("E",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/E1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/E1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=E1",
                                                                                    Id)))
                                                            }),
                                           new Building("F",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=F1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=F2",
                                                                                    Id)))
                                                            }),
                                           new Building("G",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/G1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/G1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=G2",
                                                                                    Id)))
                                                            }),
                                           new Building("H",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/H1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/H1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=H1",
                                                                                    Id)))
                                                            }),
                                           new Building("J",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/J1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/J1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=J1",
                                                                                    Id)))
                                                            }),

                                           new Building("K",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/K1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/K1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=K1",
                                                                                    Id)))
                                                            }),

                                           new Building("N",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/N1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/N1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=N1",
                                                                                    Id)))
                                                            }),
                                           new Building("Nolan Ryan Center",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/NRC1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/NRC1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=NRC1",
                                                                                    Id)))
                                                            }),
                                           new Building("S",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=S1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Section/RoomAvailability/{0}?map=S2",
                                                                                    Id)))
                                                            })
                                       }),
                        new Campus("Pearland Campus", new Building[0])
                    });

        }

        [NonAction]
        private IEnumerable<RoomAvailability> GetRoomAvailability(Guid id, string map)
        {
            return new[]
                       {
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "100", RoomStatuses.Available),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "105", RoomStatuses.Unavailable,
                                                "MATH 0309.01"),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "111", RoomStatuses.MissingEquipment,
                                                "Missing 1 whiteboard"),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "112", RoomStatuses.Available),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "126", RoomStatuses.ReducedCapacity,
                                                "Capacity: 17"),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "127", RoomStatuses.Available),
                           new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "129", RoomStatuses.Unavailable,
                                                "ENGL 1302.01")
                       };
        }


    }
}
