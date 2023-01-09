namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// 
    /// </summary>
    internal interface ILoop : IGameScript
    {
        void IGameScript.Script()
        {
            OnStart();

            while (LoopCondition())
            {
                Loop();
            }
        }

        /// <summary>
        /// is called once when the loop starts
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// is called during the loop
        /// </summary>
        protected abstract void Loop();

        /// <summary>
        /// is called once at the beginning of each loop 
        /// </summary>
        /// <returns>true or false depending on the loop's condition</returns>
        protected abstract bool LoopCondition();
    }
}
