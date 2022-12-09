using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day8
{
    private List<string> input;

    [SetUp]
    public void SetUp()
    {
        var inputFile= File.ReadAllLines("Day8.txt");
        input = new List<string>(inputFile);
    }

    [Test]
    public void Part1()
    {
        var grid = new List<List<int>>();
        foreach (var line in input)
        {
            var row = new List<int>();

            foreach (var tree in line)
            {
                row.Add(Convert.ToInt32(tree));
            }

            grid.Add(row);
        }

        int treesVisible = 0;

        treesVisible += (grid.Count * 2) + (grid[0].Count * 2) - 4;

        for (int row = 1; row < grid.Count - 1; row++)
        {
            for (int col = 1; col < grid[row].Count - 1; col++)
            {
                int currentHeight = grid[row][col];

                bool isVisible = true;

                //left check
                for (int leftCol = col - 1; leftCol >= 0; leftCol--)
                {
                    if (grid[row][leftCol] >= currentHeight)
                    {
                        isVisible = false;
                        break;
                    }
                }
                if (isVisible)
                {
                    treesVisible++;
                    continue;
                }
                isVisible = true;
                //right check
                for (int rightCol = col + 1; rightCol < grid[row].Count; rightCol++)
                {
                    if (grid[row][rightCol] >= currentHeight)
                    {
                        isVisible = false;
                        break;
                    }
                }
                if (isVisible)
                {
                    treesVisible++;
                    continue;
                }
                isVisible = true;
                //up check
                for (int upRow = row - 1; upRow >= 0; upRow--)
                {
                    if (grid[upRow][col] >= currentHeight)
                    {
                        isVisible = false;
                        break;
                    }
                }
                if (isVisible)
                {
                    treesVisible++;
                    continue;
                }
                isVisible = true;
                //down check
                for (int downRow = row + 1; downRow < grid.Count; downRow++)
                {
                    if (grid[downRow][col] >= currentHeight)
                    {
                        isVisible = false;
                        break;
                    }
                }
                if (isVisible)
                {
                    treesVisible++;
                }
            }
        }
        Assert.That(treesVisible, Is.EqualTo(21));
    }

    [Test]
    public void Part2()
    {
        var grid = new List<List<int>>();
        foreach (var line in input)
        {
            var row = new List<int>();

            foreach (var tree in line)
            {
                row.Add(Convert.ToInt32(tree));
            }

            grid.Add(row);
        }

        int bestScenicScore = 0;

        for (int row = 0; row < grid.Count; row++)
        {
            for (int col = 0; col < grid[row].Count; col++)
            {
                int currentHeight = grid[row][col];

                int left = 0;
                int right = 0;
                int up = 0;
                int down = 0;


                //left check
                for (int leftCol = col - 1; leftCol >= 0; leftCol--)
                {
                    left++;
                    if (grid[row][leftCol] >= currentHeight)
                    {
                        break;
                    }
                }

                //right check
                for (int rightCol = col + 1; rightCol < grid[row].Count; rightCol++)
                {
                    right++;
                    if (grid[row][rightCol] >= currentHeight)
                    {
                        break;
                    }
                }

                //up check
                for (int upRow = row - 1; upRow >= 0; upRow--)
                {
                    up++;
                    if (grid[upRow][col] >= currentHeight)
                    {
                        break;
                    }
                }

                //down check
                for (int downRow = row + 1; downRow < grid.Count; downRow++)
                {
                    down++;
                    if (grid[downRow][col] >= currentHeight)
                    {
                        break;
                    }
                }

                int scenicScore = left * right * up * down;

                if (scenicScore > bestScenicScore)
                {
                    bestScenicScore = scenicScore;
                }
            }
        }
        Assert.That(bestScenicScore, Is.EqualTo(8));
    }

    record Tree(int Y, int X);

}
