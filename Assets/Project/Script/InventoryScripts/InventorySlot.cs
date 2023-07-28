using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _iconGO;
    [SerializeField] private TMP_Text _itemAmount;
    private ItemScriptableObject _item;
    private int _count = 0;
    private Sprite _prevSprite;
    private Color _prevColor;
    public bool IsEmpty => _item == null;

    private void Awake()
    {
        _prevSprite = _iconGO.sprite;
        _prevColor = _iconGO.color;
    }

    public bool SetItem(ItemScriptableObject item)
    {
        if (!IsEmpty) return false;
        _item = item;
        _iconGO.color = Color.white;
        _iconGO.sprite = item._icon;
        _count += item._amount;
        _itemAmount.text = _count.ToString();
        print(_count);
        return true;
    }
    public void Throw()
    {
        var clone = Instantiate(_item._itemPrefab).GetComponent<Item>();
        var scriptObj = ScriptableObject.CreateInstance<ItemScriptableObject>();
        scriptObj._itemType = _item._itemType;
        scriptObj._itemNane = _item._itemNane;
        scriptObj._maximumAmount = _item._maximumAmount;
        scriptObj._itemDescription = _item._itemDescription;
        scriptObj._itemPrefab = _item._itemPrefab;
        scriptObj._icon = _item._icon;
        scriptObj._amount = _item._amount;
        clone._item = scriptObj;
        var player = GameObject.FindGameObjectWithTag("Player").transform;
        clone.transform.position = player.position + player.forward + Vector3.up * 3;
        _iconGO.sprite = null;
        _itemAmount.text = string.Empty;
        _iconGO.sprite = _prevSprite;
        _iconGO.color = _prevColor;
        _item = null;
        _count = 0;
    }
}