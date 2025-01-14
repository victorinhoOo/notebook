﻿using Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Gére les examens stockés dans une base de données SQLite.
    /// </summary>
    public class ExamDaoSqlite : IExamDAO
    {
        private DatabaseSqlite db;
        private ICourseDao courseDao;

        public ExamDaoSqlite(ICourseDao courseDao, DatabaseSqlite db)
        {
            this.courseDao = courseDao;
            this.db = db;
        }

        /// <inheritdoc/>
        public void Create(Exam exam)
        {
            string commandText = @"
                INSERT INTO Exam (DateExam, CourseCode, Score, Teacher, Coef)
                VALUES (@DateExam, @CourseCode, @Score, @Teacher, @Coef);";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@DateExam", exam.DateExam?.ToFileTime() ?? (object)DBNull.Value),
                new SQLiteParameter("@CourseCode", exam.Course.Code),
                new SQLiteParameter("@Score", exam.Score ?? (object)DBNull.Value),
                new SQLiteParameter("@Teacher", exam.Teacher),
                new SQLiteParameter("@Coef", exam.Coef)
            };

            db.ExecuteNonQuery(commandText, parameters);
        }

        /// <inheritdoc/>
        public Exam[] ListAll()
        {
            List<Exam> exams = new List<Exam>();
            string query = "SELECT DateExam, CourseCode, Score, Teacher, Coef FROM Exam";
            using (var reader = db.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    Exam exam = Reader2Exam(reader);
                    exams.Add(exam);
                }
            }
            return exams.ToArray();
        }

        private Exam Reader2Exam(SQLiteDataReader reader)
        {
            // on extracte les données depuis le reader
            DateTime dateExam = DateTime.FromFileTime(reader.GetInt64(0));
            string courseCode = reader.GetString(1);
            decimal? score = reader.IsDBNull(2) ? null : reader.GetDecimal(2);
            string teacher = reader.GetString(3);
            int coef = reader.GetInt32(4);


            // On créé l'examen en récupérant le cours correspondant à l'examen via le DAO courseDAO
            Exam exam = new Exam(courseDao.Read(courseCode))
            {
                DateExam = dateExam,
                Score = score,
                Teacher = teacher,
                Coef = coef
            };

            return exam;
        }


    }
}
