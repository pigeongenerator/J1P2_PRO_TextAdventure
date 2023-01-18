namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Tile
    {
        private TileType type; //the tile's type

        public TileType Type { get => type; }


        public Tile(TileType _type)
        {
            type = _type; //sets the tile's type
        }

        /// <summary>
        /// gets the message that should be displayed upon entering this tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <returns>the message based on <see cref="Type"/></returns>
        public string OnEnter(Player _player)
        {
            return type switch //switch expression to return the correct message based on the tile's type
            {
                TileType.shrubbery => "You were unable to get through the shrubberies.",
                TileType.grass => "You see nothing of interest here.",
                TileType.axe => "You see a rusty axe hidden in the grass!",
                TileType.food => "You see a can of beans hidden in the grass!",
                TileType.start => "This is where you landed after your fall. Kind of.. eerie.",
                TileType.tree => "There is a small tree here.",
                TileType.water => ConditianalMessage(_player, "You used the boat to get on the water.", "There is a lake here, you see something glistering in the distance. However, the water\n is too deep to swim safely when you are this exhausted."), //a curtain string is returned based on if the player can enter the tile
                TileType.mountain => ConditianalMessage(_player, "You climbed up the mountain.", "This is the mountain you fell off, you are too hungry to climb. You see your RV up there, it's burnt to a crisp."),
                _ => throw new NotImplementedException($"unknown tile type {nameof(type)}") //default case, if an unknown type
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
            type = _castTo; //changes the type
        }

        /// <summary>
        /// conditional <see cref="type"/> cast <br/>
        /// casts the tile only if <see cref="type"/> matches <paramref name="_allowedCast"/>
        /// </summary>
        /// <param name="_castTo">the type to be casted to</param>
        /// <param name="_allowedCast">the type that <see cref="type"/> needs to match to cast</param>
        public void CastTile(TileType _castTo, TileType _allowedCast) //overloading the method with different parameters
        {
            if (type == _allowedCast) //checks if the type matches the allowed cast type
            {
                type = _castTo; //changes the type
            }
        }

        /// <summary>
        /// returns a message based on if the player is allowed to enter this tile
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_successEnterMessage"></param>
        /// <param name="_failedEnterMessage"></param>
        /// <returns>if the player is allowed to enter the tile, <paramref name="_successEnterMessage"/> is returned, otherwise <paramref name="_failedEnterMessage"/></returns>
        private string ConditianalMessage(Player _player, string _successEnterMessage, string _failedEnterMessage)
        {
            if (CanEnter(_player)) //checks if the player can enter this tile
            {
                return _successEnterMessage; //returns the successMessage
            }

            return _failedEnterMessage; //returns the failed message
        }
    }
}
