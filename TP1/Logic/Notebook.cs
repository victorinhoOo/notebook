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
    }
}
