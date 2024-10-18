﻿using SOLIDHomework.Core.Services;
using System;
using System.IO;

namespace SOLIDHomework.Core
{
    public class MyLogger : ILogger
    {
        private readonly string filePath;
        public MyLogger()
        {
            filePath = Path.Combine(Environment.CurrentDirectory, "app.log");
        }
       
        private void Write(string text)
        {
            using (Stream file = File.OpenWrite(filePath))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(text);
                }
            }
        }

        public void LogInformation(string message)
        {
            Write($"INFO: {message}");
        }
       
        public void LogDebug(string message)
        {
            Write($"DEBUG: {message}");
        }
       
        public void LogError(string message)
        {
            Write($"ERROR: {message}");
        }
    }
}
