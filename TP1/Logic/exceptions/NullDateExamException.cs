using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorsque la date d'examen est nulle
    /// </summary>
    public class NullDateExamException: BadDateException
    {
        public NullDateExamException() : base("Exam date cannot be null.") { }
    }
}
