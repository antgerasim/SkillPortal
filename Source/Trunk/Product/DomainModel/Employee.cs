using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Proteus.Domain.Foundation;

namespace DomainModel
{
    public class Employee : IdentityPersistenceBase<Employee, Guid, string>
    {
        private IList<Skill> _skills = new List<Skill>();

        public virtual Guid Id
        {
            //Should be readonly, because we dont want anybody to set the ID, 
            //but in case of unit testing, we're going to inspect the Id
            get { return _persistenceId; }
            set { _persistenceId = value; }
        }

        //public virtual int Version
        //{
        //    get { return _persistenceVersion; }
        //}

        public virtual IList<Skill> Skills
        {
            get { return _skills.ToList().AsReadOnly(); }
        }

        public virtual void AddSkill(Skill skill)
        {
            try
            {
                skill.Employee = this;
                _skills.Add(skill);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}