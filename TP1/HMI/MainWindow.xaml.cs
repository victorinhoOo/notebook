﻿using Logic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notebook notebook;
        public MainWindow()
        {
            InitializeComponent();
            notebook = new Notebook(new CourseDaoSqlite("notebook.db"));
        }
        private void OpenCourseScreen_Click(object sender, RoutedEventArgs e)
        {
            CourseScreen courseScreen = new CourseScreen(notebook);
            courseScreen.Show();
        }

    }
}
