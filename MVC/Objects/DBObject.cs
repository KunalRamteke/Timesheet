using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Objects
{
    public abstract class DBObject
    {
        public Guid Id { get; set; }
        public string ObjType { get; set;}
        public DBObject(string ObjType) 
        {
            this.ObjType = ObjType;
            Id = Guid.NewGuid();
        }
    }
}