using FluentNHibernate.Mapping;

namespace DomainModel.Mapping
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb()
                //.GeneratedBy.Assigned()
                .UnsavedValue("00000000-0000-0000-0000-000000000000");
            Version(x => x.Version).Column("RowVersion").UnsavedValue("0");

            HasMany(x => x.Skills)
                .AsBag()
                .KeyColumn("EmployeeId")
                .Table("Skills")
                .Not.Inverse()
                .Cascade.All();
        }
    }
}