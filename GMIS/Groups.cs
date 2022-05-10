using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS
{
    public class Groups
    {
        private ObservableCollection<Group> groups;

        public Groups()
        {
            groups = Group_db.LoadAll();
        }

        public ObservableCollection<Group> GetViewableList()
        {
            return groups;
        }
    }
}
