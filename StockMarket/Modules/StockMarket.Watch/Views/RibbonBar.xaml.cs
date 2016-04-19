using StockMarket.Watch.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace StockMarket.Watch.Views
{
    /// <summary>
    /// Interaction logic for RibbonBar.xaml
    /// </summary>
    public partial class RibbonBar : UserControl
    {
        public RibbonBar()
        {
            InitializeComponent();
          
        }


        private void DropBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                var listbox = sender as ListBox;
                listbox.Background = new SolidColorBrush(Color.FromRgb(155, 155, 155));
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DropBox_DragLeave(object sender, DragEventArgs e)
        {
            var listbox = sender as ListBox;
            listbox.Background = new SolidColorBrush(Color.FromRgb(226, 226, 226));
        }

        public ObservableCollection<string> Files
        {
            get
            {
                return _files;
            }
        }
        private ObservableCollection<string> _files = new ObservableCollection<string>();

        private void DropBox_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                _files.Clear();
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string filePath in files)
                {
                    _files.Add(filePath);
                }

              UploadFiles(files);
            }
            else
            {

            }

            var listbox = sender as ListBox;
            listbox.Background = new SolidColorBrush(Color.FromRgb(226, 226, 226));
        }

        private void UploadFiles(string[] files)
        {
            var location = txtlocation.Text;
            
            foreach(var path in files)
            {
                string destination = System.IO.Path.Combine(location, System.IO.Path.GetFileName(path.TrimEnd(System.IO.Path.DirectorySeparatorChar).TrimEnd(System.IO.Path.AltDirectorySeparatorChar)));
                  
                if (Directory.Exists(path))
                {
                  
                     //string destination = System.IO.Path.Combine(location,path.Substring(path.LastIndexOf('/') + 1));
                    DirectoryCopy(path, destination, true);
                }
                else
                {
                    System.IO.File.Copy(path, destination, true);
                }
            }
                 
        }


        private void DirectoryCopy(
             string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = System.IO.Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void XamDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
