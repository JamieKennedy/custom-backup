namespace Common.Models
{
    public class Options
    {
        public const string OPTIONS_SECTION_NAME = "BackupOptions";

        public List<string>? Paths { get; init; } = null;
    }
}