//
// DebugListener.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2016, Gabor Nemeth
//

using System;
using System.Diagnostics;

namespace XTools.Diagnostics
{
    /// <summary>
    /// <see cref="ILogListener"/> that uses System.Diagnostics.Debug
    /// </summary>
    public class DebugLogListener : ILogListener
    {
        public void Write(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        public void Write(LogLevel logLevel, string message)
        {
            Debug.WriteLine(message);
        }
    }
}
