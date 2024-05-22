using Logic;
using Logic.exceptions;

namespace TestLogicLayer
{
    public class TestExam
    {
        private Course GetCourse()
        {
            Course c = new Course(new FakeCourseDao(), true);
            c.Code = "T";
            c.Name = "Test";
            c.Weight = 10;
            return c;
        }
        [Fact]
        public void TestScoreOk()
        {
            Decimal score = new Decimal(15.5);
            var exam = new Exam(GetCourse());
            exam.Score = score;
            Assert.Equal(score, exam.Score);
        }

        [Fact]
        public void TestBadScore()
        {
            var exam = new Exam(GetCourse())    ;
            Assert.Throws<BadScoreValueException>(() => exam.Score = -1);
            Assert.Throws<BadScoreValueException>(() => exam.Score = 21);
        }

        [Fact]
        public void TestDate()
        {
            var exam = new Exam(GetCourse());
            var date = DateTime.Now.AddDays(-1);
            exam.DateExam = date;
            Assert.Equal(date, exam.DateExam);
            exam.DateExam = DateTime.Now;
            Assert.NotNull(exam.DateExam);
        }

        [Fact]
        public void TestDateNull()
        {
          var exam = new Exam(GetCourse());
          Assert.Throws<NullDateExamException>(() => exam.DateExam = null);
        }

        [Fact]
        public void TestDateFuture()
        {
            var exam = new Exam(GetCourse());
            var date = DateTime.Now.AddDays(1);
            Assert.Throws<DateExamInFutureException>(() => exam.DateExam = date);
        }

        [Fact]
        public void TestCoef()
        {
            var exam = new Exam(GetCourse());
            var coef = 43;
            exam.Coef = coef;
            Assert.Equal(coef, exam.Coef);  
        }

        [Fact]
        public void TestBadCoef()
        {
            var exam = new Exam(GetCourse() );            
            Assert.Throws<BadWeightException>(() => exam.Coef = 0);
            Assert.Throws<BadWeightException>(() => exam.Coef = 102);
        }

        [Fact]
        public void TestToString()
        {
            Course c = new Course(new FakeCourseDao(), true);
            c.Code = "R2.01";
            c.Name = "POO";
            c.Weight = 20;

            Exam e = new Exam(c);
            e.DateExam = new DateTime(2000, 01, 15);
            e.Coef = 1;
            e.Teacher = "toto";
            e.Score = new Decimal(12.5) ;

            Assert.Equal("15/01/2000 - R2.01 - 12,5/20 (1)", e.ToString());
        }

        [Fact]
        public void TestEquals()
        {
            Course c = new Course(new FakeCourseDao(), true);
            c.Code = "R2.01";
            c.Name = "POO";
            c.Weight = 20;

            Exam e = new Exam(c);
            e.DateExam = new DateTime(2000, 01, 15);
            e.Coef = 1;
            e.Teacher = "toto";
            e.Score = new Decimal(12.5);

            Exam e2 = new Exam(c);
            e2.DateExam = new DateTime(2000, 01, 15);
            e2.Coef = 1;
            e2.Teacher = "toto";
            e2.Score = new Decimal(12.5);

            Assert.Equal(e, e2);
            e2.Teacher = "other";
            Assert.NotEqual(e, e2);
        }
    }
}
