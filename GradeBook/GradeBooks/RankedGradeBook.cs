using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
     
        }


        public override char GetLetterGrade(double averageGrade)
        {
         
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            }

           int X = (int)(Math.Ceiling(Students.Count * 0.2));

            var grades = Students.OrderByDescending(o => o.AverageGrade).Select(o => o.AverageGrade).ToList();

            if (grades[X - 1] <= averageGrade)
                return 'A';
            else if (grades[(X * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(X * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(X * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';

            return base.GetLetterGrade(averageGrade);


        }


    }
}
