using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    [SerializeField] private Transform _shotDir;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            var clone = Instantiate(_ammo, _shotDir.position, _shotDir.rotation);
        }
    }

}
