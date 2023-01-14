namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Tile
    {
        private TileType type;

        public TileType Type
        {
            get => type;
            set => type = value;
        }


        public Tile(TileType _type)
        {
            type = _type;
        }

        /// <summary>
        /// modifies the player & the tile to what is appropriate based on <see cref="type"/>
        /// </summary>
        /// <param name="_player">the player to be modified</param>
        public void Enter(Player _player)
        {
            switch (type)
            {
                case TileType.tree:
                    _player.Wood += 1;
                    type = TileType.grass;
                    break;

                case TileType.axe:
                    _player.HasAxe = true;
                    type = TileType.grass;
                    break;

                case TileType.food:
                    _player.IsHungry = false;
                    break;
            };
        }

        /// <summary>
        /// gets the message that should be displayed upon entering this tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <param name="_direction">the direction the player was traveling in</param>
        /// <returns>the message based on <see cref="type"/></returns>
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
