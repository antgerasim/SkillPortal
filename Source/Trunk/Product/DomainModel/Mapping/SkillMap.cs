using FluentNHibernate.Mapping;

namespace DomainModel.Mapping
{
    public class SkillMap : ClassMap<Skill>
    {
        public SkillMap()
        {
            Table("Skills");
            Id(x => x.Id, "Id")
                .GeneratedBy.GuidComb() //.Assigned()
                .UnsavedValue("00000000-0000-0000-0000-000000000000");
            //Version(x => x.Version).Column("Version");

            References(x => x.Employee)
                .Column("EmployeeId");
            //.Not.Nullable()
            //.Cascade.All();

            References(x => x.SkillType)
                .Column("SkillTypeId");
            //.Not.Nullable()
            //.Cascade.All();
        }
    }
}