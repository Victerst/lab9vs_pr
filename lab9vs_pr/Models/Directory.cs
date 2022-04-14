using System.Collections.ObjectModel;

namespace lab9vs_pr.Models
{
    public class Directory : Folder
    {
        public ObservableCollection<Folder> Items { get; set; }
        public Directory()
        {
            Items = new ObservableCollection<Folder>();
        }
    }
}

