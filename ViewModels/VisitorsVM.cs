﻿using System.ComponentModel.DataAnnotations;

using VisitorManagementStudent2022.Models;

namespace VisitorManagementStudent2022.ViewModels
{
    public class VisitorsVM
    {
        public Guid Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string? Business { get; set; }
        [Display(Name = "Visit Date In")]
        
        public DateTime? DateIn { get; set; }
        [Display(Name = "Visit Date Out")]
        public DateTime? DateOut { get; set; }

        //navigation
        [Display(Name = "Staff Person Visited")]
        public Guid StaffNameId { get; set; }
        
        [Display(Name = "Staff Person Visited")]
        public StaffNames? StaffName { get; set; }

    }
}
