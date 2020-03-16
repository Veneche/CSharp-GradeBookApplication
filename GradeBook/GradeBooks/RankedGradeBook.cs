using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public int X = 0;

        public double LowestForA { get; set; }
        public double LowestForB { get; set; }
        public double LowestForC { get; set; }
        public double LowestForD { get; set; }


        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
            X = numStudentsBeforeDrop(Students.Count);
            //Students.Sort((x, y) => x.AverageGrade.CompareTo(y.AverageGrade));
            List<Student> SortedList = Students.OrderByDescending(o => o.AverageGrade).ToList();
            

        }

        public int numStudentsBeforeDrop(int totStudents)
        {
            var result = (int)(totStudents * 20 / 100);

            return (result);
        }




        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw InvalidOperationException();
            }
            else
            {
                int count = 0;
                int numDropped = 0;

                for (int i = 0; i< Students.Count; i++)
                {
                    if (averageGrade < Students[i].AverageGrade)
                    {
                        count += 1;
                    }

                    if (count == X)
                    {
                        numDropped += 1;
                        count = 0;
                    }


                }

                if (numDropped == 0)
                    return 'A';
                else if (numDropped == 1)
                    return 'B';
                else if (numDropped == 2)
                    return 'C';
                else if (numDropped == 3)
                    return 'D';
                else
                    return 'F';



            }
            
        }

        private Exception InvalidOperationException()
        {
            throw new NotImplementedException();
        }
    }
}
