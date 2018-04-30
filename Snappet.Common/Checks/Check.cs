using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Common.Checks
{
    public static class Check
    {
        public static void That(bool conditionTest, string message)
        {
            if (!conditionTest)
                throw new CheckException(message);
        }

        private class CheckException : Exception
        {
            public CheckException(string message) : base(message)
            {
            }
        }
    }    
}
