using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Entities.Abstract;

namespace Entities.Concerete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
