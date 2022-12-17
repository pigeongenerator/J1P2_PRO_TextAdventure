﻿using J1P2_PRO_TextAdventure.GameScripts;


namespace J1P2_PRO_TextAdventure; //file-scoped namespace

internal class Program //defines a class
{
    /// <summary>
    /// starts the program
    /// </summary>
    /// <param name="_args">the paths of the files the program is opened with</param>
    static void Main() //defines a static method which means that the method is accessible from anywhere the class is
    {
        _ = new Environment.LivingEntities.PlayerEntity(0,0);
        Console.ReadKey();
        Game game = new(); //defines a new game object
        game.Start(); //calls the start method
    }
}
