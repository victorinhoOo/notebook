using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorsque une tentative de modification du code d'un cours déjà existant dans la base de données est faite.
    /// </summary>
    public class CodeCannotChangeException: Exception
    {
        public CodeCannotChangeException() : base("Code cannot be changed once set.") { }
    }
}
