﻿using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class UnassignCourseFromInstructor : CommandBase 
    {

        public Guid InstructorId { get; private set; }
        public Guid CourseId { get; private set; }

        public UnassignCourseFromInstructor(Guid instructorId, Guid courseId)
        {
            InstructorId = instructorId;
            CourseId = courseId;
        }

    }

}