using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.Environment
{
    internal class LivingEntity
    {
        protected readonly string name;
        protected Guid guid;
        protected float maxHealth;
        protected float health;

        public LivingEntity(string _name, float _maxHealth, Guid _guid)
        {
            Debug.WriteLine($"created a living entity with the name: {_name}");

            maxHealth = _maxHealth;
            health = _maxHealth;
            guid = _guid;
            name = _name;
        }
    }
}
