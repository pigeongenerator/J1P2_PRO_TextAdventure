using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.GameScripts;

internal abstract class Loop : IGameScript
{
    /// <summary>
    /// starts the loop
    /// </summary>
    public void Start()
    {
        Debug.WriteLine($"started loop {GetType()}");
        OnStart();

        do
        {
            Debug.WriteLine($"{GetType()} started new loop");
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

    /// <summary>
    /// the code that is ran before the loop starts
    /// </summary>
    protected virtual void OnStart()
    {
        Debug.WriteLine($"{nameof(OnStart)} has not been overwritten in Loop {GetType()}");
    }
}
