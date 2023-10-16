namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User : IModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string MiddleName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Source { get; set; }
    [Required] public int RoleId { get; set; }
    [Required] public string PublisherId { get; set; }
    [Required] public DateTime HireDate { get; set; }
}