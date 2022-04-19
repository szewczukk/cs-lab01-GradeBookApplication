using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base (name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentCount = Students.Count;

            if (studentCount < 5)
            {
                throw new InvalidOperationException();
            }

            var betterStudents = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    betterStudents++;
                }
            }
            
            var betterStudentsPercentage = (float)betterStudents / studentCount;
            if (betterStudentsPercentage <= 0.2)
            {
                return 'A';
            }
            if (betterStudentsPercentage > 0.2 && betterStudentsPercentage <= 0.4)
            {
                return 'B';
            }
            if (betterStudentsPercentage > 0.4 && betterStudentsPercentage <= 0.6)
            {
                return 'C';
            }
            if (betterStudentsPercentage > 0.6 && betterStudentsPercentage <= 0.8)
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
    }
}
