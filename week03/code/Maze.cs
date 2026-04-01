/// <summary>
/// Defines a maze using a dictionary.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE

    /// <summary>
    /// Move left if possible
    /// </summary>
    public void MoveLeft()
    {
        // Plan:
        // 1. Get current position (x, y)
        // 2. Check if left is allowed (index 0)
        // 3. If false → throw error
        // 4. If true → decrease x by 1

        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX -= 1;
    }

    /// <summary>
    /// Move right if possible
    /// </summary>
    public void MoveRight()
    {
        // Plan:
        // index 1 represents right

        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX += 1;
    }

    /// <summary>
    /// Move up if possible
    /// </summary>
    public void MoveUp()
    {
        // Plan:
        // index 2 represents up

        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY -= 1;
    }

    /// <summary>
    /// Move down if possible
    /// </summary>
    public void MoveDown()
    {
        // Plan:
        // index 3 represents down

        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}