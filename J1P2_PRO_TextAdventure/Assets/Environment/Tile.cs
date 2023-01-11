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

        public bool CanEnter(Player _player)
        {
            switch (type)
            {
                case TileType.water:
                    return _player.HasBoat;

                case TileType.tree:
                    return TreeTile(_player);

                case TileType.axe:
                    return AxeTile(_player);

                default:
                    return true;
            };
        }

        private bool TreeTile(Player _player)
        {
            if (_player.HasAxe)
            {
                _player.Wood += 1;
                type = TileType.grass;
                return true;
            }

            return false;
        }

        private bool AxeTile(Player _player)
        {
            _player.HasAxe = true;
            type = TileType.grass;
            return true;
        }
    }
}
