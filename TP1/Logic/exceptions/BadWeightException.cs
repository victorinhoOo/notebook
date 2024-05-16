using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorsque la valeur attribuée à un poids est en dehors de l'intervalle autorisé (1 à 100).
    /// </summary>
    public class BadWeightException: Exception
    {
        public BadWeightException() : base("Weight must be between 1 and 100.") { }
    }
}
