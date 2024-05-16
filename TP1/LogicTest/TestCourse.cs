using Logic;
using Logic.exceptions;

namespace TestLogicLayer
{
    public class TestCourse
    {
        [Fact]
        public void TestCode()
        {
            string code = "R2.01";           
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao,true);
            test.Code = code;            
            Assert.Equal(code, test.Code);            
        }

        [Fact]
        public void TestBadCode()
        {
            string code = "  ";
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao,true);
            Assert.Throws<EmptyStringException>(() => test.Code = code);            
        }

        [Fact]
        public void TestName()
        {         
            string name = "Développement objet";
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao,true);
            test.Name = name;
            Assert.Equal(name,test.Name);            
        }

        [Fact]
        public void TestBadName()
        {            
            string name = "     ";
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao,false);
            Assert.Throws<EmptyStringException>(() => test.Name = name);            
        }

        [Fact]
        public void TestWeigth()
        {
            FakeCourseDao dao = new FakeCourseDao();            
            int weigth = 1;
            Course test = new Course(dao,true);
            test.Weight = weigth;
            Assert.Equal(weigth, test.Weight);            
        }

        [Fact]
        public void TestBadWeigth()
        {            
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao,false);
            Assert.Throws<BadWeightException>(() => test.Weight = 0);
            Assert.Throws<BadWeightException>(() => test.Weight = 105);
        }

     

        [Fact]
        public void TestCodeChange()
        {
            string code = "R2.01";
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, true);
            test.Code = code;
            Assert.Throws<CodeCannotChangeException>(() => test.Code = "autre");
        }

        [Fact]
        public void TestEquals()
        {
            string code = "R2.01";
            string name = "Développement objet";
            int weigth = 1;
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, true);
            test.Code = code;
            test.Name = name;
            test.Weight = weigth;

            Course other = new Course(dao, true);
            other.Code = code;
            Assert.Equal(test, other);

            other = new Course(dao, true);            
            other.Code = "R2.01bis";
            other.Name = name;
            other.Weight = weigth;
            Assert.NotEqual(other, test);
        }

        [Fact]
        public void TestToString()
        {
            string code = "R2.01";
            string name = "POO";
            int weigth = 12;
            string result = "R2.01-POO (12)";
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, true);
            test.Code = code;
            test.Name = name;
            test.Weight = weigth;
            Assert.Equal(result, test.ToString());
        }
        
    }
}