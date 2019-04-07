using System;

namespace RReporter.Framework
{
    public interface ITimeProvider 
    {
        DateTime CurrentUtcTime {get;}
    }

 }