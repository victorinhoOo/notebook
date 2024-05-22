using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Représente un carnet utilisant un DAO pour les opérations de base de données.
    /// </summary>
    public class Notebook
    {
        private ICourseDao cDao;
        private IExamDAO eDao;
        public Notebook(ICourseDao cdao, IExamDAO eDAO)
        {
            this.cDao = cdao;
            this.eDao = eDAO;
        }

        /// <summary>
        /// Affiche la liste des cours du carnet
        /// </summary>
        /// <returns>Liste des cours</returns>
        public Course[] GetCourses()
        {
            return this.cDao.ListAll();
        }

        /// <summary>
        /// Supprime un cours du carnet
        /// </summary>
        /// <param name="course">Cours à supprimer</param>
        public void RemoveCourse(Course course)
        {
            cDao.Delete(course);
        }

        /// <summary>
        /// Créé un cours vide qui n'existe pas encore dans le SGBD
        /// </summary>
        /// <returns>cours créé</returns>
        public Course CreateCourse()
        {
            return new Course(cDao, false);
        }

        /// <summary>
        /// Créé un examen dans le carnet
        /// </summary>
        /// <param name="course">Cours de l'examen à créé</param>
        public void CreateExamen(Exam exam)
        {
            eDao.Create(exam);
        }

        /// <summary>
        /// Affiche la liste des examens du carnet
        /// </summary>
        /// <returns>Liste des examens</returns>
        public Exam[] GetExams()
        {
            return this.eDao.ListAll();
        }

    }
}
