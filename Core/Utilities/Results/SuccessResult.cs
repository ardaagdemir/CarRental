using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //base--->Result
        //true durumu default olmuş oldu
        //verildiği metotta yalnızca true olarak çalışır (metodun true olduğunu belirtir)
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string message) : base(true,message)
        {
        }
    }
}
