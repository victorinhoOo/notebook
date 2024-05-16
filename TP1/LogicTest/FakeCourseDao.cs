using Logic;
namespace TestLogicLayer
{
    internal class FakeCourseDao : ICourseDao
    {
        private Course? lastCourse;
        private string? lastAction;

        public Course? LastCourse => lastCourse;
        public string? LastAction => lastAction;

        public void Create(Course course)
        {
            lastCourse = course;
            lastAction = "Create";
        }

        public void Delete(Course course)
        {
            lastCourse = course;
            lastAction = "Delete";
        }

        public Course[] ListAll()
        {            
            Course c1 = new Course(this, true);
            c1.Code = "R2.01";
            c1.Name = "POO";
            c1.Weight = 5;
            Course c2 = new Course(this, true);
            c2.Code = "R2.02";
            c2.Name = "IHM";
            c2.Weight = 3;
            Course c3 = new Course(this, true);
            c3.Code = "R2.03";
            c3.Name = "Qualité";
            c3.Weight = 2;

            return new Course[] { c1, c2, c3 };
        }

        public Course Read(string code)
        {
            Course c = new Course(this, false);
            c.Code = code;
            c.Name = "toto";
            c.Weight = 1;
            lastCourse = c;
            lastAction = "Read";
            return c;
        }

        public void Update(Course course)
        {
            lastAction = "Update";
            lastCourse = course;
        }
    }

 
}
