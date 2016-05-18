//
// ILogListener.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//
        
using System;

namespace XDotNet.Diagnostics
{
    public interface ILogListener
    {
        void Write(LogLevel logLevel, string message);
        void Write(Exception ex);
    }
}
