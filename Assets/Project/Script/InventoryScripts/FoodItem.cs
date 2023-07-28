using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Food Item", menuName ="Inventory/New Food Item")]

public class FoodItem : ItemScriptableObject
{
    [SerializeField] private float _healtAmount;

    private void Start()
    {
        _itemType = ItemType.Food;
    }
}
