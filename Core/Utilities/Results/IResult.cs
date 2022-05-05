using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Basic voids
    public interface IResult
    {
        //get --> okunabilir
        bool Success { get; } 
        string Message { get; }
    }
}
