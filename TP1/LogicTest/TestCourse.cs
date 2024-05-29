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

        [Fact]
        public void TestSaveUpdate()
        {
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, true);
            test.Code = "T";
            test.Name = "Test";
            test.Weight = 1;
            test.Save();
            Assert.Equal("Update", dao.LastAction);
            Assert.Equal(test, dao.LastCourse);
        }

        [Fact]
        public void TestSaveCreate()
        {
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, false);
            test.Code = "T";
            test.Name = "Test";
            test.Weight = 1;
            test.Save();
            Assert.Equal("Create", dao.LastAction);
            Assert.Equal(test, dao.LastCourse);
        }

        [Fact]
        public void TestComputeAverage()
        {
            FakeCourseDao dao = new FakeCourseDao();
            Course test = new Course(dao, true);
            test.Code = "T";          
            test.Name = "test";
            test.Weight = 1;
            Exam e1 = new Exam(test);
            e1.Score = new decimal(11.5);
            e1.Coef = 2;
            Exam e2 = new Exam(test);
            e2.Score = 14;
            e2.Coef = 3;
            Course other = new Course(dao, true);
            other.Code = "o";
            other.Name = "other";
            other.Weight = 10;
            Exam e3 = new Exam(other);
            e3.Score = 18;
            e3.Coef = 10;
            Exam[] exams = new Exam[] { e1, e2, e3 };
            double? average = test.ComputeAverage(exams);
            Assert.NotNull(average);
            double computed = (11.5 * 2 + 14 * 3) / 5;
            Assert.Equal(computed, average.Value, 6);
        }

    }
}