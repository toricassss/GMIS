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
using MySql.Data.MySqlClient;
namespace GMIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public ClassDBLoad classDBLoad;

        public MainWindow()
        {
            InitializeComponent();

            classDBLoad = (ClassDBLoad)Application.Current.FindResource("class_controller");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            groupListbox.Items.Clear();
            for (int i = 0; i < classDBLoad.GetData().Count; i++)
            {
                groupListbox.Items.Add(classDBLoad.GetData()[i]);
            }

            classComboBox.Items.Clear();
            for (int i = 0; i < classDBLoad.GetComboData().Count; i++)
            {
                classComboBox.Items.Add(classDBLoad.GetComboData()[i]);
            }
        }

        private void grpListView_Loaded(object sender, RoutedEventArgs e)
        {


            //grpListView.Items.Clear();
            //for (int i = 0; i < studentGroupDBLoad.GetData().Count; i++)
            //{
            //    grpListView.Items.Add(studentGroupDBLoad.GetData()[i]);
            //}
        }

        public void LoadClassID()
        {
            

           
        }

        private void classComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          
            ObservableCollection<ClassWithGroupModel> classWithGroups = classDBLoad.LoadClassWithGroup();
            groupListbox.Items.Clear();
            String classID = String.Concat(classComboBox.SelectedItem.ToString().Where(c => !Char.IsWhiteSpace(c)));


            if (classWithGroups.Count() != 0)
            {
                for (int i = 0; i < classWithGroups.Count; i++)
                {
                   

                    if (classWithGroups[i].class_id== Convert.ToInt64(classID))
                    {
                        groupListbox.Items.Add(classWithGroups[i]);
                    }
                }

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<StudentGroupModel> studentGroups = classDBLoad.GetData();
            groupListbox.Items.Clear();
            String groupID = String.Concat(searchBox.Text.Where(c => !Char.IsWhiteSpace(c)));
            if(searchBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(searchBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter Group ID.");
                    searchBox.Text = searchBox.Text.Remove(searchBox.Text.Length - 1);
                }
                else
                {
                    if (studentGroups.Count() != 0)
                    {
                        for (int i = 0; i < studentGroups.Count; i++)
                        {
                            if (studentGroups[i].group_id == Convert.ToInt64(groupID))
                            {
                                groupListbox.Items.Add(studentGroups[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                groupListbox.Items.Clear();
                for (int i = 0; i < classDBLoad.GetData().Count; i++)
                {
                    groupListbox.Items.Add(classDBLoad.GetData()[i]);
                }
            }

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {

           
        }

        private void groupListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        
            ObservableCollection<StudentModel> studentDetail = classDBLoad.LoadStudents();

            studentListBox.Items.Clear();
            if (groupListbox.SelectedItem != null)
            {

                String groupID = String.Concat(groupListbox.SelectedItem.ToString().Where(c => !Char.IsWhiteSpace(c)));
                groupID = groupID.Substring(9, 3);
                groupID = groupID.Replace(",",String.Empty);

                

                if (studentDetail.Count() != 0)
                {
                    for (int i = 0; i < studentDetail.Count; i++)
                    {


                        if (studentDetail[i].group_id == Convert.ToInt64(groupID))
                        {
                            studentListBox.Items.Add(studentDetail[i]);
                        }
                    }

                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //ObservableCollection<StudentGroupModel> studentGroups = studentGroupDBLoad.GetData();
            //groupListbox.Items.Clear();
            //String group = String.Concat(searchBox.Text.Where(c => !Char.IsWhiteSpace(c)));
            //if (searchBox.Text != "")
            //{
            //    MessageBox.Show("Please enter Group ID or Group Name");
            //}
            // else
            // {
            //        if (studentGroups.Count() != 0)
            //        {
            //            for (int i = 0; i < studentGroups.Count; i++)
            //            {
            //                if (studentGroups[i].group_id == Convert.ToInt64(group) || studentGroups[i].group_name.Contains(group))
            //                {
            //                    groupListbox.Items.Add(studentGroups[i]);
            //                }
            //            }
            //        }
            // }
            
        }
    }
}
