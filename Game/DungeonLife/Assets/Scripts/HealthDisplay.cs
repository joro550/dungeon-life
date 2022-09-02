using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private EnemyHealth health; 
    
    public void Update()
    {
        text.text = health.GetValue();
    }
}