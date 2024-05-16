using Logic;

namespace TestLogicLayer
{
    public class TestNotebook
    {
        [Fact]
        public void TestGetAllCourses()
        {
            var dao = new FakeCourseDao();
            var list = dao.ListAll();
            var notebook = new Notebook(dao);
            var test = notebook.GetCourses();

            Assert.Equal(list, test);
        }

        [Fact]
        public void TestRemoveCourse()
        {
            var dao = new FakeCourseDao();
            var notebook = new Notebook(dao);
            var course = new Course(dao, true);
            course.Code = "T";
            course.Name = "Test";
            course.Weight = 1;
            notebook.RemoveCourse(course);
            Assert.Equal("Delete", dao.LastAction);
            Assert.Equal(course, dao.LastCourse);
        }


    }
}
