using InitialDataSetUp.TypeOneData;
using System.IO.Compression;
using System.Text;

namespace InitialDataSetUp
{
    public class TypeOneDataExtractor
    {
        public List<TypeOneDataModel> GetData()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("C:/Projects/pundit/Data/typeOneData");
            FileInfo[] ZipFolders = directoryInfo.GetFiles();

            List<TypeOneDataModel> typeOneDataModels = new List<TypeOneDataModel>();

            foreach (FileInfo ZipFolder in ZipFolders)
            {
                TypeOneDataModel typeOneDataModel = new TypeOneDataModel();

                string[] splitFolderName = ZipFolder.Name.Split('-');

                typeOneDataModel.Nationality = splitFolderName[0];

                typeOneDataModel.LeagueName = GetLeagueName(splitFolderName);

                typeOneDataModel.Clubs = GetClubNames(ZipFolder.Name, directoryInfo);

                typeOneDataModels.Add(typeOneDataModel);
            }

            return typeOneDataModels;
        }

        private List<string> GetClubNames(string ZipFolderName, DirectoryInfo directoryInfo)
        {
            List<string> ClubNames = new List<string>();

            string zipFilePath = ZipFolderName;
            string extractionPath = directoryInfo.FullName;
            Console.WriteLine(zipFilePath);
            Console.WriteLine(extractionPath);

            return ClubNames;
        }

        private string GetLeagueName(string[] splitFolderName)
        {
            var leagueName = new StringBuilder();

            foreach (string splitFolder in splitFolderName)
            {
                if (splitFolder == splitFolderName.Last())
                {
                    string[] finalSplit = splitFolder.Split('_');
                    leagueName.Append(finalSplit[0]);
                } 
                else if (splitFolder != splitFolderName.First())
                {
                    leagueName.Append(splitFolder + " ");
                }
            }
            return leagueName.ToString();
        }
    }
}
