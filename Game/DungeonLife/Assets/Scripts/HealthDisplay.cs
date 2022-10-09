using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private Health health; 
    
    public void Update()
    {
        text.text = health.GetValue();
    }
}