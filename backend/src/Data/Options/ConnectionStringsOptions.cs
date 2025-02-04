using System.ComponentModel.DataAnnotations;

namespace Versta.OrderPlacement.Data.Options;

public sealed class ConnectionStringsOptions
{
    public static readonly string OptionKey = "ConnectionStrings";

    [Required]
    public string? DbConnection { get; set; }
}
