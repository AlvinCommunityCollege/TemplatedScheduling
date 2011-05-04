﻿using System;
using ISIS.Scheduling.CreateTemplateExceptions;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Template : AggregateRootMappedByConvention
    {

        private TemplateStatuses _status;
        private string _label;
        private bool _isContinuingEducation;

        private Template()
        {
        }

        public Template(Guid templateId, string label, Course course)
            : base(templateId)
        {
            var courseData = course.GetCourseData();

            if (string.IsNullOrEmpty(courseData.Title))
                throw new CourseMissingTitleException();
            
            if (string.IsNullOrEmpty(courseData.Description))
                throw new CourseMissingDescriptionException();

            var @event = new TemplateCreated(
                EventSourceId,
                label,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber,
                courseData.Title,
                courseData.Description,
                courseData.IsContinuingEducation);
            ApplyEvent(@event);
        }

        public void Rename(string newLabel)
        {
            if (_label != newLabel)
                ApplyEvent(new TemplateRenamed(EventSourceId, _label, newLabel));
        }

        public void Activate()
        {
            if (_status != TemplateStatuses.Activated)
                ApplyEvent(new TemplateActivated(EventSourceId));
        }

        public void MakePending()
        {
            if (_status != TemplateStatuses.Pending)
                ApplyEvent(new TemplateMadePending(EventSourceId));
        }

        public void Deactivate()
        {
            if (_status != TemplateStatuses.Deactivated)
                ApplyEvent(new TemplateDeactivated(EventSourceId));
        }

        public void MakeObsolete()
        {
            if (_status != TemplateStatuses.Obsolete)
                ApplyEvent(new TemplateMadeObsolete(EventSourceId));
        }
        
        protected void On(TemplateCreated @event)
        {
            _label = @event.Label;
            _isContinuingEducation = @event.IsContinuingEducation;
        }

        protected void On(TemplateRenamed @event)
        {
            _label = @event.NewLabel;
        }

        protected void On(TemplateActivated @event)
        {
            _status = TemplateStatuses.Activated;
        }

        protected void On(TemplateMadePending @event)
        {
            _status = TemplateStatuses.Pending;
        }

        protected void On(TemplateDeactivated @event)
        {
            _status = TemplateStatuses.Deactivated;
        }

        protected void On(TemplateMadeObsolete @event)
        {
            _status = TemplateStatuses.Obsolete;
        }
        
    }
}