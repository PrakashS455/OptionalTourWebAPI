using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PAMAPI.Common.Helpers
{
    public class TextWriter
    {
        public static void SaveLogFile(string logText,string fileName,string logFolderPath)
        {

            var fileNameWithTime = GenerateNewLogFile(fileName.Trim());
            var fileFullPath = logFolderPath.Trim();
            try
            {
                if (!Directory.Exists(fileFullPath))
                {
                    Directory.CreateDirectory(fileFullPath);
                }
                fileFullPath = $"{fileFullPath.TrimEnd('\\')}\\{fileNameWithTime.TrimStart('\\')}";

                if (!File.Exists(fileFullPath))
                {
                    using var sw = File.CreateText(fileFullPath);
                }
                File.AppendAllText(fileFullPath, logText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GenerateNewLogFile(string fileNamePreFix)
        {
            fileNamePreFix = $"{fileNamePreFix}-{DateTime.Now:yyyy-MM-ddTHHmmss}.txt";
            return fileNamePreFix;
        }
    }
}
