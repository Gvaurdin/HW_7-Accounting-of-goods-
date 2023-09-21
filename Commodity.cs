using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7_Accounting_of_goods_
{
    abstract class Commodity
    {
        public static int ID { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get;protected set; }
        public string Description { get; set; }

        public Commodity(string description,string name,double weight, double price, int count )
        {
            Name = name;
            Price = price;
            Count = count;
            Description = description;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Description,-25}{Name,-17}{Weight,-10}{Price,-10}{Count,-10}";
        }
    }
}
