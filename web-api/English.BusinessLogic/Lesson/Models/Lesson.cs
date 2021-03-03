﻿using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class Lesson
    {
        public Lesson()
        {
            this.Exercises = new List<Exercise>();
        }

        public int Id { get; set; }

        public IList<Exercise> Exercises { get; set; }
    }
}
