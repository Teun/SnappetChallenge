using SnappetChallenge.Models;
using SnappetChallenge.ViewModels;
using SnappetChallenge.Views;
using System.Windows;
using System.Windows.Controls;

namespace SnappetChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void ShowIndividualDetailsPageButton_Click(object sender, RoutedEventArgs e)
        {
            StudentData selectedStudent = (StudentData)StudentDataGrid.SelectedItem;
            if (selectedStudent != null) 
            {
                ((DockPanel)MainFrameTopGrid.Children[0]).Visibility = Visibility.Collapsed;

                var individualStudentDetailsPage = new IndividualStudentDetailsPage(selectedStudent);
                StudentDetailsFrame.Visibility = Visibility.Visible;
                StudentDetailsFrame.Navigate(individualStudentDetailsPage);
            }
        }
    }
}