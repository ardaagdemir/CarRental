using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
            //Defaul constructor
        }

        //Base default' u true'dur.
        public ErrorResult(string message) : base(false, message)
        {

        }
    }
}
