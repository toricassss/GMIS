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
using System.Windows.Shapes;

namespace GMIS
{
    /// <summary>
    /// Interaction logic for AllStudnets.xaml
    /// </summary>
    public partial class AllStudnets : Window
    {
        
        public ClassDBLoad classDBLoad;
        public AllStudnets()
        {
            InitializeComponent();
            

            classDBLoad = (ClassDBLoad)Application.Current.FindResource("class_controller");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            groupListbox.Items.Clear();
            for (int i = 0; i < classDBLoad.LoadGroupID().Count; i++)
            {
                groupListbox.Items.Add(classDBLoad.LoadGroupID()[i]);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<GroupIDOnlyModel> gID = classDBLoad.LoadGroupID();
            groupListbox.Items.Clear();
            studentListBox.Items.Clear();
            String groupID = String.Concat(searchBox.Text.Where(c => !Char.IsWhiteSpace(c)));
            if (searchBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(searchBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter Group ID.");
                    searchBox.Text = searchBox.Text.Remove(searchBox.Text.Length - 1);
                }
                else
                {
                    if (gID.Count() != 0)
                    {
                        for (int i = 0; i < gID.Count; i++)
                        {
                            if (gID[i].group_id == Convert.ToInt64(groupID))
                            {
                                groupListbox.Items.Add(gID[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                groupListbox.Items.Clear();
                for (int i = 0; i < classDBLoad.LoadGroupID().Count; i++)
                {
                    groupListbox.Items.Add(classDBLoad.LoadGroupID()[i]);
                }
            }
        }

        private void groupListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<StudentModel> studentDetail = classDBLoad.LoadStudents();
            studentListBox.Items.Clear();
            

            if(groupListbox.SelectedItem != null)
            {
                String groupID = String.Concat(groupListbox.SelectedItem.ToString().Where(c => !Char.IsWhiteSpace(c)));

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
    }
}
