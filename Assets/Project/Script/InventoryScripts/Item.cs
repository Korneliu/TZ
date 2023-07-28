using UnityEngine;

public class Item : MonoBehaviour
{
     public ItemScriptableObject _item;

    private void Awake()
    {
        if (_item !=null)
            _item._amount = 1;
    }
}
