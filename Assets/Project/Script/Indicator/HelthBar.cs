using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    private float _maxValue;
    private Camera _camera;
    private Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }

    private void Update()
    {
        transform.rotation = Camera.transform.rotation;
    }

    public void Init(float maxValue) => _maxValue = maxValue;
    public void SetValue(float value) => _image.fillAmount = (1F / _maxValue) * value;
}