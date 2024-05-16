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

       
    }
}
