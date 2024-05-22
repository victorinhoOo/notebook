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
        private DatabaseSqlite db;
        public CourseDaoSqlite(DatabaseSqlite db)
        {
            this.db= db;
        }

        /// <inheritdoc/>
        private Course Reader2Course(SQLiteDataReader reader)
        {
            Course course = new Course(this, true);
            course.Code = reader["Code"].ToString();
            course.Name = reader["Name"].ToString();
            course.Weight = Convert.ToInt32(reader["Weight"]);
            return course;
        }

        /// <inheritdoc/>
        public void Create(Course course)
        {
            string commandText = "INSERT INTO Course (Code, Name, Weight) VALUES (@Code, @Name, @Weight);";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Code", course.Code),
                new SQLiteParameter("@Name", course.Name),
                new SQLiteParameter("@Weight", course.Weight)
            };
            db.ExecuteNonQuery(commandText, parameters);
        }

        /// <inheritdoc/>
        public void Delete(Course course)
        {
            string commandText = "DELETE FROM Course WHERE Code = @Code;";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Code", course.Code)
            };
            db.ExecuteNonQuery(commandText, parameters);
        }

        /// <inheritdoc/>
        public Course[] ListAll()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM Course";
            using (var reader = db.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    courses.Add(Reader2Course(reader));
                }
            }
            return courses.ToArray();
        }

        /// <inheritdoc/>
        public Course Read(string code)
        {
            string query = "SELECT * FROM Course WHERE Code = @Code;";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Code", code)
            };
            using (var reader = db.ExecuteQuery(query, parameters))
            {
                if (reader.Read())
                {
                    return Reader2Course(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public void Update(Course course)
        {
            string commandText = "UPDATE Course SET Name = @Name, Weight = @Weight WHERE Code = @Code;";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Name", course.Name),
                new SQLiteParameter("@Weight", course.Weight),
                new SQLiteParameter("@Code", course.Code)
            };
            db.ExecuteNonQuery(commandText, parameters);
        }
    }
}
