namespace J1P2_PRO_TextAdventure.Environment.ItemTypes;

internal class FoodItem : Item
{
    private readonly float weightModifier;

    public float WeightModifier
    {
        get { return weightModifier; }
    }


    public FoodItem(string _name, float _weightModifier) : base(_name)
    {
        weightModifier = _weightModifier;
    }
}
