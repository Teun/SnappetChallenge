using System;

namespace Snappet.Borisov.Test.Domain
{
    public interface IProvideDateTime
    {
        DateTimeOffset Now();
    }
}