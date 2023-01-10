namespace J1P2_PRO_TextAdventure
{
    /// <summary>
    /// interface for game scripts, starts the script using Start().
    /// </summary>
    internal abstract class GameScript //defines an abstract class which cannot be used to create objects directly
    {
        /// <summary>
        /// starts the game script
        /// </summary>
        public void Start()
        {
            Script();
        }

        /// <summary>
        /// is called upon running the script
        /// </summary>
        protected abstract void Script(); //defines an abstract method who's body is provided by an inherited class
    }
}
