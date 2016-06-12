using System;
using Proteus.Domain.Foundation;

namespace DomainModel
{
    public class SkillType:IdentityPersistenceBase<SkillType,Guid,String>
    {
        public virtual Guid Id
        {
            get { return _persistenceId; }
            set { _persistenceId = value; }
        }
    }
}