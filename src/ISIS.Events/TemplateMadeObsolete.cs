﻿using System;

namespace ISIS.Events
{
    public class TemplateMadeObsolete
    {

        public Guid TemplateId { get; private set; }

        public TemplateMadeObsolete(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}