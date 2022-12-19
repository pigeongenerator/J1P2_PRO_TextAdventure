namespace J1P2_PRO_TextAdventure.Environment.ItemTypes;

internal class Item
{
    private readonly string itemName;
    
    public string ItemName
    {
        get { return itemName; }
    }


    public Item(string _itemName)
    {
        itemName = _itemName;
    }
}
