using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Basic voids
    public interface IResult
    {
        //Her projede geçerli olabilecek metotlar (başarı ve mesaj metotları)
        //get --> okunabilir
        bool Success { get; } 
        string Message { get; }
    }
}
