namespace FileToPlantUMLConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var filePath = "/home/brian/Development/CreatePlantUMLPlugin/FileToPlantUMLConsoleApp/TestFile.cs";
        var fileContents = File.ReadAllText(filePath);
        var p = new ClassProperties(fileContents);
        var className = p.ClassName;
        var constructorParameters = p.ConstructorParameters;
    }
}