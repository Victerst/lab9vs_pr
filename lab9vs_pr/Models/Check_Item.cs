using System.Collections.ObjectModel;
using System.IO;

namespace lab9vs_pr.Models
{
    public class Check_Item
    {
        public ObservableCollection<Folder> GetItems(string path)
        {
            var items = new ObservableCollection<Folder>();

            var dirInfo = new DirectoryInfo(path);

            foreach (var directory in dirInfo.GetDirectories())
            {
                var item = new Directory
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetItems(directory.FullName)
                };

                items.Add(item);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new Folder
                {
                    Name = file.Name,
                    Path = file.FullName
                };
                string Format_Image = Path.GetExtension(item.Path);
                if (Format_Image == ".png" || Format_Image == ".jpeg" || Format_Image == ".ico" || Format_Image == ".jpg")
                    items.Add(item);
            }

            return items;
        }

        public ObservableCollection<Folder> GetFilesNoRecursion(string path)
        {
            var items = new ObservableCollection<Folder>();

            var dirInfo = new DirectoryInfo(path);

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new Folder
                {
                    Name = file.Name,
                    Path = file.FullName
                };
                string Format_Image = Path.GetExtension(item.Path);
                if (Format_Image == ".png" || Format_Image == ".jpeg" || Format_Image == ".ico" || Format_Image == ".jpg")
                    items.Add(item);
            }
            return items;
        }
    }
}
