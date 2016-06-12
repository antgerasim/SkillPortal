using NUnit.Framework;

namespace DomainModel.Tests
{
    [TestFixture]
    public class ClassTest
    {
        [Test]
        public void MustInjectSkillTypeWhenCreateNewSkill()
        {
            var skill = new Skill();
            skill.SkillType = new SkillType();
            Assert.IsNotNull(skill.SkillType);
        }

        [Test]
        public void EmployeeIsAssignedToSkillWhenSkillAddedToEmployee()
        {
            var emp = new Employee();
            emp.AddSkill(new Skill());

            //Assert.AreEqual(emp,emp.Skills[0].Employee);
            //Assert.AreSame(emp, emp.Skills[0].Employee);
            var b = emp.Equals(emp.Skills[0].Employee);
            Assert.IsTrue(emp.Equals(emp.Skills[0].Employee));

        }


    }
}