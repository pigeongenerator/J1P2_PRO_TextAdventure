using J1P2_PRO_TextAdventure.Environment.ItemTypes;
using J1P2_PRO_TextAdventure.Environment.LivingEntities;
using J1P2_PRO_TextAdventure.Environment.Rooms;
using J1P2_PRO_TextAdventure.GameScripts;

namespace J1P2_PRO_TextAdventure.Environment;

internal class Workshop
{
    private readonly Room[,] workshop;
    private readonly PlayerEntity player;
    private readonly Game game;

    public Workshop(Game _game)
    {
        game = _game;
        workshop = GenRooms(3, 5);
        player = new PlayerEntity(2, 0, _game);
    }

    public PlayerEntity GetPlayer()
    {
        return player;
    }

    public (int maxRows, int maxColumns) GetMaxSize()
    {
        return (workshop.GetLength(0), workshop.GetLength(1));
    }

    public char[,] GetRender()
    {
        int xLength = workshop.GetLength(0);
        int yLength = workshop.GetLength(1);

        char[,] render = new char[xLength, yLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                render[x, y] = workshop[x, y].GetDisplay();
            }
        }

        (int playerX, int playerY) = player.GetPosition();

        render[playerX, playerY] = 'O';

        return render;
    }

    /// <summary>
    /// generates the rooms
    /// </summary>
    /// <param name="_rows">sets the width of the generated rooms</param>
    /// <param name="_columns">sets the length of the generated rooms</param>
    /// <returns></returns>
    private Room[,] GenRooms(int _rows, int _columns)
    {
        Room[,] rooms = new Room[_rows, _columns];
        rooms = new Room[3, 1]
        {
            { new Office(game, 1) },
            { new Hallway(game, new Item("key")) },
            { new Start(game) }
        };

        return rooms;
    }

    public void EnterRoom(int _posX, int _posY)
    {
        Room enteredRoom = workshop[_posX, _posY];
        enteredRoom.Enter();
    }

    public bool IsRoomLocked(int _row, int _column)
    {
        return workshop[_row, _column].IsLocked;
    }
}
