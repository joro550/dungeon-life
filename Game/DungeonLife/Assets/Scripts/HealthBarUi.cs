using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : MonoBehaviour
{
    [SerializeField] private Image image;
    public void SetValue(float value)
    {
        image.fillAmount = value;
    }
}