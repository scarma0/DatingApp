using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]          // specify the table name
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public AppUser AppUser { get; set; }      // FULLY DEFINING THE RELATIONSHIP BETWEEN AppUser CLASS AND Photo CLASS
        public int AppUserId { get; set; }        // FULLY DEFINING THE RELATIONSHIP BETWEEN AppUser CLASS AND Photo CLASS
    }
}