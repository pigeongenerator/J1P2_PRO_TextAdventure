namespace J1P2_PRO_TextAdventure.Environment.LivingEntities;

internal class PlayerEntity : LivingEntity
{
    private int rowPos, columnPos;

    public PlayerEntity(int _rowPos, int _columnPos) : base(72, 1.7F)
    {
        rowPos = _rowPos;
        columnPos = _columnPos;
    }

    public void MoveTo(int _row, int _column, Workshop _workshop)
    {
        _workshop.EnterRoom(_row, _column);
        rowPos = _row;
        columnPos = _column;
    }

    public (int row, int column) GetPosition()
    {
        return (rowPos, columnPos);
    }
}
