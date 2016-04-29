using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebFolderExplorer.Repositories
{
    public class DriveInfoRepository
    {
        public DriveInfo[] Drives { get; }
        private DriveInfoRepository()
        {
            this.Drives = DriveInfo.GetDrives();
        }

        static DriveInfoRepository current;
        public static DriveInfoRepository Current
        {
            get { return current ?? (current = new DriveInfoRepository()); }
        }
    }
}