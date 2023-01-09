namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class MainLoop : Loop
    {
        Workshop workshop;


        public MainLoop(Workshop _workshop)
        {
            workshop = _workshop;
        }

        /// <summary>
        /// gets called upon starting the loop
        /// </summary>
        protected override void OnStart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get's called during the loop
        /// </summary>
        protected override void DuringLoop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// checks if the loop should continue
        /// </summary>
        /// <returns>true/false</returns>
        protected override bool CheckLoop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets called upon stopping the loop
        /// </summary>
        protected override void OnStop()
        {
            throw new NotImplementedException();
        }
    }
}
