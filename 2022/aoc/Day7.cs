using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day7
{
    private readonly AoCDir _tree = new() { Name = "/" };
    private List<AoCDir> list = new();

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

    [Test]
    public void Part1()
    {
        ListHierarchy(_tree);
        var result = list.Where(d => d.TotalSize <= 100000).Sum(x => x.TotalSize);

        Assert.That(result, Is.EqualTo(95437));
    }

    [Test]
    public void Part2()
    {
        const int diskCapacity = 70000000;
        const int spaceNeeded = 30000000;
        var freeSpace = diskCapacity - _tree.TotalSize;

        ListHierarchy(_tree);

        var result = GetSpateToCleanup(freeSpace, spaceNeeded);
        
        Assert.That(result, Is.EqualTo(24933642));
    }

    private long GetSpateToCleanup(long freeSpace, int spaceNeeded)
    {
        foreach (var dir in list.OrderBy(x => x.TotalSize))
        {
            if (freeSpace + dir.TotalSize >= spaceNeeded)
            {
                return dir.TotalSize;
            }
        }

        return 0;
    }

    private record AoCDir
    {
        public string Name { get; set; }

        public AoCDir? Parent { get; set; }
        public List<AoCDir> Dirs { get; set; } = new();
        public List<AoCFile> Files { get; set; } = new();

        public long TotalSize => Files.Sum(f => f.Size) + Dirs.Sum(d => d.TotalSize);
    }

    private record AoCFile
    {
        public string Name { get; set; }
        public long Size { get; set; }
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
            ["$", "ls"] => new Action(() =>
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

    private void ListHierarchy(AoCDir currentDir)
    {
        list.Add(currentDir);
        foreach (var dir in currentDir.Dirs)
        {
            ListHierarchy(dir);
        }
    }
}