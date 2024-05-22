using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Définit les opérations de base de données pour les examens
    /// </summary>
    public interface IExamDAO
    {
        /// <summary>
        /// Créé un nouvel examen dans la base de données
        /// </summary>
        /// <param name="exam">examen à créer</param>
        public void Create(Exam exam);
        /// <summary>
        /// Liste les examens contenus dans la base de données
        /// </summary>
        /// <returns>Liste d'examens</returns>
        public Exam[] ListAll();
    }
}
