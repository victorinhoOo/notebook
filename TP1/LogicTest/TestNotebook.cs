using Logic;

namespace TestLogicLayer
{
    public class TestNotebook
    {
        [Fact]
        public void TestGetAllCourses()
        {
            var dao = new FakeCourseDao();
            var eDao = new FakeExamDao();
            var list = dao.ListAll();
            var notebook = new Notebook(dao, eDao);
            var test = notebook.GetCourses();

            Assert.Equal(list, test);
        }

        [Fact]
        public void TestRemoveCourse()
        {
            var dao = new FakeCourseDao();
            var eDao = new FakeExamDao();
            var notebook = new Notebook(dao, eDao);
            var course = new Course(dao, true);
            course.Code = "T";
            course.Name = "Test";
            course.Weight = 1;
            notebook.RemoveCourse(course);
            Assert.Equal("Delete", dao.LastAction);
            Assert.Equal(course, dao.LastCourse);
        }

        [Fact]
        public void TestCreateCourse()
        {
            var dao = new FakeCourseDao();
            var eDao = new FakeExamDao();
            var notebook = new Notebook(dao, eDao);
            var course = notebook.CreateCourse();
            Assert.NotNull(course);
            course.Save();
            Assert.Equal("Create", dao.LastAction);
            Assert.Equal(course, dao.LastCourse);
        }

        [Fact]
        public void TestComputeAverage()
        {
            var examDao = new FakeExamDao();
            var courseDao = new FakeCourseDao();
            var notebook = new Notebook(courseDao, examDao);
            double? average = notebook.ComputeAverage();
            Assert.NotNull(average);
            double r203 = (12 * 1 + 0 * 10) / 11.0;
            double r201 = 10.0;
            double total = (r201 * 5 + r203 * 3) / 8;
            Assert.Equal(total, average.Value, 5);
        }


    }
}
