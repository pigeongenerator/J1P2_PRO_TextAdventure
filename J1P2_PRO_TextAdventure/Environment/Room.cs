using J1P2_PRO_TextAdventure.Environment.ItemTypes;
using J1P2_PRO_TextAdventure.GameScripts;


namespace J1P2_PRO_TextAdventure.Environment;

/// <summary>
/// 
/// </summary>
internal abstract class Room
{
    protected readonly List<Item> items;
    protected readonly Game game;
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
    public Room(Game _game, bool _isHidden, params Item[] _items)
    {
        isHidden = _isHidden;
        items = _items.ToList();
        game = _game;
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
    /// removes the given item from the room
    /// </summary>
    /// <returns>the item with the given name</returns>
    /// <exception cref="InvalidOperationException" />
    public void RemoveItem(Item _item)
    {
        int itemIndex = items.IndexOf(_item);

        if (itemIndex == -1)
            throw new InvalidOperationException($"The room does not contain this item {nameof(_item)}");

        items.RemoveAt(itemIndex);
    }


    /// <summary>
    /// gets called when the player enters the room
    /// </summary>
    public abstract void Enter();
}
