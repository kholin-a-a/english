﻿using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public Task Create()
        {
            return Task.CompletedTask;
        }

        public Task<Lesson> GetLessonWithMaxNumber()
        {
            return Task.FromResult(new Lesson
            {
                Id = 12,
                Number = 123
            });
        }
    }
}