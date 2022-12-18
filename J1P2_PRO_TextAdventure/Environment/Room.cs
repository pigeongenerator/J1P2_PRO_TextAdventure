namespace J1P2_PRO_TextAdventure.Environment;

/// <summary>
/// 
/// </summary>
internal abstract class Room
{
    protected List<Item> items;
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
    /// 
    /// </summary>
    /// <param name="_isHidden"></param>
    public Room(bool _isHidden)
    {
        isHidden = _isHidden;
        items = new List<Item>();
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
    /// gets called when the player enters the room
    /// </summary>
    public abstract void Enter();
}
