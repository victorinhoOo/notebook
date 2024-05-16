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
        private ICourseDao dao;
        public Notebook(ICourseDao dao)
        {
            this.dao = dao;
        }

        /// <summary>
        /// Affiche la liste des cours du carnet
        /// </summary>
        /// <returns>Liste des cours</returns>
        public Course[] GetCourses()
        {
            return this.dao.ListAll();
        }

        /// <summary>
        /// Supprime un cours du carnet
        /// </summary>
        /// <param name="course">Cours à supprimer</param>
        public void RemoveCourse(Course course)
        {
            dao.Delete(course);
        }

    }
}
