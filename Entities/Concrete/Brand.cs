using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
    }
}
