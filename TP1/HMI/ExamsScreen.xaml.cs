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
    /// Logique d'interaction pour la page d'affichage des examens
    /// </summary>
    public partial class ExamsScreen : Window
    {
        private Notebook notebook;
        public ExamsScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            listExam.ItemsSource = this.notebook.GetExams();
        }

        /// <summary>
        /// Ouvre la page de création d'un examen
        /// </summary>
        private void CreateExam(Object sender, RoutedEventArgs e)
        {
            ExamScreen examScreen = new ExamScreen(notebook);
            examScreen.ShowDialog();
            listExam.ItemsSource = this.notebook.GetExams();
        }
    }
}
