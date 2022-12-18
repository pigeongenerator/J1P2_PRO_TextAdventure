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
        while (Check() == true);
    }

    /// <summary>
    /// checks a condition whether the loop should remain running or not
    /// </summary>
    /// <returns>true/false based on the condition</returns>
    protected abstract bool Check();

    /// <summary>
    /// contains all the code that should be looped
    /// </summary>
    protected abstract void DoLoop();
}
