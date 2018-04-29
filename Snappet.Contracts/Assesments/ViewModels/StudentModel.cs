using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Result { get; set; }

        public StudentModel(int id, double result, string name= "")
        {
            Id = id;
            Result = result;
            Name = name;
        }
    }
}
