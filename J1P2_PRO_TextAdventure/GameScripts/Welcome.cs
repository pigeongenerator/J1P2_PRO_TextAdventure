namespace J1P2_PRO_TextAdventure.GameScripts;

internal class Welcome : IGameScript
{
    private readonly Game game;


    public Welcome(Game _game)
    {
        game = _game;
    }

    public void Start()
    {
        Dialogue dialogue = new(
            game,
            "You woke up today.",
            "Happily you ran downstairs; today it is Christmas",
            "But there were no presents",
            "this could only mean one thing: Santa become evil",
            "naturally you booked a flight to the North pole and broke into his workshop",
            "But he must have been prepared because the door of his office is locked!",
            "that old man really didn't want you to get in because he installed X locks on the door",
            "Now you need to look around for the keys hidden somewhere in his workshop!");

        dialogue.Start();
    }
}
