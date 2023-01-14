using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class Loop : GameScript
    {
        /// <summary>
        /// contains the loop
        /// </summary>
        protected override void Script()
        {
            Debug.WriteLine($"Started loop {this}");
            OnStart();

            while ( LoopCondition() )
            {
                DuringLoop();
                Debug.WriteLine($"Completed loop {this}");
            }

            Debug.WriteLine($"Ended loop {this}");
            OnEnd();
        }

        /// <summary>
        /// is called once the loop starts
        /// </summary>
        protected virtual void OnStart()
        {
            Debug.WriteLine($"loop {this} hasn't overwritten {OnStart}.");
        }

        /// <summary>
        /// is called once the loop ends
        /// </summary>
        protected virtual void OnEnd()
        {
            Debug.WriteLine($"loop {this} hasn't overwritten {OnEnd}.");
        }

        /// <summary>
        /// is called once at the start of each loop to check if the loop should keep running
        /// </summary>
        /// <returns>true or false depending on the loop's condition</returns>
        protected abstract bool LoopCondition();

        /// <summary>
        /// is called during the loop
        /// </summary>
        protected abstract void DuringLoop();

    }
}
