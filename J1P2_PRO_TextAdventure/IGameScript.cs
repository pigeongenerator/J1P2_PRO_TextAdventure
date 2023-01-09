namespace J1P2_PRO_TextAdventure
{
    /// <summary>
    /// interface for game scripts, starts the script using Start().
    /// </summary>
    internal interface IGameScript
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
        protected abstract void Script();
    }
}
