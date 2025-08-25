﻿using TrendyolSln.Domain.Common;

namespace TrendyolSln.Domain.Entities
{
    public class Category:EntityBase,IEntityBase
    {
        public Category() { }
        public Category( int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }
        public int ParentId { get; set; }
        public string Name { get; set; } 
        public  int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
