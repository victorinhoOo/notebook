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
    /// Logique d'interaction pour la fenêtre des cours
    /// </summary>
    public partial class CoursesScreen : Window
    {
        private Notebook notebook;

        public CoursesScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            listCourses.ItemsSource = this.notebook.GetCourses();
        }

        /// <summary>
        /// Réagit au clic du bouton de suppression 
        /// </summary>
        private void RemoveCourse(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = listCourses.SelectedItem as Course;
            if (selectedCourse == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }
            // Confirme la suppression
            if (MessageBox.Show($"Are you sure you want to delete the course : {selectedCourse.Name}?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                notebook.RemoveCourse(selectedCourse);
                listCourses.ItemsSource = this.notebook.GetCourses(); // met à jour la liste des cours après la suppression
            }

        }

        /// <summary>
        /// Réagit au clic du bouton d'édition
        /// </summary>
        private void EditCourse(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = listCourses.SelectedItem as Course;
            CourseScreen courseScreen = new CourseScreen(selectedCourse);
            courseScreen.ShowDialog();
            listCourses.ItemsSource = this.notebook.GetCourses(); // met à jour les cours affichés après la modification

        }

        /// <summary>
        /// Réagit au clic du bouton de création
        /// </summary>
        private void AddCourse(object sender, RoutedEventArgs e)
        {
            Course newCourse = notebook.CreateCourse();
            CourseScreen courseScreen = new CourseScreen(newCourse);
            courseScreen.ShowDialog();
            listCourses.ItemsSource = this.notebook.GetCourses(); // met à jour les cours affichés après la création
        }
    }
}
