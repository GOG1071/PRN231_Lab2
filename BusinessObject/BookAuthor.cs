namespace BusinessObject;

using System.ComponentModel.DataAnnotations;

public class BookAuthor
{
    [Required] public int    AuthorId          { get; set; }
    [Required] public int    BookId            { get; set; }
    [Required] public string AuthorOrder       { get; set; }
    [Required] public int    RoyaltyPercentage { get; set; }
}