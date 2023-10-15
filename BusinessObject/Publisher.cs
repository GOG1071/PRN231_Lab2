namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publisher
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PublisherId { get; set; }

    [Required] public string PublisherName { get; set; }
    [Required] public string City          { get; set; }
    [Required] public string State         { get; set; }
    [Required] public string Country       { get; set; }
}