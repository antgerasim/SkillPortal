using System;
using Proteus.Domain.Foundation;

namespace DomainModel
{
    public class Skill : IdentityPersistenceBase<Skill, Guid, string>
    {
        private Employee _employee;
        private SkillType _skillType;

        public virtual Guid Id
        {
            get { return _persistenceId; }
            set { _persistenceId = value; }
        }

        public virtual Employee Employee
        {
            get { return _employee; }

            set { _employee = value; }
        }

        public virtual SkillType SkillType
        {
            get { return _skillType; }
            set { _skillType = value; }
        }

        
    }
}