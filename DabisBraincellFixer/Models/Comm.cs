using System.ComponentModel.DataAnnotations;

namespace DabisBraincellFixer.Models;
public class Comm
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Message { get; set; }
    [Required]
    public string? Response { get; set; }
}
