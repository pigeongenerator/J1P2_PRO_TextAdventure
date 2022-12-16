﻿using J1P2_PRO_TextAdventure.Environment.Rooms;

namespace J1P2_PRO_TextAdventure.Environment
{
    internal class Workshop
    {
        private readonly Room[,] workshop;
        private Dictionary<Guid, LivingEntity> entities;

        public Workshop()
        {
            entities = new Dictionary<Guid, LivingEntity>();

            workshop = GenRooms(3,5);
        }

        public char[,] GetRender()
        {
            int xLength = workshop.GetLength(0);
            int yLength = workshop.GetLength(1);

            char[,] render = new char[xLength, yLength];

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    render[x,y] = workshop[x, y].GetDisplay();
                }
            }

            return render;
        }

        /// <summary>
        /// generates the rooms
        /// </summary>
        /// <param name="_width">sets the width of the generated rooms</param>
        /// <param name="_length">sets the length of the generated rooms</param>
        /// <returns></returns>
        private Room[,] GenRooms(int _width, int _length)
        {
            Room[,] rooms = new Room[1, 3]
            {
                {
                    new Office(1),
                    new Hallway(),
                    new Start()
                }
            };

            return rooms;
        }
    }
}
