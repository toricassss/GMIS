using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GMIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes classes;
        private Groups groups;
        private Students students;
        private Meetings meetings;
        public MainWindow()
        {
            InitializeComponent();
            classes = (Classes)Application.Current.FindResource("class_controller");
            groups = (Groups)Application.Current.FindResource("group_controller");
            students = (Students)Application.Current.FindResource("student_controller");
            meetings = (Meetings)Application.Current.FindResource("meeting_controller");
            ShowAllClass.Visibility = Visibility.Collapsed;
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
        }

        private void ClassButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < classes.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(classes.GetViewableList()[i]);
            }
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
            ShowAllClass.Visibility = Visibility.Visible;
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> student_list = students.GetViewableList();
            String student_id = String.Concat(LogTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
            if (student_id.Count() != 0)
            {
                for (int i = 0; i < student_list.Count; i++)
                {
                    if (student_list[i].student_id == Convert.ToInt64(student_id))
                    {
                        MessageBox.Show("Log on successfully!");
                        if (student_list[i].category == "Masters")
                        {
                            ClassButton.Visibility = Visibility.Visible;
                            GroupButton.Visibility = Visibility.Visible;
                            StudentButton.Visibility = Visibility.Visible;
                            MeetingButton.Visibility = Visibility.Visible;
                        }
                        LogTextBox.Visibility = Visibility.Collapsed;
                        IDTextBox.Visibility = Visibility.Collapsed;
                        LogButton.Visibility = Visibility.Collapsed;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check your student ID entered!");
            }
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < students.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(students.GetViewableList()[i]);
            }
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < groups.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(groups.GetViewableList()[i]);
            }
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
        }

        private void MeetingButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < meetings.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(meetings.GetViewableList()[i]);
            }
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> class_list = classes.GetViewableList();
            ObservableCollection<Student> student_list = students.GetViewableList();
            ObservableCollection<Group> group_list = groups.GetViewableList();
            ObservableCollection<Meeting> meeting_list = meetings.GetViewableList();
            ListBox.Items.Clear();
            if (MainAttributeBox.Text == "Class ID")
            {
                String class_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (class_id.Count() != 0)
                {
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        if (class_list[i].class_id == Convert.ToInt64(class_id))
                        {
                            ListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (MainAttributeBox.Text == "Group ID")
            {
                String group_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (group_id.Count() != 0)
                {
                    for (int i = 0; i < group_list.Count; i++)
                    {
                        if (group_list[i].group_id == group_id)
                        {
                            ListBox.Items.Add(group_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (MainAttributeBox.Text == "Student ID")
            {
                String student_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (student_id.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        if (student_list[i].student_id == Convert.ToInt32(student_id))
                        {
                            ListBox.Items.Add(student_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (MainAttributeBox.Text == "Meeting ID")
            {
                String meeting_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (meeting_id.Count() != 0)
                {
                    for (int i = 0; i < meeting_list.Count; i++)
                    {
                        if (meeting_list[i].meeting_id == Convert.ToInt32(meeting_id))
                        {
                            ListBox.Items.Add(meeting_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else
            {
                MessageBox.Show("Please select required attribute and enter key word");
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassDetailsPanel.DataContext = ListBox.SelectedItem;
        }
    }
}
