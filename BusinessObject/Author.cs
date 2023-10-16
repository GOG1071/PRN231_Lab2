namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author : IModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FirstName    { get; set; }
    [Required] public string LastName     { get; set; }
    [Required] public string Phone        { get; set; }
    [Required] public string EmailAddress { get; set; }
    [Required] public string Address      { get; set; }
    [Required] public string City         { get; set; }
    [Required] public string State        { get; set; }
    [Required] public string Zip          { get; set; }
}