using J1P2_PRO_TextAdventure.Environment.ItemTypes;
using J1P2_PRO_TextAdventure.GameScripts;


namespace J1P2_PRO_TextAdventure.Environment.LivingEntities;

internal class PlayerEntity : LivingEntity
{
    private readonly List<Item> inventory;
    private int rowPos, columnPos;
    private Game game;

    public List<Item> Inventory
    {
        get { return inventory; }
    }



    public PlayerEntity(int _rowPos, int _columnPos, Game _game) : base(72, 1.7F)
    {
        inventory = new List<Item>();
        rowPos = _rowPos;
        columnPos = _columnPos;
        game = _game;
    }

    public void MoveTo(int _row, int _column, Workshop _workshop)
    {
        if (_workshop.IsRoomLocked(_row, _column) == false)
        {
            _workshop.EnterRoom(_row, _column);
            rowPos = _row;
            columnPos = _column;
        }
        else
        {
            game.WriteDialogue("It seems like this door is locked.");
        }
    }

    public void MoveRelative(int _relativeRows, int _relativeColumns, Workshop _workshop)
    {
        (int maxY, int maxX) = _workshop.GetMaxSize();

        int newRowPos = rowPos + _relativeRows;
        int newColumnPos = columnPos + _relativeColumns;

        if (newRowPos >= maxY || newRowPos < 0)
        {
            newRowPos = rowPos;
        }

        if (newColumnPos >= maxX || newColumnPos < 0)
        {
            newColumnPos = columnPos;
        }

        MoveTo(newRowPos, newColumnPos, _workshop);
    }

    public (int row, int column) GetPosition()
    {
        return (rowPos, columnPos);
    }
}
