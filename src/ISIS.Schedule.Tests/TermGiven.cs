﻿using System;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TermGiven
    {

        [Given(@"I created a term ([^\s]*) ""(.*)"" from ([\d/]*) to ([\d/]*)")]
        public void GivenICreatedATerm(
            string abbreviation,
            string name,
            string startDateString,
            string endDateString)
        {
            var termId = DomainHelper.Id<Term>();
            var startDate = DateTime.Parse(startDateString);
            var endDate = DateTime.Parse(endDateString);
            var @event = new TermCreated(termId, abbreviation, name, startDate, endDate);
            DomainHelper.Given<Term>(@event);
        }

    }
}