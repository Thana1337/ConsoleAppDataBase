

using System.ComponentModel.DataAnnotations;

namespace ConsoleAppDataBase.Entities;

internal class AddressEntity
{
    [Key]
    public int Id { get; set; }
    public string City { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}
