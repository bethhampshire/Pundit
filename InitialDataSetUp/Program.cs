using InitialDataSetUp;
using InitialDataSetUp.TypeOneData;
using System.Text;

var test = new TypeOneDataExtractor();

List<TypeOneDataModel> file = test.GetData();

file.ForEach(x => Console.WriteLine(x.Nationality + " " + x.LeagueName));