namespace Ws.Architecture.Tests.Tests;

public class SimpleDependenciesTests
{
    public static readonly TheoryData<string, string> TestData = SolutionUtils.GetProjectFiles();

    [Theory]
    [MemberData(nameof(TestData))]
    public void Shared_Dependency_Must_Be_Private(string file, string filePath)
    {
        ProjectFileUtils.CheckPrivateProject(filePath, "Ws.Shared")
            .Should().BeTrue(Path.GetFileName(file));
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void EntityFramework_Dependency_Must_Be_Private(string file, string filePath)
    {
        ProjectFileUtils.CheckPrivateProject(filePath, "Ws.Database.EntityFramework")
            .Should().BeTrue(Path.GetFileName(file));
    }
}