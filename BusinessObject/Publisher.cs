namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publisher : IModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string PublisherName { get; set; }
    [Required] public string City          { get; set; }
    [Required] public string State         { get; set; }
    [Required] public string Country       { get; set; }
}