using Logic;
using Storage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMI
{
    /// <summary>
    /// Interaction logic for the main window
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notebook notebook;
        public MainWindow()
        {
            InitializeComponent();
            DatabaseSqlite db = new DatabaseSqlite("notebook.db");
            CourseDaoSqlite cDao = new CourseDaoSqlite(db);
            ExamDaoSqlite eDao = new ExamDaoSqlite(cDao,db);
            notebook = new Notebook(cDao, eDao);
        }
        /// <summary>
        /// Réagit au clic sur le bouton "Courses" en ouvrant la fenêtre correspondante
        /// </summary>
        private void OpenCourseScreen_Click(object sender, RoutedEventArgs e)
        {
            CoursesScreen courseScreen = new CoursesScreen(notebook);
            courseScreen.Show();
        }

        /// <summary>
        /// Réagit au clic sur le bouton "Edit Exam" en ouvrant la fenêtre correspondante
        /// </summary>
        private void OpenExamsScreen_Click(Object sender, RoutedEventArgs e)
        {
            ExamsScreen examScreen= new ExamsScreen(notebook);
            examScreen.Show();
        }

    }
}
