﻿using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class ChangeRoom : Index 
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; }
        public IEnumerable<Campus> Campuses { get; set; }

        public ChangeRoom(
            IEnumerable<TemplateListItem> templates,
            Guid id,
            string courseName,
            string templateName,
            IEnumerable<Campus> campuses) 
            : base(templates)
        {
            Id = id;
            TemplateName = templateName;
            Campuses = campuses;
            CourseName = courseName;
        }
    }
}
