using J1P2_PRO_TextAdventure.Assets;
using J1P2_PRO_TextAdventure.Assets.SpecialItems;
using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class MainLoop : Loop
    {
        private readonly Workshop workshop;
        private readonly Player player;


        public MainLoop(Workshop _workshop, Player _player)
        {
            workshop = _workshop;
            player = _player;
        }

        protected override bool Check()
        {
            Debug.WriteLine($"passed {nameof(MainLoop)} {nameof(Check)}, returning true.");
            Debug.WriteLine($"the current player position is: {player.Position}, room name: {workshop.GetRoom(player.Position.row, player.Position.column).Name}");
            return true;
        }

        protected override void DoLoop()
        {
            string input;
            Room playerRoom = GetPlayerRoom();

            Console.WriteLine($"\nyou find yourself in {GetArticle(playerRoom.Name)} {playerRoom.Name}, you see{ListItems(playerRoom.Items)}");
            input = GetInput("what do you want to do?");

            //TEMPORARY COMMAND SYSTEM PLEASE INPROVE
            if ( input.StartsWith("open") )
            {

                OpenDoor(playerRoom.Door);
            }
            else if ( input.StartsWith("go") )
            {
                GoThroughDoor(playerRoom.Door);
            }
            else if ( input.StartsWith("take") )
            {
                input = GetInput("what do you want to take?");
                TakeItem(input, playerRoom);
            }
            else if ( input.StartsWith("inventory") )
            {
                string itemListed = ListItems(player.InventoryItems);
                Console.WriteLine($"you have{itemListed}.\n");
            }
            else if ( input.StartsWith("eat") )
            {
                EatItem(playerRoom);
            }
            else
            {
                Console.WriteLine($"you don't know this thing: {input}\n");
            }
        }

        /// <summary>
        /// creates the prompt for eating items and eats the item if one was found
        /// </summary>
        /// <param name="_playerRoom">set's the room where the item needs to be searched</param>
        private void EatItem(Room _playerRoom)
        {
            string itemName = GetInput("what do you want to eat?");
            Item eatItem;

            if ( player.HasItem(itemName) )
            {
                eatItem = player.GetItem(itemName);
                if ( eatItem.IsEatable )
                {
                    player.RemoveItem(eatItem);
                }
            }
            else if ( _playerRoom.HasItem(itemName, true) )
            {
                eatItem = _playerRoom.GetItem(itemName, true);
                if ( eatItem.IsEatable )
                {
                    _playerRoom.RemoveItem(itemName);
                }
            }
            else
            {
                Console.WriteLine($"You did not see this item: {itemName}\n");
                return;
            }

            Console.WriteLine($"{eatItem.OnEat()}\n");
        }

        /// <summary>
        /// takes an item from the room and puts it into the player's inventory
        /// </summary>
        /// <param name="_itemName">set's the name of the item to take</param>
        /// <param name="_playerRoom">set's the room that should be looked in for the item</param>
        private void TakeItem(string _itemName, Room _playerRoom)
        {
            if ( _playerRoom.HasItem(_itemName) == false )
            {
                Console.WriteLine($"you don't see this thing: {_itemName}\n");
                return;
            }

            Console.WriteLine($"you took the {_itemName}.\n");
            player.AddToInventory(_playerRoom.GetItem(_itemName));
            _playerRoom.RemoveItem(_itemName);
        }

        /// <summary>
        /// get's the players input with a prompt, will retry endlessly until an input that is neither null or string.Empty
        /// </summary>
        /// <param name="_prompt">sets the prompt</param>
        /// <returns>a string</returns>
        private string GetInput(string _prompt)
        {
            string? input;

            Console.WriteLine(_prompt);
            Console.Write(" > ");
            (int x, int y) = Console.GetCursorPosition();

            do
            {
                Console.SetCursorPosition(x, y);
                input = Console.ReadLine();
            }
            while ( string.IsNullOrEmpty(input) );

            Console.WriteLine();

            return input;
        }

        /// <summary>
        /// creates a list of the items given
        /// </summary>
        /// <param name="_itemList">The list of items to check</param>
        /// <returns>a list with the proper article for each item</returns>
        private string ListItems(Item[] _itemList)
        {
            string output = string.Empty;

            foreach ( Item item in _itemList )
            {
                string itemName = item.Name;

                if ( IsOpenDoor(item) )
                {
                    itemName = "open " + itemName;
                }


                output += $", {GetArticle(itemName)} {itemName}";
            }

            if ( _itemList.Length == 0 )
            {
                output += " nothing";
            }

            return output;
        }

        /// <summary>
        /// makes the player go through a door and moves them to the new location
        /// </summary>
        /// <param name="_door">set's the door that the player needs to go through</param>
        private void GoThroughDoor(DoorItem _door)
        {
            (int row, int column) = _door.LeadsTo;

            if ( _door.IsOpen == false )
            {
                Console.WriteLine("you can't go through closed doors silly!\n");
                return;
            }
            if ( _door.IsLocked )
            {
                Console.WriteLine("this door is locked!\n");
                return;
            }

            Console.WriteLine("you walked through the door.\n");
            player.MoveTo(row, column, workshop);
        }

        /// <summary>
        /// opens the door, checks if the door is locked
        /// </summary>
        /// <param name="_door">set's the door to be opened</param>
        private void OpenDoor(DoorItem _door)
        {
            Console.WriteLine(_door.OnOpen() + '\n');
        }

        /// <summary>
        /// gets if the current item is an open door
        /// </summary>
        /// <param name="_item">set's the item to check</param>
        /// <returns>true if it is an open door, otherwise false</returns>
        private bool IsOpenDoor(Item _item)
        {
            if ( _item.GetType() == typeof(DoorItem) )
            {
                DoorItem door = (DoorItem)_item;
                return door.IsOpen;
            }

            return false;
        }

        /// <summary>
        /// get's the room the player is currently standing in
        /// </summary>
        /// <returns>the room the player is standing in</returns>
        private Room GetPlayerRoom()
        {
            (int playerRowPos, int playerColumnPos) = workshop.Player.Position;
            Room playerRoom = workshop.GetRoom(playerRowPos, playerColumnPos);

            return playerRoom;
        }

        /// <summary>
        /// get's the article for a string
        /// </summary>
        /// <param name="_getFor">set's the value that the article should be get from</param>
        /// <returns>"an" if the string starts with a vowel, "a" if it doesn't</returns>
        private string GetArticle(string _getFor)
        {
            string article;

            article = StartsWithVowel(_getFor) ? "an" : "a"; //if the item name starts with a vowel, the article is "an". otherwise it is "a"

            return article;

            bool StartsWithVowel(string _value)
            {
                switch ( _value[0] )
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

                    default:
                        return false;
                }
            }
        }
    }
}
