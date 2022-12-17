namespace J1P2_PRO_TextAdventure.Environment;

internal abstract class Room
{
    protected bool isGenerated = false;
    protected bool isHidden;

    /// <summary>
    /// whether the room is locked or not
    /// </summary>
    public abstract bool IsLocked
    {
        get;
    }


    /// <summary>
    /// Get's the tile's display character
    /// </summary>
    /// <returns>room's display character</returns>
    public virtual char GetDisplay()
    {
        if (isHidden == true)
        {
            return '.';
        }
        else
        {
            return ' ';
        }
    }

    /// <summary>
    /// generates the room
    /// </summary>
    protected void Generate()
    {
        if (isGenerated == true)
            throw new Exception("The room is already generated");
    }

    /// <summary>
    /// gets called when the player enters the room
    /// </summary>
    public abstract void Enter();
}
