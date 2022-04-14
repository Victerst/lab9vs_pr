using System;
using System.Collections.ObjectModel;
using System.IO;
using ReactiveUI;
using System.Reactive;
using lab9vs_pr.Models;

namespace lab9vs_pr.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var strFolder = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Assets";
            var itemProvider = new Check_Item();

            ButtonsEnabled = false;
            ImagesSelect = new ObservableCollection<Image>();
            Items = new ObservableCollection<Folder>(itemProvider.GetItems(strFolder));

            SelectDirectory = ReactiveCommand.Create<Folder, Unit>(
                (file) =>
                {
                    var dir = itemProvider.GetFilesNoRecursion(Path.GetDirectoryName(file.Path));

                    ImagesSelect.Clear();
                    foreach (var item in dir)
                    {
                        string Format_Image = Path.GetExtension(item.Path);
                        if (Format_Image == ".png" || Format_Image == ".jpeg" || Format_Image == ".ico" || Format_Image == ".jpg" || Format_Image == ".bmp")
                            ImagesSelect.Add(new Image((Folder)item));
                    }

                    if (ImagesSelect.Count > 1) ButtonsEnabled = true;
                    else ButtonsEnabled = false;

                    return Unit.Default;
                });
        }

        ObservableCollection<Folder> items;

        public ObservableCollection<Folder> Items
        {
            get { return items; }
            set { this.RaiseAndSetIfChanged(ref items, value); }
        }

        ObservableCollection<Image> Select_Image;

        public ObservableCollection<Image> ImagesSelect
        {
            get { return Select_Image; }
            set { this.RaiseAndSetIfChanged(ref Select_Image, value); }
        }

        bool buttonsenabled;

        public bool ButtonsEnabled
        {
            get { return buttonsenabled; }
            set { this.RaiseAndSetIfChanged(ref buttonsenabled, value); }
        }

        public ReactiveCommand<Folder, Unit> SelectDirectory { get; }
        public ReactiveCommand<Folder, Unit> GetFilePath { get; }

    }
}