using NUnit.Framework;

namespace DomainModel.Tests
{
    [TestFixture]
    public class EmployeeTests
    {

        [Test]
        public void CanCreateEmployeeWithDefaultConstructor()
        {
            var e = new Employee();

            Assert.IsNotNull(e);
        }

        [Test]
        public void CanAddSkillToEmployee()
        {
            var emp = new Employee();
            var skill = new Skill();
            emp.AddSkill(skill);

            Assert.IsNotNull(emp.Skills);
        }

        [Test]
        public void SkillPropertyIsReadonly()
        {
            var emp = new Employee();
            
            emp.AddSkill(new Skill());

            var skills = emp.Skills;

            Assert.IsTrue(skills.IsReadOnly);
        }
    }
}