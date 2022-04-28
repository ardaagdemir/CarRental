﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
