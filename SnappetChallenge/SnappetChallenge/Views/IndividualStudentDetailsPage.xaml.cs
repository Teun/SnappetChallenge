using SnappetChallenge.Models;
using SnappetChallenge.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SnappetChallenge.Views
{
    /// <summary>
    /// Interaction logic for IndividualStudentDetailsPage.xaml
    /// </summary>
    public partial class IndividualStudentDetailsPage : Page
    {
        public IndividualStudentDetailsPage(StudentData selectedStudent)
        {
            InitializeComponent();
            DataContext = new IndividualStudentDetailsViewModel(selectedStudent);
        }

        private void ReturnToMainPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page or clear the frame content
            Window myWindow = Window.GetWindow(this);
            Frame? parentFrame = myWindow.FindName("StudentDetailsFrame") as Frame;
            if (parentFrame != null)
            {
                if (parentFrame.CanGoBack)
                {
                    parentFrame.GoBack();  // If there's a navigation history
                }
                else
                {
                    parentFrame.Content = null;  // Clear the frame to show main content
                }
                parentFrame.Visibility = Visibility.Collapsed;

                Grid? mainFrameTopGrid = myWindow.FindName("MainFrameTopGrid") as Grid;

                if (mainFrameTopGrid != null) 
                {
                    ((DockPanel)mainFrameTopGrid.Children[0]).Visibility = Visibility.Visible;
                    DataGrid? studentDataGrid = myWindow.FindName("StudentDataGrid") as DataGrid;
                    if (studentDataGrid != null) 
                    {
                        studentDataGrid.UnselectAll();
                    }
                }
            }
        }
    }
}