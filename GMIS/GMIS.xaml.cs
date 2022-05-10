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
            ShowAllGroup.Visibility = Visibility.Collapsed;
            ShowAllStudent.Visibility = Visibility.Collapsed;
            ShowAllMeeting.Visibility = Visibility.Collapsed;
            ClassButton.Visibility = Visibility.Collapsed;
            GroupButton.Visibility = Visibility.Collapsed;
            StudentButton.Visibility = Visibility.Collapsed;
            MeetingButton.Visibility = Visibility.Collapsed;
            ClassAttributeBox.Visibility = Visibility.Collapsed;
            ClassFilterButton.Visibility = Visibility.Collapsed;
            ClassTextBox.Visibility = Visibility.Collapsed;
            GroupAttributeBox.Visibility = Visibility.Collapsed;
            GroupFilterButton.Visibility = Visibility.Collapsed;
            GroupTextBox.Visibility = Visibility.Collapsed;
            StudentAttributeBox.Visibility = Visibility.Collapsed;
            StudentFilterButton.Visibility = Visibility.Collapsed;
            StudentTextBox.Visibility = Visibility.Collapsed;
            MeetingAttributeBox.Visibility = Visibility.Collapsed;
            MeetingFilterButton.Visibility = Visibility.Collapsed;
            MeetingTextBox.Visibility = Visibility.Collapsed;
        }

        private void ClassButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < classes.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(classes.GetViewableList()[i]);
            }
            ShowAllClass.Visibility = Visibility.Visible;
            ClassAttributeBox.Visibility= Visibility.Visible;
            ClassFilterButton.Visibility= Visibility.Visible;
            ClassTextBox.Visibility = Visibility.Visible;
            ShowAllGroup.Visibility = Visibility.Collapsed;
            ShowAllMeeting.Visibility = Visibility.Collapsed;
            ShowAllStudent.Visibility = Visibility.Collapsed;
            MainAttributeBox.Text = "Class ID";
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
                ShowAllStudent.Visibility = Visibility.Visible;
                StudentAttributeBox.Visibility = Visibility.Visible;
                StudentFilterButton.Visibility = Visibility.Visible;
                StudentTextBox.Visibility = Visibility.Visible;
                ShowAllClass.Visibility = Visibility.Collapsed;
                ShowAllGroup.Visibility = Visibility.Collapsed;
                ShowAllMeeting.Visibility = Visibility.Collapsed;
                MainAttributeBox.Text = "Student ID";
            }
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < groups.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(groups.GetViewableList()[i]);
            }
            ShowAllGroup.Visibility = Visibility.Visible;
            GroupAttributeBox.Visibility = Visibility.Visible;
            GroupFilterButton.Visibility = Visibility.Visible;
            GroupTextBox.Visibility = Visibility.Visible;
            ShowAllClass.Visibility = Visibility.Collapsed;
            ShowAllStudent.Visibility = Visibility.Collapsed;
            ShowAllMeeting.Visibility = Visibility.Collapsed;
            MainAttributeBox.Text = "Group ID";
        }

        private void MeetingButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < meetings.GetViewableList().Count; i++)
            {
                ListBox.Items.Add(meetings.GetViewableList()[i]);
            }
            ShowAllMeeting.Visibility = Visibility.Visible;
            MeetingAttributeBox.Visibility = Visibility.Visible;
            MeetingFilterButton.Visibility = Visibility.Visible;
            MeetingTextBox.Visibility = Visibility.Visible;
            ShowAllClass.Visibility = Visibility.Collapsed;
            ShowAllStudent.Visibility = Visibility.Collapsed;
            ShowAllGroup.Visibility = Visibility.Collapsed;
            MainAttributeBox.Text = "Meeting ID";
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
                            ShowAllClass.Visibility = Visibility.Visible;
                            ShowAllGroup.Visibility = Visibility.Collapsed;
                            ShowAllStudent.Visibility = Visibility.Collapsed;
                            ShowAllMeeting.Visibility = Visibility.Collapsed;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check key word!");
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
                            ShowAllGroup.Visibility = Visibility.Visible;
                            ShowAllClass.Visibility = Visibility.Collapsed;
                            ShowAllStudent.Visibility = Visibility.Collapsed;
                            ShowAllMeeting.Visibility = Visibility.Collapsed;
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
                            ShowAllStudent.Visibility = Visibility.Visible;
                            ShowAllClass.Visibility = Visibility.Collapsed;
                            ShowAllGroup.Visibility = Visibility.Collapsed;
                            ShowAllMeeting.Visibility = Visibility.Collapsed;
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
                            ShowAllMeeting.Visibility = Visibility.Visible;
                            ShowAllClass.Visibility = Visibility.Collapsed;
                            ShowAllGroup.Visibility = Visibility.Collapsed;
                            ShowAllStudent.Visibility = Visibility.Collapsed;
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
            SearchTextBox.Text = String.Empty;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainAttributeBox.Text == "Class ID")
            {
                ClassDetailsPanel.DataContext = ListBox.SelectedItem;
            }
            else if (MainAttributeBox.Text == "Group ID")
            {
                GroupDetailsPanel.DataContext = ListBox.SelectedItem;
            }
            else if (MainAttributeBox.Text == "Student ID")
            {
                StudentDetailsPanel.DataContext = ListBox.SelectedItem;
            }
            else if (MainAttributeBox.Text == "Meeting ID")
            {
                MeetingDetailsPanel.DataContext = ListBox.SelectedItem;
            }
        }

        private void RelatedGroupButton_Click(object sender, RoutedEventArgs e)
        {
            Class List_selected_class = new Class();
            List_selected_class = (ListBox.SelectedItem) as Class;
            ListBox.Items.Clear();
            if (List_selected_class != null)
            {
                string required_group_id = List_selected_class.group_id;
                for (int i = 0; i < groups.GetViewableList().Count; i++)
                {
                    if (required_group_id == groups.GetViewableList()[i].group_id)
                    {
                        ListBox.Items.Add(groups.GetViewableList()[i]);
                    }
                }
                ShowAllGroup.Visibility = Visibility.Visible;
                ShowAllClass.Visibility = Visibility.Collapsed;
                ShowAllStudent.Visibility = Visibility.Collapsed;
                ShowAllMeeting.Visibility = Visibility.Collapsed;
                MainAttributeBox.Text = "Group ID";
            }
            else
            {
                MessageBox.Show("There is no class selected!");
            }
        }

        private void RelatedStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Group List_selected_class = new Group();
            List_selected_class = (ListBox.SelectedItem) as Group;
            ListBox.Items.Clear();
            if (List_selected_class != null)
            {
                string required_group_id = List_selected_class.group_id;
                for (int i = 0; i < students.GetViewableList().Count; i++)
                {
                    if (required_group_id == students.GetViewableList()[i].group_id)
                    {
                        ListBox.Items.Add(students.GetViewableList()[i]);
                    }
                }
                ShowAllStudent.Visibility = Visibility.Visible;
                ShowAllClass.Visibility = Visibility.Collapsed;
                ShowAllGroup.Visibility = Visibility.Collapsed;
                ShowAllMeeting.Visibility = Visibility.Collapsed;
                MainAttributeBox.Text = "Student ID";
            }
            else
            {
                MessageBox.Show("There is no class selected!");
            }
        }

        private void RelatedClassButton_Click(object sender, RoutedEventArgs e)
        {
            Student List_selected_class = new Student();
            List_selected_class = (ListBox.SelectedItem) as Student;
            ListBox.Items.Clear();
            if (List_selected_class != null)
            {
                string required_group_id = List_selected_class.group_id;
                for (int i = 0; i < classes.GetViewableList().Count; i++)
                {
                    if (required_group_id == classes.GetViewableList()[i].group_id)
                    {
                        ListBox.Items.Add(classes.GetViewableList()[i]);
                    }
                }
                ShowAllClass.Visibility = Visibility.Visible;
                ShowAllStudent.Visibility = Visibility.Collapsed;
                ShowAllGroup.Visibility = Visibility.Collapsed;
                ShowAllMeeting.Visibility = Visibility.Collapsed;
                MainAttributeBox.Text = "Class ID";
            }
            else
            {
                MessageBox.Show("There is no class selected!");
            }
        }

        private void RelatedMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            Student List_selected_class = new Student();
            List_selected_class = (ListBox.SelectedItem) as Student;
            ListBox.Items.Clear();
            if (List_selected_class != null)
            {
                string required_group_id = List_selected_class.group_id;
                for (int i = 0; i < meetings.GetViewableList().Count; i++)
                {
                    if (required_group_id == meetings.GetViewableList()[i].group_id)
                    {
                        ListBox.Items.Add(meetings.GetViewableList()[i]);
                    }
                }
                ShowAllMeeting.Visibility = Visibility.Visible;
                ShowAllStudent.Visibility = Visibility.Collapsed;
                ShowAllGroup.Visibility = Visibility.Collapsed;
                ShowAllClass.Visibility = Visibility.Collapsed;
                MainAttributeBox.Text = "Meeting ID";
            }
            else
            {
                MessageBox.Show("There is no class selected!");
            }
        }

        private void ClassFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> class_list = classes.GetViewableList();
            ListBox.Items.Clear();
            if (MainAttributeBox.Text == "Class ID" && ClassAttributeBox.Text == "Day")
            {
                String day = String.Concat(ClassTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (day.Count() != 0)
                {
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        if (class_list[i].day.ToLower() == day.ToLower())
                        {
                            ListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select required attribute and enter key word");
                }
            }
            else
            {
                MessageBox.Show("Please select required attribute and enter key word");
            }
            ClassTextBox.Text = String.Empty;
        }

        private void GroupFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Group> group_list = groups.GetViewableList();
            ListBox.Items.Clear();
            if (MainAttributeBox.Text == "Group ID" && GroupAttributeBox.Text == "Group Name")
            {
                String group_name = String.Concat(GroupTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (group_name.Count() != 0)
                {
                    for (int i = 0; i < group_list.Count; i++)
                    {
                        if (group_list[i].group_name.ToLower() == group_name.ToLower())
                        {
                            ListBox.Items.Add(group_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select required attribute and enter key word");
                }
            }
            else
            {
                MessageBox.Show("Please select required attribute and enter key word");
            }
            GroupTextBox.Text = String.Empty;
        }

        private void MeetingFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Meeting> meeting_list = meetings.GetViewableList();
            ListBox.Items.Clear();
            if (MainAttributeBox.Text == "Meeting ID" && MeetingAttributeBox.Text == "Day")
            {
                String day = String.Concat(MeetingTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (day.Count() != 0)
                {
                    for (int i = 0; i < meeting_list.Count; i++)
                    {
                        if (meeting_list[i].day.ToLower() == day.ToLower())
                        {
                            ListBox.Items.Add(meeting_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select required attribute and enter key word");
                }
            }
            else
            {
                MessageBox.Show("Please select required attribute and enter key word");
            }
            MeetingTextBox.Text = String.Empty;
        }

        private void StudentFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> student_list = students.GetViewableList();
            ListBox.Items.Clear();
            if (MainAttributeBox.Text == "Student ID" && StudentAttributeBox.Text == "Name")
            {
                String name = String.Concat(StudentTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (name.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        if (name.ToLower().Contains(student_list[i].family_name.ToLower()) && name.Contains(student_list[i].given_name.ToLower()))
                        {
                            ListBox.Items.Add(student_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select required attribute and enter key word");
                }
            }
            else
            {
                MessageBox.Show("Please select required attribute and enter key word");
            }
            StudentTextBox.Text = String.Empty;
        }
    }
}
