using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorsqu'on tente de définir une propriété avec une chaîne vide.
    /// </summary>
    public class EmptyStringException: Exception
    {
        public EmptyStringException(string field) : base($"The {field} cannot be empty.") { }
    }
}
