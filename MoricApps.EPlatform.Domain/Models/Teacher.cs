﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MoricApps.EPlatform.Teachers.Domain.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public TeacherStatus Status { get; set; } = TeacherStatus.Active;

        public virtual ICollection<TeacherAssigment> Assigments { get; set; } = new List<TeacherAssigment>();

        public Teacher(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

        }
        public void Disactivate()
        {
            Status = TeacherStatus.Inactive;
        }


    }
}
