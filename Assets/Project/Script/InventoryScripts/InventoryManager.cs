using UnityEngine;
using UnityEngine.Assertions;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private Transform _inventoryPanel;
    private InventorySlot[] _slots;
    private Camera _mainCamera;
    [SerializeField] private float _reachDistance;

    private void Start()
    {
        _mainCamera = Camera.main;
        _slots = _inventoryPanel.gameObject.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    var item = hit.collider.gameObject.GetComponent<Item>()._item;
                    if (AddItem(item))
                        Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (InventorySlot slot in _slots)
            {
                if (!slot.IsEmpty)
                {
                    slot.Throw();
                    break;
                }
            }
        }
    }

    private bool AddItem(ItemScriptableObject _item)
    {
        foreach (InventorySlot slot in _slots)
            if (slot.SetItem(_item)) return true;
        return false;
    }
}
