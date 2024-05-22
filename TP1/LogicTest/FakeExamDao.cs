using Logic;

namespace TestLogicLayer
{
    class FakeExamDao : IExamDAO
    {
        private string? lastAction;
        private Exam? lastExam;

        public string? LastAction => lastAction;
        public Exam? LastExam => lastExam;

        public void Create(Exam exam)
        {
            lastAction = "Create";
            lastExam = exam;
        }

        public Exam[] ListAll()
        {
            FakeCourseDao courseDao = new FakeCourseDao();
            Course[] courses = courseDao.ListAll();
            
            Exam e1 = new Exam(courses[0]);
            e1.DateExam = DateTime.Now.AddDays(-1);
            e1.Score = 10;
            e1.Coef = 1;
            e1.Teacher = "toto";

            Exam e2 = new Exam(courses[1]);
            e2.DateExam = DateTime.Now;
            e2.Score = 12;
            e2.Coef = 1;
            e2.Teacher = "toto";

            Exam e3 = new Exam(courses[1]);
            e3.DateExam = DateTime.Now;
            e3.Score = 0;
            e3.Coef = 10;
            e3.Teacher = "bob";


            lastAction = "List";
            lastExam = null;

            return new Exam[] { e1,e2,e3 };
        }
    }
}
