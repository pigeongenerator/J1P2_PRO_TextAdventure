using J1P2_PRO_TextAdventure.Assets;
using J1P2_PRO_TextAdventure.Assets.Items;
using J1P2_PRO_TextAdventure.Assets.Items.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.Rooms;
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
            Debug.WriteLine($"the current player position is: {player.Position}, room name: {workshop.GetRoom(player.Position.row, player.Position.column).RoomName}");
            return player.Position != (0, 0);
        }

        protected override void DoLoop()
        {
            (string command, string argument) input;
            Room playerRoom = GetPlayerRoom();

            Console.WriteLine($"\nyou find yourself in {GetArticle(playerRoom.RoomName)} {playerRoom.RoomName}, you see{ListItems(playerRoom.RoomItems)}");
            input = GetCommandInput("what do you want to do?");

            //TEMPORARY COMMAND SYSTEM
            switch ( input.command )
            {
                case "go":
                    GoThroughDoor(playerRoom.RoomDoor);
                    break;

                case "open":
                    Console.WriteLine(playerRoom.RoomDoor.OnUse() + '\n');
                    break;

                case "take":
                    TakeItem(input.argument, playerRoom);
                    break;

                case "eat":
                    EatItem(input.argument, playerRoom);
                    break;

                case "use":
                    UseItem(input.argument, playerRoom);
                    break;

                case "inventory":
                    Console.WriteLine($"you have: {ListItems(player.InventoryItems)}");
                    break;

                default:
                    Console.WriteLine($"you don't know this thing: {input.command}\n");
                    break;
            }
        }

        private void EatItem(string _itemName, Room _playerRoom)
        {
            Item eatItem;

            if ( player.HasItem(_itemName) )
            {
                eatItem = player.GetItem(_itemName);
                if ( eatItem.IsEatable )
                {
                    player.RemoveItem(eatItem);
                }
            }
            else if ( _playerRoom.HasItem(_itemName, true) )
            {
                eatItem = _playerRoom.GetItem(_itemName, true);
                if ( eatItem.IsEatable )
                {
                    _playerRoom.RemoveItem(_itemName, true);
                }
            }
            else
            {
                Console.WriteLine($"You don't know how to eat this: {_itemName}\n");
                return;
            }

            Console.WriteLine($"{eatItem.OnEat()}\n");
        }

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

        private void UseItem(string _itemName, Room _playerRoom)
        {
            Item? item = null;

            if ( player.HasItem(_itemName) )
            {
                item = player.GetItem(_itemName);
                player.RemoveItem(item);
            }
            else if ( _playerRoom.HasItem(_itemName) )
            {
                item = _playerRoom.GetItem(_itemName);
            }

            if ( item != null )
            {
                Console.WriteLine(item.OnUse());
            }
        }

        /// <summary>
        /// makes the player go through a door and moves them to the new location
        /// </summary>
        /// <param name="_door">set's the door that the player needs to go through</param>
        private void GoThroughDoor(DoorItem _door)
        {
            (int row, int column) = _door.DoorLeadsTo;

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

            return input.ToLower(); ;
        }

        /// <summary>
        /// get's the players input for commands
        /// </summary>
        /// <param name="_prompt">set's the prompt that asks the player for what to do</param>
        /// <returns>the command and the argument. The argument is empty if none is given</returns>
        private (string command, string argument) GetCommandInput(string _prompt)
        {
            string input;

            input = GetInput(_prompt);

            input += ' ';
            string[] seperatedInput = input.Split(' ');


            return (seperatedInput[0], seperatedInput[1]);
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
                string itemName = item.ItemName;

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
            else
            {
                output = output.TrimStart(',');
            }

            return output;
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
        /// gets if the item is usable or not
        /// </summary>
        /// <param name="_itemName">set's the item name for the item to search</param>
        /// <returns>true if the item is usable, false if it is not or if no matching items were found</returns>
        private bool ItemUsable(string _itemName)
        {
            if ( player.HasItem(_itemName) )
            {
                Item useItem = player.GetItem(_itemName);
                if ( useItem.IsUsable )
                {
                    return true;
                }
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

    }
}
