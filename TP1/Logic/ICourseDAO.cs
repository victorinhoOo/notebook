using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Create(Course course);
        public Course Read(string code);
        public void Update(Course course);
        public void Delete(Course course);
        public Course[] ListAll();
    }
}
