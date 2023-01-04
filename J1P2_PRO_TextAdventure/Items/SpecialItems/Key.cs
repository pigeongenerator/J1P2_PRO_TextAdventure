namespace J1P2_PRO_TextAdventure.Items.SpecialItems
{
    internal class Key : Item
    {
        private int keyId;

        /// <summary>
        /// defines a new key
        /// </summary>
        /// <param name="_keyName">sets the name of the key</param>
        /// <param name="_keyId">sets the id of the key which is used to unlock the corresponding door</param>
        public Key(string _keyName, int _keyId) : base($"{_keyName} key", new ItemBuilder().SetOnEat("You don't think this is a good idea; you might need this!"))
        {
            keyId = _keyId;
        }

        public override string OnUse()
        {
            return base.OnUse();
        }
    }
}
