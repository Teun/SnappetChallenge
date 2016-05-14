using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
	//This class just holds basic class information. Since the assignment gave no information regarding the class
	//we can assume that a class class (sorry, no pun intended ;) ) must exist but we know nothing about how it relates
	//to the submitted answers, so I am using this just to contain basic information to show on the dashboard.
	public class SchoolClass
	{
		public long ClassId { get; set; }
		public string ClassName { get; set; }
		public string TeacherName{ get; set; }
		public int NumberOfStudents { get; set; }

	}
}