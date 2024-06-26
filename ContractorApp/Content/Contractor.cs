//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContractorApp.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Contractor
    {
        public int ContractorID { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [DisplayName("Last Name")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        [DisplayName("First Name")]
        public string Fname { get; set; }
        public string Phone { get; set; }
        [DisplayName("Program")]
        public Nullable<int> ProgramID { get; set; }
        [DisplayName("Supervisor")]
        public Nullable<int> SupervisorID { get; set; }
        [DisplayName("Employer")]
        public Nullable<int> EmployerID { get; set; }
        [DisplayName("Location")]
        public Nullable<int> LocationID { get; set; }
        public bool Active { get; set; }
        [DisplayName("Work Email")]
        public string work_email { get; set; }
        [DisplayName("Personal Email")]
        public string personal_email { get; set; }
        public Nullable<int> InstitutionID { get; set; }
    
        public virtual Employer Employer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Program Program { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
