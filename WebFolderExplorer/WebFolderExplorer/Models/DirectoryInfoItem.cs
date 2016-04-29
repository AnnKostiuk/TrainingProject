using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebFolderExplorer.Models
{
    public class DirectoryInfoItem
    {
        const int size10mb = 10 * 1024 * 1024;
        const int size100mb = 10*size10mb;

        public DirectoryInfo Current { get; }
        public DirectoryInfoItem[] Dirs { get; private set; }
        public FileInfo[] Files { get; private set; }

        public int SmallFilesCount { get; private set; }
        public int MediumFilesCount { get; private set; }
        public int LargeFilesCount { get; private set; }

        public DirectoryInfoItem(DirectoryInfo current)
        {
            Current = current;
            Init();
        }

        public void Init()
        {
            Files = Current.GetFiles();
            DirectoryInfo[] dirs2 = Current.GetDirectories();
            Dirs = new DirectoryInfoItem[dirs2.Length];

            for (int i = 0; i < dirs2.Length; i++)
            {
                Dirs[i] = new DirectoryInfoItem (dirs2[i]);
            }

            CalculateCountOfFiles();    
        }


        void CalculateCountOfFiles()
        {
            foreach (FileInfo file in Files)
            {
                if (file.Length < size10mb)
                {
                    SmallFilesCount++;
                }

                if ((file.Length > size10mb) && (file.Length < size100mb))
                {
                    MediumFilesCount++;
                }
                if (file.Length > size100mb)
                {
                    LargeFilesCount++;
                }
            }

            foreach (DirectoryInfoItem dir in Dirs)
            {
                SmallFilesCount += dir.SmallFilesCount;
                MediumFilesCount += dir.MediumFilesCount;
                LargeFilesCount += dir.LargeFilesCount;
            }
        } 
    }
}