using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal abstract class Loop : IGameScript
    {
        /// <summary>
        /// starts the loop
        /// </summary>
        public void Start()
        {
            Debug.WriteLine($"started loop {this}.");
            OnStart();

            do
            {
                DuringLoop();
                Debug.WriteLine($"reached end of loop {this}.");
            }
            while ( CheckLoop() );

            OnStop();
            Debug.WriteLine($"quit loop {this}");
        }

        /// <summary>
        /// gets called once upon start
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// runs during the loop
        /// </summary>
        protected abstract void DuringLoop();

        /// <summary>
        /// checks a condition during the loop
        /// </summary>
        /// <returns>true/false based on a condition</returns>
        protected abstract bool CheckLoop();

        /// <summary>
        /// get's called once when the loop ends
        /// </summary>
        protected abstract void OnStop();
    }
}
