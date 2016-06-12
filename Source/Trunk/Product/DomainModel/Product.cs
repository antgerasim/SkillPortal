using System;
using Proteus.Domain.Foundation;

namespace DomainModel
{
    public class Product :IdentityPersistenceBase<Product,int,string>
    {
        public virtual int Id
        {
            get { return _persistenceId; }
            set { _persistenceId = value; }
        }
        //public virtual int Version
        //{
        //    get { return _persistenceVersion; }
        //    set { _persistenceVersion = value; }
        //}
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool Discontinued { get; set; }
  
    }
}