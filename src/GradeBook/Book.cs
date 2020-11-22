using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public Book(int x)
        {
            this.x = x;
        }


        /*
        public void AddLetterGrade(char letter) //Switch is like using Else If (elif) statements. 
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break; // u have to break otherwise the line of code will continue to execute the next line
                
                case 'B':
                    AddGrade(80);
                    break;
                
                case 'C':
                    AddGrade(70);
                    break;
                
                default: //adding defeault as an else statement to take care of other inputs ('D', 'E', etc.)
                    AddGrade(0);
                    break;
            }
        }
        */






        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            /*
            var index = 0;
            do // with 'do while' loop the loop will always execute the block of code at least once because it won't check the condition until it reaches the end of ('while') the block o code
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1; // adding 1 everytime when we loop through the index
            }while(index < grades.Count); // make sure that length of our index size has not been exceeded

            result.Average /= grades.Count;
            
            return result;
            */
        
            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            //here 'Average' can be changed with 'High' or 'Low'
            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;    
            }
            
            return result;
        }

        
        private List<double> grades;
        public string Name;
        private int x;
    }

}