using Avalonia.Media.Imaging;

namespace lab9vs_pr.Models
{
    public class Image : Folder
    {
        public Image(Folder item)
        {
            Name = item.Name;
            Path = item.Path;
            ImageBitmap = new Bitmap(Path);
        }

        public Bitmap ImageBitmap { get; set; }
    }
}

