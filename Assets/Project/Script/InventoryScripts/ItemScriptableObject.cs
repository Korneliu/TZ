using UnityEngine;

public enum ItemType {Default, Food, Weapon, Instrument }

[System.Serializable]
public class ItemScriptableObject : ScriptableObject
{
    public ItemType _itemType;
    public string _itemNane;
    public int _maximumAmount;
    public string _itemDescription;
    public GameObject _itemPrefab;
    public Sprite _icon;
    public int _amount;
}
