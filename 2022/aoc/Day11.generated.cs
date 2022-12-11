
// generated file - don't change manually

namespace aoc; 

public partial class Day11
{
    /// <summary>
    /// generated method
    /// </summary>     
    private List<(int Value, bool IsProcessed)> CreateTuples(int[] arr) => 
        arr.Select(x => (x, false)).ToList();
            
    /// <summary>
    /// generated method
    /// </summary>      
    private Dictionary<int, Monkey> SetupMonkeys()
    {
        return new Dictionary<int, Monkey> (){
        
                
                { 0, new Monkey {
                        Items = CreateTuples(new[]{ 79, 98 }),
                        Operation = (old) => old * 19,
                        DivideBy = 23,
                        OnTrue = 2,
                        OnFalse = 3,
                    }
                },
                
                { 1, new Monkey {
                        Items = CreateTuples(new[]{ 54, 65, 75, 74 }),
                        Operation = (old) => old + 6,
                        DivideBy = 19,
                        OnTrue = 2,
                        OnFalse = 0,
                    }
                },
                
                { 2, new Monkey {
                        Items = CreateTuples(new[]{ 79, 60, 97 }),
                        Operation = (old) => old * old,
                        DivideBy = 13,
                        OnTrue = 1,
                        OnFalse = 3,
                    }
                },
                
                { 3, new Monkey {
                        Items = CreateTuples(new[]{ 74 }),
                        Operation = (old) => old + 3,
                        DivideBy = 17,
                        OnTrue = 0,
                        OnFalse = 1,
                    }
                },
        

        };
    }
}