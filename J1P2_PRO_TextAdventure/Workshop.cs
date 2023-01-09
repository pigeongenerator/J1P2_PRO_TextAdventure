using J1P2_PRO_TextAdventure.Rooms;

namespace J1P2_PRO_TextAdventure
{
    internal class Workshop
    {
        Room[,] workshop;


        public Workshop()
        {
            workshop = GenerateWorkshop();
        }

        private Room[,] GenerateWorkshop()
        {
            Room[,] rooms = new Room[5, 5];

            return rooms;
        }
    }
}
