using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift1Layout.Models.POCO
{
    public class Picture
    {
        public int PictureID { get; set; }
        public string PictureName { get; set; }
        [ForeignKey("ID")]
        public int CaseID { get; set; }
    }
}
