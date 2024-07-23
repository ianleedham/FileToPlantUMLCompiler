namespace FileToPlantUMLConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        
        // var filePath = "C:\\Users\\ukilee\\Code\\FileToPlantUMLCompiler\\FileToPlantUMLConsoleApp\\TestFile.cs";
        // var filePath = "C:\\Users\\ukilee\\Code\\quan-review\\RoutineQuan\\Waters.RoutineQuan.BusinessLogic\\UseCases\\ResultSets\\GetResultSetsUseCase.cs";
        var filePath = "/home/brian/Development/CreatePlantUMLPlugin/FileToPlantUMLConsoleApp/TestFile.cs";
        var fileContents = File.ReadAllText(filePath);
        var p = new ClassProperties(fileContents);
        var uml = PlantUMLGenerator.Generate(p);
        Console.Write(uml);
    }
}