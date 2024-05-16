using Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Gére les cours stockés dans une base de données SQLite.
    /// </summary>
    public class CourseDaoSqlite: ICourseDao
    {
        private SQLiteConnection connection;
        public CourseDaoSqlite(string fileName)
        {
            connection = new SQLiteConnection(@"DataSource=" + fileName);
            connection.Open();
        }

        public void Create(Course course)
        {
            throw new NotImplementedException();
        }

        public void Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public Course[] ListAll()
        {
            throw new NotImplementedException();
        }

        public Course Read(string code)
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
