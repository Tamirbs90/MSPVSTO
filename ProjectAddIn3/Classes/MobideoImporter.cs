using Microsoft.Office.Interop.MSProject;
using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace ProjectAddIn3.Classes
{
    public class MobideoImporter : IMobideoImporter
    {
        public async Task ImportFilesToMobideo(IEnumerable<SubProjectWrapper> selectedSubProjects)
        {
            var subProjectsFiles = CreateSubProjectFiles(selectedSubProjects);
            foreach(var subProjectFile in subProjectsFiles)
            {
                await UploadFileToMobideo(subProjectFile.Item1, subProjectFile.Item2);
            }

        }

        private async Task UploadFileToMobideo(string filePath, Stream stream)
        {
            IFileUploader mobideoFileUploader = FileUploaderFactory.CreateFileUploader();
            await mobideoFileUploader.UploadFile(filePath, stream);
        }

        private List<Tuple<string,Stream>> CreateSubProjectFiles(IEnumerable<SubProjectWrapper> selectedSubProjects)
        {
            var subProjectFiles = new List<Tuple<string,Stream>>();    
            foreach (var subProject in selectedSubProjects)
            {
                var currrentSubProject = subProject.SubProjectLegacyObject;
                using (FileStream fileStream = new FileStream(currrentSubProject.Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    subProjectFiles.Add(new Tuple<string, Stream>(currrentSubProject.Path, fileStream));
                }
            }

            return subProjectFiles;
        }
    }
}
