using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour {

    [SerializeField] private Image _foodBar;
    [SerializeField] private float _secondsFood;

    public void Start()
    {
        _foodBar.fillAmount = 1;
    }

    public void Update()
    {
        _foodBar.fillAmount = Mathf.Clamp(_foodBar.fillAmount - (Time.deltaTime / _secondsFood), 0, 1);

    }
}
