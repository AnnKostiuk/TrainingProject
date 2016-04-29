using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFolderExplorer.Models;
using WebFolderExplorer.Repositories;

namespace WebFolderExplorer.Controllers
{
    public class WebAPIController : ApiController
    {
        DriveInfoRepository drives = DriveInfoRepository.Current;
        public DriveInfo[] GetAllDrives()
        {
            return drives.Drives;
        }

        public DirectoryInfoItem GetDriveRootItem(string diskName)
        {
            DriveInfo NameDisk = drives.Drives.First(disk=>disk.Name==diskName);
            DirectoryInfoItem root = new DirectoryInfoItem(NameDisk.RootDirectory);
            

            return root;
        }
    }

}
