using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorque le score n'a pas une valeur comprise entre 0 et 20
    /// </summary>
    public class BadScoreValueException: Exception
    {
        public BadScoreValueException() : base("Score must be between 0 and 20.") { }
    }
}
