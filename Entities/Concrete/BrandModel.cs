using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class BrandModel : IEntity
    {
        public int BrandModelId { get; set; }
        public int BrandId { get; set; }
        public string BrandModelName { get; set; }
    }
}
