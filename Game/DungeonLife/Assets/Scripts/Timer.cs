using Event.Events;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerMax = .2f;
    [SerializeField] private VoidEvent OnTick;

    private float tickTimer;
    
    public void Update()
    {
        tickTimer += Time.deltaTime;
        if (!(tickTimer > timerMax)) 
            return;
        
        tickTimer -= timerMax;
        OnTick?.Raise();
    }
}