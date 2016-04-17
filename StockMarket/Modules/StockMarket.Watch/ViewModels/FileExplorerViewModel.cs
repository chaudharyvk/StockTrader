using Microsoft.Practices.Prism.Commands;
using StockMarket.Watch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;


///http://www.c-sharpcorner.com/blogs/creating-windows-explorer-in-wpf-using-c-sharp1
///
namespace StockMarket.Watch.ViewModels
{
    public class FileExplorerViewModel : INotifyPropertyChanged
    {


        public FileExplorerViewModel()
        {
            
            FileExplorerData = new ObservableCollection<FileExplorer>();
            NavigateFolder = new DelegateCommand(OnNavigate,canNavigate);
            FillDirectory("Z://");
            
        }

        private void OnNavigate()
        {
            throw new System.NotImplementedException();
        }

        private bool canNavigate()
        {
            return true;
        }

        public FileExplorer _activeRecord;
        
        public FileExplorer ActiveRecord
        {
            get
            {
                return _activeRecord;
            }
            set
            {
                _activeRecord = value;
                if (PropertyChanged != null)
                {
                   if(_activeRecord.FileType=="Folder")
                    {
                        FileExplorerData.Clear();
                        FillDirectory(_activeRecord.Path);
                    }
                    else
                    {
                       Process.Start(_activeRecord.Path);
                    }
                    PropertyChanged(this, new PropertyChangedEventArgs("ActiveRecord"));

                }
            }
        }

        private string locationPath;
        public string Location { set; get; }

       

        public DelegateCommand NavigateFolder { get; set; }     
        public ObservableCollection<FileExplorer> fileExplorerData;

       public ObservableCollection<FileExplorer> FileExplorerData
        {
            get
            {
                return fileExplorerData;
            }
            set
            {
                fileExplorerData = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FileExplorerData"));
                }
            }
        }

       public event PropertyChangedEventHandler PropertyChanged;


       IEnumerator<string> filesEnumerator;

       public void FillDirectory(string path)
       {
           Location = path;

           DirectoryInfo DIR = new DirectoryInfo(path);
           filesEnumerator = Directory.EnumerateDirectories(path).GetEnumerator();
               foreach(var rd in DIR.GetDirectories())
               {
                   FileExplorer rootDirectory = new FileExplorer();
                      rootDirectory.FileType = "Folder";
                    rootDirectory.Name=rd.Name;
                  

                    rootDirectory.FileCreatedDateTime = rd.CreationTime;
                    rootDirectory.FileModifiedDateTime = rd.LastWriteTime;
                    rootDirectory.FileType = "Folder";
                   rootDirectory.Path=String.Format("{0}/{1}",path,rd.Name);
                   fileExplorerData.Add(rootDirectory);
                 
                 
               }
               foreach(var file in DIR.GetFiles())
                    {
                       FileExplorer f = new FileExplorer();
                      f.FileType = file.Extension;
                        f.Name=file.Name;
                        f.FileCreatedDateTime = file.CreationTime;
                        f.FileModifiedDateTime = file.LastWriteTime;
                        f.Path = String.Format("{0}/{1}", path, file.Name);
                        fileExplorerData.Add(f);
                    }

       }


    }
}
