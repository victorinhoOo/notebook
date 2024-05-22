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


    }
}
