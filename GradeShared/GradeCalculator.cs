using GradeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeShared
{
    public class GradeCalculator
    {
        public IEnumerable<Grading> Gradings { get; set; }

        public string GetGradeByScore(int score)
        {
            var isScoreValid = score >= 0 && score <= 100;
            if (!isScoreValid)
            {
                throw new ArgumentException();
            }

            var result = Gradings
                .OrderByDescending(it => it.MinScore)
                .FirstOrDefault(it => score >= it.MinScore);
            return result.Grade;
        }
    }
}
