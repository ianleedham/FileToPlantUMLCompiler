using FileToPlantUMLConsoleApp;

namespace UnitTests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void CanParseClassName()
    {
        var subject = new ClassProperties("class Test1 {}");
        
        Assert.AreEqual("Test1", subject.ClassName);
    }
    
    [TestMethod]
    public void CanParseConstructorParametersWithNoParameters()
    {
        var subject = new ClassProperties(@"class Test1 {
            Test1 (){}
        }");
        
        Assert.AreEqual("", subject.ConstructorParameters);
    }
    
    [TestMethod]
    public void CanParseConstructorParametersWithOneParameterAndNoSpaces()
    {
        var subject = new ClassProperties(@"class Test1 {
            Test1(TestClass2 testClass2){}
        }");
        
        Assert.AreEqual("TestClass2 testClass2", subject.ConstructorParameters);
    }
    
    [TestMethod]
    public void CanParseConstructorParametersWithOneParameterAndOneSpace()
    {
        var p = new ClassProperties(@"class Test1 {
            Test1 (TestClass2 testClass2){}
        }");
        var constructorParameters = p.ConstructorParameters;
        
        Assert.AreEqual("TestClass2 testClass2", constructorParameters);
    }
    
    [TestMethod]
    public void CanParseConstructorParametersWithOneParameterAndThreeSpaces()
    {
        var subject = new ClassProperties(@"class Test1 {
            Test1   (TestClass2 testClass2){}
        }");
        
        Assert.AreEqual("TestClass2 testClass2", subject.ConstructorParameters);
    }
    
    [TestMethod]
    public void CanParseDependencies_WhenOnlyOne()
    {
        var subject = new ClassProperties(@"class Test1 {
            Test1   (TestClass2 testClass2){}
        }");
        
        Assert.AreEqual("TestClass2", subject.Dependencies.First());
        Assert.AreEqual(1, subject.Dependencies.Count());
    }
    
    [TestMethod]
    public void CanParseDependencies_WhenTwo()
    {
        var subject = new ClassProperties(@"class Test1 {
            Test1   (TestClass2 testClass2, TestClass3 test){}
        }");
        var dependencies = subject.Dependencies.ToList();
        Assert.AreEqual("TestClass2", dependencies[0]);
        Assert.AreEqual("TestClass3", dependencies[1]);
        Assert.AreEqual(2, dependencies.Count);
    }
}