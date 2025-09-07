

using System;
using System.Collections.Generic;
using System.Text;

namespace OptionalToursAPI.Common.Configuration
{

    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Jwt Jwt { get; set; }
        public CacheSettings CacheSettings { get; set; }
        public WindwardReports WindwardReports { get; set; }
        public FolderSettings FolderSettings { get; set; }
        public EmailSettings EmailSettings { get; set; }
    }

    public class Logging
    {
        public string IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
    }
    public class ConnectionStrings
    {
        public string TemplateDatabase { get; set; }
    }
    public class WindwardReports
    {
        public string license { get; set; }
        public string apiURL { get; set; }
    }
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }

    public class CacheSettings
    {
        public string AbsoluteExpiration { get; set; }
        public string SlidingExpiration { get; set; }
    }

    public class FolderSettings
    {
        public string PAInstanceInputFolder { get; set; }
    }

    public class EmailSettings
    {
        public string ServiceEmailID { get; set; }
        public string ServiceEmailPassword { get; set; }
        public string SMTPHostName { get; set; }
        public int SMTPPortNumber { get; set; }
    }
    public class ExcelMap
    {
        public string Name { get; set; }
        public string MappedTo { get; set; }
        public int Index { get; set; }
    }
}
