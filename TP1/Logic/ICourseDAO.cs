using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Définit les opérations de base de données pour les cours
    /// </summary>
    public interface ICourseDao
    {
        /// <summary>
        /// Crée un nouveau cours dans la base de données.
        /// </summary>
        /// <param name="course">Cours à créer</param>
        public void Create(Course course);

        /// <summary>
        /// Lit et retourne un cours basé sur son code unique.
        /// </summary>
        /// <param name="code">Code du cours</param>
        /// <returns>Cours correspondant au code</returns>
        public Course Read(string code);

        /// <summary>
        /// Met à jour les données d'un cours existant dans la base de données.
        /// </summary>
        /// <param name="course">Cours avec les données mises à jour</param>
        public void Update(Course course);

        /// <summary>
        /// Supprime un cours de la base de données.
        /// </summary>
        /// <param name="course">Cours à supprimer</param>
        public void Delete(Course course);

        /// <summary>
        /// Liste tous les cours disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste des cours disponibles</returns>
        public Course[] ListAll();
    }
}
