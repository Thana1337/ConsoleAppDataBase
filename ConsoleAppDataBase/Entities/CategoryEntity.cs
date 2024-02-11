
using System.ComponentModel.DataAnnotations;


namespace ConsoleAppDataBase.Entities;

internal class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

}
