using J1P2_PRO_TextAdventure.Assets.SpecialItems;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Room
    {
        private readonly string name;
        private readonly DoorItem door;
        private readonly Item[] items;

        public DoorItem Door { get { return door; } }
        public string Name { get { return name; } }


        public Room(string _name, bool _isLocked, params Item[] _items)
        {
            name = _name;
            door = new DoorItem(_isLocked);

            List<Item> itemList = _items.ToList();
            itemList.Add(door);

            items = itemList.ToArray();
        }

        public virtual string OnEnter()
        {
            string output = $"You enter a {name} and you see";


            foreach (Item item in items)
            {
                string article = StartsWithVowel(item.Name) ? "an" : "a"; //if the item name starts with a vowel, the article is "an". otherwise it is "a"

                output += $", {article} " + item.Name;
            }

            return output + '.';
        }

        private bool StartsWithVowel(string _value)
        {
            switch (_value[0])
            {
                case 'a':
                    return true;

                case 'e':
                    return true;

                case 'i':
                    return true;

                case 'o':
                    return true;

                case 'u':
                    return true;

            }

            return false;
        }
    }
}
