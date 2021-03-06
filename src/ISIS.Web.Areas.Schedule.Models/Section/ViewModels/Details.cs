﻿using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class Details : Index 
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }
        public string Term { get; set; }
        public int Capacity { get; set; }
        public string RoomName { get; set; }
        public string InstructorName { get; set; }
        public string ScheduleText { get; set; }
        public IEnumerable<string> InstructorEquipment { get; set; }
        public IEnumerable<string> StudentEquipment { get; set; }
        public bool CanChangeInstructor { get; set; }
        public string GetQualifiedInstructorsUrl { get; set; }
        public bool CanChangeTerm { get; set; }
        public string GetAvailableTermsUrl { get; set; }
        public bool CanCancelSection { get; set; }
        public IEnumerable<Note> Notes { get; set; }

        public Details(
            IEnumerable<SectionListItem> sections,
            Guid id,
            string sectionName,
            string courseName,
            string term,
            int capacity,
            string roomName,
            string instructorName,
            string scheduleText,
            IEnumerable<string> instructorEquipment,
            IEnumerable<string> studentEquipment,
            bool canChangeInstructor,
            string getQualifiedInstructorsUrl,
            bool canChangeTerm,
            string getAvailableTermsUrl,
            bool canCancelSection,
            IEnumerable<Note> notes)
            : base(sections)
        {
            Id = id;
            SectionName = sectionName;
            Term = term;
            Capacity = capacity;
            RoomName = roomName;
            InstructorName = instructorName;
            ScheduleText = scheduleText;
            InstructorEquipment = instructorEquipment;
            StudentEquipment = studentEquipment;
            CanChangeInstructor = canChangeInstructor;
            GetQualifiedInstructorsUrl = getQualifiedInstructorsUrl;
            CanChangeTerm = canChangeTerm;
            GetAvailableTermsUrl = getAvailableTermsUrl;
            CanCancelSection = canCancelSection;
            Notes = notes;
            CourseName = courseName;
        }
    }

    public class Note
    {
        public Guid Id { get; set; }
        public string NoteAdded { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }

        public Note(Guid id,
            DateTime noteAdded,
            string userName,
            string content)
        {
            Id = id;
            NoteAdded = noteAdded.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            UserName = userName;
            Content = content;
        }
    }
}
