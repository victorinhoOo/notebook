using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.exceptions
{
    /// <summary>
    /// Levée lorsque la date d'examen saisie est dans le futur
    /// </summary>
    public class DateExamInFutureException: BadDateException
    {
        public DateExamInFutureException() : base("Exam date is set in the future.") { }
    }
}
