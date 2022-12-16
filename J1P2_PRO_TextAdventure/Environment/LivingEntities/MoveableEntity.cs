namespace J1P2_PRO_TextAdventure.Environment.LivingEntities
{
    internal class MoveableEntity : LivingEntity
    {
        protected int positionX, positionY;

        public MoveableEntity(string _name, float _maxHealth, Guid _guid, int _posX, int _posY) : base(_name, _maxHealth, _guid)
        {
            SetPosition(_posX, _posY);
            maxHealth = _maxHealth;
            health = _maxHealth;
        }

        public (int posX, int posY) GetPosition()
        {
            return (positionX, positionY);
        }

        public void SetPosition(int _posX, int _posY)
        {
            positionX = _posX;
            positionY = _posY;
        }
    }
}
