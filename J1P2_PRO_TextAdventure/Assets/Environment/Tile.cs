using System.Diagnostics.Metrics;

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
                TileType.grass => $"You see nothing of interest here.",
                TileType.axe => "You found an axe!",
                TileType.food => "You found a can of beans, you ate the beans and feel recharged!",
                TileType.start => "This is where you landed after your fall, you see your RV up the mountain, burnt to a crisp.",
                TileType.water => ConditianalMessage(_player, "You used the boat to get on the water, you see something glistering in the distance.", "There is a lake here, you see something shining in the distance. However the water is too deep to swim safely when you are this exhausted."),
                TileType.tree => ConditianalMessage(_player, $"You chopped down the tree and got some wood, you now have {_player.Wood} wood.", "There is a tree here, you can't go through trees."),
                TileType.mountain => ConditianalMessage(_player, "You climb up the mountain.", "There is a mountain here, you are too hungry to climb."),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// checks if the player is allowed to enter the tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <returns><c>true</c> if the player is allowed to enter, otherwise <c>false</c></returns>
        public bool CanEnter(Player _player)
        {
            return type switch
            {
                TileType.water => _player.HasBoat,
                TileType.tree => _player.HasAxe,
                _ => true,
            };
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
