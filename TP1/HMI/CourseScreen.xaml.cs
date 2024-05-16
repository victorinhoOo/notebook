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
    }
}
