using FluentNHibernate.Mapping;

namespace DomainModel.Mapping
{
    public class SkillTypeMap : ClassMap<SkillType>
    {
        public SkillTypeMap()
        {
            Table("SkillTypes");
            Id(x => x.Id, "Id")
                .GeneratedBy.GuidComb()//Assigned()
                .UnsavedValue("00000000-0000-0000-0000-000000000000");
            //Version(x => x.Version).Column("Version");

           
        }
    }
}