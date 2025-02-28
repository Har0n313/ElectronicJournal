namespace ElectronicJournal.Infrastructure.Dal.Models;

public class DataBaseSettings
{
    public string? ConnectionStrings { get; init; }
    public int CommandTimeout { get; init; }
}