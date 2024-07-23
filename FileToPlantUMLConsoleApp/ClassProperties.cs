using System.Text.RegularExpressions;

namespace FileToPlantUMLConsoleApp;

public class ClassProperties : IClassProperties
{
    private string _fileContents;
    
    public ClassProperties(string fileContents)
    {
        _fileContents = fileContents;
    }

    public string ConstructorParameters
    {
        get
        {
            var reg = new Regex($"(?<={ClassName}\\s*\\().*(?=\\))");
            return reg.Match(_fileContents).Value;
        }
    }

    public string ClassName
    {
        get
        {
            var classNameReg = new Regex("(?<=class\\s).\\S*");
            return classNameReg.Match(_fileContents).Value;
        }
    }

    public IEnumerable<string> Dependencies
    {
        get
        {
            return ConstructorParameters
                .Split(',').Select(x => x.Trim().Split(' ').First());
        }
    }
}

public interface IClassProperties
{
    string ConstructorParameters { get; }
    string ClassName { get; }
    IEnumerable<string> Dependencies { get; }
    
}
