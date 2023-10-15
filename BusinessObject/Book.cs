namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    [Required] public string   Title         { get; set; }
    [Required] public string   Type          { get; set; }
    [Required] public int      PublisherId   { get; set; }
    [Required] public decimal  Price         { get; set; }
    [Required] public string   Advance       { get; set; }
    [Required] public decimal  Royalty       { get; set; }
    [Required] public int      YtdSales      { get; set; }
    [Required] public string   Notes         { get; set; }
    [Required] public DateTime PublishedDate { get; set; }
}