using System.ComponentModel.DataAnnotations;

namespace Versta.OrderPlacement.Data.Options;

public sealed class DatabaseProviderOptions
{
    public static readonly string OptionKey = "Database";

    public enum DataProvider
    {
        Psql
    }

    [Required]
    public DataProvider? Provider { get; set; }
}
