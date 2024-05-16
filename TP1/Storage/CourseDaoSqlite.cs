using Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Course Reader2Course(SQLiteDataReader reader)
        {
            Course course = new Course(this, true);
            course.Code = reader["Code"].ToString();
            course.Name = reader["Name"].ToString();
            course.Weight = Convert.ToInt32(reader["Weight"]);
            return course;
        }

        public void Create(Course course)
        {
            throw new NotImplementedException();
        }

        public void Delete(Course course)
        {
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Course WHERE Code = @Code";
            command.Parameters.AddWithValue("@Code", course.Code);
            command.ExecuteNonQuery();

        }

        public Course[] ListAll()
        {
            List<Course> courses = new List<Course>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Course";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(Reader2Course(reader));
                }
            }
            return courses.ToArray();
        }

        public Course Read(string code)
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE Course SET Name='{course.Name}',Weight ={ course.Weight} WHERE Code = '{course.Code}'";
            command.ExecuteNonQuery();
        }
    }
}
