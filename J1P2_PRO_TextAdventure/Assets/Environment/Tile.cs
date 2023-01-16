namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Tile
    {
        private TileType type;

        public TileType Type { get => type; }


        public Tile(TileType _type)
        {
            type = _type;
        }

        /// <summary>
        /// gets the message that should be displayed upon entering this tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <returns>the message based on <see cref="Type"/></returns>
        public string OnEnter(Player _player)
        {
            return type switch
            {
                TileType.shrubbery => "You were unable to get through the shrubberies.",
                TileType.grass => "You see nothing of interest here.",
                TileType.axe => "You see a rusty axe hidden in the grass!",
                TileType.food => "You see a can of beans hidden in the grass!",
                TileType.start => "This is where you landed after your fall. Kind of.. eerie.",
                TileType.tree => "There is a small tree here.",
                TileType.water => ConditianalMessage(_player, "You used the boat to get on the water.", "There is a lake here, you see something glistering in the distance. However, the water\n is too deep to swim safely when you are this exhausted."),
                TileType.mountain => ConditianalMessage(_player, "You climbed up the mountain.", "This is the mountain you fell off, you are too hungry to climb. You see your RV up there, it's burnt to a crisp."),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// checks if the player is allowed to enter the tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <returns><see langword="true"/> if the player is allowed to enter, otherwise <see langword="false"/></returns>
        public bool CanEnter(Player _player)
        {
            return type switch
            {
                TileType.water => _player.HasBoat,
                TileType.mountain => !_player.IsHungry,
                TileType.shrubbery => false,
                _ => true,
            };
        }

        /// <summary>
        /// casts this tile's type to another
        /// </summary>
        /// <param name="_castTo">the type to be casted to</param>
        public void CastTile(TileType _castTo)
        {
            type = _castTo;
        }

        /// <summary>
        /// conditional <see cref="type"/> cast <br/>
        /// casts the tile only if <see cref="type"/> matches <paramref name="_allowedCast"/>
        /// </summary>
        /// <param name="_castTo">the type to be casted to</param>
        /// <param name="_allowedCast">the type that <see cref="type"/> needs to match to cast</param>
        public void CastTile(TileType _castTo, TileType _allowedCast)
        {
            if (type == _allowedCast)
            {
                type = _castTo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_successEnterMessage"></param>
        /// <param name="_failedEnterMessage"></param>
        /// <returns></returns>
        private string ConditianalMessage(Player _player, string _successEnterMessage, string _failedEnterMessage)
        {
            if (CanEnter(_player))
            {
                return _successEnterMessage;
            }

            return _failedEnterMessage;
        }
    }
}
