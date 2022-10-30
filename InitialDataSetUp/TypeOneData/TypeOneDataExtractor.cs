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

            string zipFilePath = directoryInfo.FullName + "\\" + ZipFolderName;
            string extractionPath = directoryInfo.FullName + "\\" + ZipFolderName + "extract";
            string dataPath = extractionPath + "\\data\\";

            System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractionPath);

            DirectoryInfo dataInfo = new DirectoryInfo(dataPath);
            FileInfo[] seasonsFiles = dataInfo.GetFiles();

            foreach (FileInfo season in seasonsFiles)
            {
                if(season.Extension == ".csv")
                {
                    using (var reader = new StreamReader(season.FullName))
                    {
                        int count = 0;
                        while (!reader.EndOfStream)
                        {
                            if (count != 0)
                            {
                                var splits = reader.ReadLine().Split('\n');
                                string[] split = splits[0].Split(',');

                                string club = split[2];
                                string club2 = split[3];

                                if (!ClubNames.Contains(club))
                                {
                                    ClubNames.Add(club);
                                }
                                if (!ClubNames.Contains(club2))
                                {
                                    ClubNames.Add(club2);
                                }

                            }
                            else
                            {
                                var splits = reader.ReadLine().Split('\n');
                            }
                            count++;

                        }
                    }
                }
            }

            System.IO.Directory.Delete(extractionPath, true);

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
