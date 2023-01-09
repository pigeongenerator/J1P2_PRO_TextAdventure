namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class Loop : GameScript
    {
        protected override void Script()
        {
            OnStart();

            while (LoopCondition())
            {
                DuringLoop();
            }
        }

        /// <summary>
        /// is called once when the loop starts
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// is called once at the beginning of each loop 
        /// </summary>
        /// <returns>true or false depending on the loop's condition</returns>
        protected abstract bool LoopCondition();

        /// <summary>
        /// is called during the loop
        /// </summary>
        protected abstract void DuringLoop();
    }
}
