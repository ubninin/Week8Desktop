[System.Serializable]
public class InventoryItem
{
    public InventoryItemType itemType;

    public InventoryItem(InventoryItemType type)
    {
        itemType = type;
    }
}
