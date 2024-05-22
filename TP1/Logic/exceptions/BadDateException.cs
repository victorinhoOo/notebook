using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Classe utilisée pour les exceptions relatives aux dates.
    /// </summary>
    public class BadDateException: Exception
    {
        public BadDateException() : base("The provided date is invalid.") { }
        public BadDateException(string message) : base(message) { }
    }
}
