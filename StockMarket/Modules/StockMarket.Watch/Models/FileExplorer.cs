using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Watch.Models
{
    public class FileExplorer 
    {
        public FileExplorer()
        {
         //  SubDirectories= new List<FileExplorer>();
        }
        public string Name { get; set; }
        public DateTime FileCreatedDateTime { get; set; }

        public DateTime FileModifiedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public string Size { get; set; }

        public string FileType { get; set; }

        public string Path { get; set; }

       // public List<FileExplorer> SubDirectories { get; set; }
    }
}
