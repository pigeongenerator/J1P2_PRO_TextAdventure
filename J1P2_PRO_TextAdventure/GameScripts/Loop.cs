namespace J1P2_PRO_TextAdventure.GameScripts;

internal abstract class Loop : IGameScript
{
    /// <summary>
    /// starts the loop
    /// </summary>
    public virtual void Start()
    {
        do
        {
            DoLoop();
        }
        while (CheckLoop() == true);
    }

    /// <summary>
    /// checks a condition whether the loop should remain running or not
    /// </summary>
    /// <returns>true/false based on the condition</returns>
    protected abstract bool CheckLoop();

    /// <summary>
    /// contains all the code that should be looped
    /// </summary>
    protected abstract void DoLoop();
}
