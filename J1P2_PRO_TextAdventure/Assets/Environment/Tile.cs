namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Tile
    {
        private TileType type;

        public TileType Type { get { return type; } }


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
                TileType.axe => "You found a rusty axe!",
                TileType.food => "You found a can of beans on a small island, you ate the beans and feel recharged!",
                TileType.start => "This is where you landed after your fall.",
                TileType.water => ConditianalMessage(_player, "You used the boat to get on the water.", "There is a lake here, you see something glistering in the distance. However, the water\n is too deep to swim safely when you are this exhausted."),
                TileType.tree => ConditianalMessage(_player, $"You chopped down the tree and got some wood, you now have {_player.Wood + 1} wood.", "There is a tree here; you can't go through trees."),
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
                TileType.tree => _player.HasAxe,
                TileType.mountain => !_player.IsHungry,
                TileType.shrubbery => false,
                _ => true,
            };;
            ;
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
