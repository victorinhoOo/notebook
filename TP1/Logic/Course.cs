using Logic.exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Gère les caractéristiques d'un cours
    /// </summary>
    public class Course
    {
        private string name;
        private int weight;
        private string code;

        /// <summary>
        /// Obtient ou définit le nom de la matière
        /// </summary>
        /// <exception cref="EmptyStringException">Lancée si la valeur est vide</exception>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new EmptyStringException(nameof(Name));
                name = value;
            }
        }

        /// <summary>
        /// Obtient ou définit le poids du cours
        /// </summary>
        /// <exception cref="BadWeightException">Lancée si la valeur est en dehors de l'intervalle [1, 100].</exception>
        public int Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 100)
                    throw new BadWeightException();
                weight = value;
            }
        }

        /// <summary>
        /// Obtient ou définit le code de la matière
        /// </summary>
        /// <exception cref="EmptyStringException">Lancée si la valeur est vide.</exception>
        /// <exception cref="CodeCannotChangeException">Lancée si une tentative est faite pour modifier le code sur un objet existant.</exception>
        public string Code
        {
            get => code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new EmptyStringException(nameof(Code));
                if (exists && code != null && value != code)
                    throw new CodeCannotChangeException();
                code = value;
            }
        }

        private bool exists = false;
        private ICourseDao dao;

        public Course(ICourseDao dao, bool exists)
        {
            this.exists = exists;
            this.dao = dao;
        }

        /// <summary>
        /// Retourne une représentation en chaîne du cours.
        /// </summary>
        public override string ToString()
        {
            return $"{Code}-{Name} ({Weight})";
        }

        /// <summary>
        /// Détermine si l'objet spécifié est égal à l'instance du cours, basé sur le code de la matière.
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   Code == course.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        /// <summary>
        /// Enregistre le cours dans la base de données (soit en le modifiant soit en le créant si celui-ci n'existe pas)
        /// </summary>
        public void Save()
        {
            if(this.exists)
            {
                dao.Update(this);
            }
            else
            {
                dao.Create(this);
                exists = true;
            }
        }
    }
}
