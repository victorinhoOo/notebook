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
    /// Logique d'interaction pour ExamScreen.xaml
    /// </summary>
    public partial class ExamScreen : Window
    {
        private Notebook notebook;
        public ExamScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            listExam.ItemsSource = this.notebook.GetExams();
        }
    }
}
