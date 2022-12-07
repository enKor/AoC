using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day7
{
    private readonly AoCDir _tree = new() { Name = "/" };

    [SetUp]
    public void SetUp()
    {
        var data = File.ReadAllLines("Day7.txt");

        var currentDir = _tree;

        foreach (var line in data)
        {
            var prompt = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            currentDir = Run(prompt, currentDir);
        }

    }

    private AoCDir Run(string[] prompt, AoCDir currentDir)
    {
        var resultingDir = currentDir;

        (prompt switch
        {
            ["$", "cd", "/"] => new Action(() =>
            {
                resultingDir = _tree;
            }),
            ["$", "cd", ".."] => new Action(() =>
            {
                resultingDir = currentDir.Parent;
            }),
            ["$", "cd", var dirName] => new Action(() =>
            {
                resultingDir = currentDir.Dirs.Single(d => d.Name == dirName);
            }),
            ["ls", var dirName] => new Action(() =>
            {
                // nothing
            }),
            ["dir", var dirName] => new Action(() =>
            {
                currentDir.Dirs.Add(new AoCDir
                {
                    Name = dirName, 
                    Parent = currentDir
                });
            }),
            [var size, var fileName] => new Action(() =>
            {
                currentDir.Files.Add(new AoCFile
                {
                    Name = fileName,
                    Size = Convert.ToInt64(size)
                });
            }),
            _ => throw new NotImplementedException()
        })();

        return resultingDir;
    }

    [Test]
    public void Part1()
    {
        //var result = tree
        //Assert.That(result, Is.EqualTo(95437));
    }

    [Test]
    public void Part2()
    {

        //Assert.That(result, Is.EqualTo(19));
    }

    private class AoCDir
    {
        public string Name { get; set; }

        public AoCDir? Parent { get; set; }
        public List<AoCDir> Dirs { get; set; } = new();
        public List<AoCFile> Files { get; set; } = new();

        public long TotalSize => Files.Sum(f => f.Size) + Dirs.Sum(d => d.TotalSize);
    }

    private class AoCFile
    {
        public string Name { get; set; }
        public long Size { get; set; }
    }
}
