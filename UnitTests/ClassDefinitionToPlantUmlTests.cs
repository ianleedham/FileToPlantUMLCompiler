using FileToPlantUMLConsoleApp;

namespace UnitTests;

[TestClass]
public class ClassDefinitionToPlantUmlTests
{
    [TestMethod]
    public void CreatesPlantUmlTestName()
    {
        var properties = new ClassPropertiesForTest(className: "Test1");

        var result = PlantUMLGenerator.Generate(properties);
        
        Assert.IsTrue(result.Contains("class Test1 {"), result + "doesn't contain 'class Test1 {' ");
        Assert.IsTrue(result.Contains("}"), "doesnt contain }");
    }
    
    [TestMethod]
    public void CreatesPlantUmlTestName_Multiple_WithLineBreaks()
    {
        var class1Properties = new ClassPropertiesForTest(className: "Test1");
        var class2Properties = new ClassPropertiesForTest(className: "Test2");

        var result = PlantUMLGenerator.Generate(class1Properties, class2Properties);
        
        Assert.IsTrue(result.Contains("class Test1 {"), result + "doesn't contain 'class Test1 {' ");
        Assert.IsTrue(result.Contains("\n"), result + "doesn't contain line break");
        Assert.IsTrue(result.Contains("class Test2 {"), result + "doesn't contain 'class Test2 {' ");
        Assert.IsTrue(result.Count(x => x == '}') == 2, "contains wrong number of closing braces");
    }
    
    [TestMethod]
    public void CreatesPlantUml_WithDependency()
    {
        var class1Properties = new ClassPropertiesForTest(className: "Test1", "Test2");
        var class2Properties = new ClassPropertiesForTest(className: "Test2");

        var result = PlantUMLGenerator.Generate(class1Properties, class2Properties);
        
        Assert.IsTrue(result.Contains("\nTest1 -> Test2\n"), result + "doesn't contain \nTest1 -> Test2\n");
        // Assert.IsTrue(result.Count(x => x == ) == 2); assert only once
    }
    
    [TestMethod]
    public void CreatesPlantUml_With2Dependencies()
    {
        var class1Properties = new ClassPropertiesForTest(className: "Test1", "Test2", "Test3");

        var result = PlantUMLGenerator.Generate(class1Properties);
        
        Assert.IsTrue(result.Contains("\nTest1 -> Test2\n"), result + "doesn't contain \nTest1 -> Test2\n");
        Assert.IsTrue(result.Contains("\nTest1 -> Test3\n"), result + "doesn't contain \nTest1 -> Test3\n");
    }
}

public class ClassPropertiesForTest : IClassProperties
{
    public ClassPropertiesForTest(string className, params string[] dependencies)
    {
        ClassName = className;
        Dependencies = dependencies;
    }
    public string ConstructorParameters { get; }
    public string ClassName { get; }
    public IEnumerable<string> Dependencies { get; }
}