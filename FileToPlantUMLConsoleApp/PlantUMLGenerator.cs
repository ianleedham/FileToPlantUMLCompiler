namespace FileToPlantUMLConsoleApp;

public class PlantUMLGenerator
{
    public static string Generate(params IClassProperties[] properties)
    {
        string result = string.Empty;
        foreach (var property in properties)
        {
            result += Generate(property) + "\n";
        }

        return result;
    }
    
    public static string Generate(IClassProperties properties)
    {
        var result = string.Empty;

        result += AddClass(properties.ClassName);
        foreach (var dependencyName in properties.Dependencies)
        {
            result += "\n" + $@"{properties.ClassName} -> {dependencyName}" + "\n";
        }

        return result;
    }
    
    public static string AddClass(string testName)
    {
        return $"class {testName} " + "{" + "}";
    }
}