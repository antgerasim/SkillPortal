using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace DomainModel.Mapping
{
    public class ProductMap :ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id, "Id").GeneratedBy.HiLo("1000");
            Map(x => x.Name);
            Map(x => x.Category);
            Map(x => x.Discontinued);
        }
    }
}