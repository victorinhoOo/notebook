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
    /// Gère les attributs des examens
    /// </summary>
    public class Exam
    {
        private Course course;
        private Decimal? score;
        private string teacher;
        private DateTime? dateExam;
        private int coef;

        /// <summary>
        /// Obtient ou définit le score de l'examen, qui peut être nul si l'étudiant était absent.
        /// </summary>
        /// <exception cref="BadScoreValueException">Levée lorsque le score n'est pas dans la plage valide (0 à 20).</exception>
        public Decimal? Score
        {
            get => score;
            set
            {
                if (value.HasValue && (value < 0 || value > 20))
                    throw new BadScoreValueException();
                score = value;
            }
        }
        /// <summary>
        /// Obtient ou définit le nom de l'enseignant qui dirige l'examen.
        /// </summary>
        public string Teacher { get => teacher; set => teacher = value; }

        /// <summary>
        /// Obtient ou définit la date à laquelle l'examen est programmé.
        /// </summary>
        /// <exception cref="NullDateExamException">Levée lorsqu'une tentative est faite pour définir la date de l'examen à null.</exception>
        /// <exception cref="DateExamInFutureException">Levée lorsqu'une tentative est faite pour définir la date de l'examen à une date future supérieure à la date actuelle.</exception>
        public DateTime? DateExam
        {
            get => dateExam;
            set
            {
                if (value == null)
                    throw new NullDateExamException();
                if (value > DateTime.Now)
                    throw new DateExamInFutureException();
                dateExam = value;
            }
        }
        /// <summary>
        /// Obtient ou définit le coefficient de l'examen, qui représente son poids relatif par rapport aux autres examens.
        /// </summary>
        /// <exception cref="BadWeightException">Levée lorsque le coefficient est défini en dehors de la plage de 1 à 100.</exception>
        public int Coef
        {
            get => coef;
            set
            {
                if (value < 1 || value > 100)
                    throw new BadWeightException();
                coef = value;
            }
        }

        public Course Course { get => course; }

        public Exam(Course c)
        {
            course = c;
        }

        public override bool Equals(object? obj)
        {
            return obj is Exam exam &&
                   EqualityComparer<Course>.Default.Equals(course, exam.course) &&
                   score == exam.score &&
                   teacher == exam.teacher &&
                   dateExam == exam.dateExam &&
                   coef == exam.coef;
        }

        /// <summary>
        /// Renvoi l'examen sous forme de chaînes de caractères au format suivant : Date – Code – Note/20 (coef)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string formattedDate = dateExam?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) ?? "NA";
            string courseCode = course?.Code ?? "NA";
            string formattedScore = score.HasValue ? score.Value.ToString("0.#") : "NA";
            return $"{formattedDate} - {courseCode} - {formattedScore}/20 ({coef})";
        }

    }
}
