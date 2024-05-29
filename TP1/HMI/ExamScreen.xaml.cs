using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HMI
{
    /// <summary>
    /// Logique d'interaction pour la page de création d'un examen
    /// </summary>
    public partial class ExamScreen : Window
    {
        private Notebook notebook;
        public ExamScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            this.listCourses.ItemsSource = notebook.GetCourses();
        }

        /// <summary>
        /// Réagit au clic sur le bouton "Close"
        /// </summary>
        private void ButtonCloseClicked(object sender, RoutedEventArgs e)
        {
            //Vérifie si un cours est sélectionné
            if(this.listCourses.SelectedItem != null)
            {
                try
                {
                    // Créé un nouvel exam à partir du cours sélectionné
                    Exam newExam = new Exam((Course)listCourses.SelectedItem);
                    newExam.DateExam = DateExamPicker.SelectedDate;
                    newExam.Teacher = TeacherTextBox.Text;
                    newExam.Score = decimal.TryParse(ScoreTextBox.Text, out decimal score) ? score : (decimal?)null;  // Gérer le cas où le score n'est pas un décimal valide
                    newExam.Coef = int.TryParse(CoefTextBox.Text, out int coef) ? coef : 0;  // Mettre à 0 si la conversion échoue

                    notebook.CreateExamen(newExam);
                    this.Close();
                    MessageBox.Show("Exam created successfully.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error while creating the exam : " + ex.Message);
                }
            }
            else // Si aucun cours sélectionné on ferme la fenêtre
            {
                this.Close();
                MessageBox.Show("No course selected.");
            }

        }
    }
}
