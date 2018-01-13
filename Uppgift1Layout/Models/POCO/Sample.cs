using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift1Layout.Models.POCO
{
    public class Sample
    {
        public int SampleID { get; set; }
        public string SampleName { get; set; }
        [ForeignKey("ID")]
        public int CaseID { get; set; }
    }
}
