using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            //Created a unique name for each file
            return Guid.NewGuid().ToString(); 
        }
    }
}
