namespace Common.Exceptions
{
    public class ConfigurationException : Exception
    {
        public bool Fatal { get;}
        public const ExitCode ExitCode = Common.ExitCode.Error;

        public ConfigurationException(string message, bool fatal) : base(message)
        {
            Fatal = fatal;
        }
    }
}