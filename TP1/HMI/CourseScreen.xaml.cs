using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
    /// Logique d'interaction pour la fenêtre de détail d'un cours
    /// </summary>
    public partial class CourseScreen : Window
    {
        private Course course;
        public CourseScreen(Course course)
        {
            InitializeComponent();
            this.course = course;
            this.courseName.Text = course.Name;
            this.courseCode.Text = course.Code;
            this.courseWeight.Text = course.Weight.ToString();
        }

        /// <summary>
        /// Réagit au clic sur le bouton Close
        /// </summary>
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Réagit au clic sur le bouton Ok, modifie ou créé le cours saisi dans la fenêtre
        /// </summary>
        private void Ok(object sender, RoutedEventArgs e)
        {
            try
            {
                this.course.Name = this.courseName.Text;
                this.course.Code = this.courseCode.Text;
                this.course.Weight = Convert.ToInt32(this.courseWeight.Text);
                this.course.Save();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
