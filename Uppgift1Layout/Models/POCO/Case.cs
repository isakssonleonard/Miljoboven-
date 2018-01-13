using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Uppgift1Layout.Models.POCO;

namespace Uppgift1Layout.Models
{
    // denna klass hanterar case object och validering
    public class Case
    {
        public int ID { get; set; }
        public string RefNumber { get; set; }
        [Display(Name = "Var har brottet skett någonstans?")]
        [Required(ErrorMessage = "Du måste skriva in på vilken plats brottet begicks")]
        public string Place { get; set; }
        [Display(Name = "Vilken typ av brott?")]
        [Required(ErrorMessage = "Du måste skriva in på vilken typ av brott det var")]
        public string TypeofCrime { get; set; }
        [Display(Name = "När skedde brottet?")]
        [Required(ErrorMessage = "Du måste skriva in vilken tid brottet skedde")]
        [DisplayFormat(DataFormatString = @"{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeOfObservation { get; set; }
        [Display(Name = "Beskriv din observation ex.namn på misstänkt person:")]
        public string Observation { get; set; }
        public string Info { get; set; }
        public string Action { get; set; }
        [Display(Name = "Ditt namn (för- och efternamn):")]
        [Required(ErrorMessage = "Du måste skriva in ditt förnamn och efternamn")]
        public string InformerName { get; set; }
        [Display(Name = "Din telefon:")]
        [RegularExpression(pattern: @"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$", ErrorMessage = "Nummret är inte giltigt ex det ska vara xxxx-xxxxxxxxx")]
        public string InformerPhone { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public string Employee { get; set; }
        public ICollection<Sample> Samples { get; set; } 
        public ICollection<Picture> Pictures { get; set; }
    }
}