using System;
using System.IO;

namespace lib_Equation
{
    public class LogFileWriter
    {
        public FileInfo LogFile { get; set; }
        public LogFileWriter(string filePath)
        {
            if (File.Exists(filePath))
                LogFile = new FileInfo(filePath);
        }
        public void WriteEquationToLog(string equationString)
        {
            if (LogFile != null && !LogFile.IsReadOnly)
                File.AppendAllText(LogFile.FullName, equationString + Environment.NewLine);
        }
        public void WriteIncorrectDataToLog(string incorrectData)
        {
            string recordToFile = $"Incorrect coefficient: {incorrectData}{Environment.NewLine}";
            if (LogFile != null && !LogFile.IsReadOnly)
                File.AppendAllText(LogFile.FullName, recordToFile);
        }
    }
}
