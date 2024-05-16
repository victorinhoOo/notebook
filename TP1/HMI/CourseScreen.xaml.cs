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
    /// Logique d'interaction pour CourseScreen.xaml
    /// </summary>
    public partial class CourseScreen : Window
    {
        private Notebook notebook;

        public CourseScreen(Notebook notebook)
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
    }
}
