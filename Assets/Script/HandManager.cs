using UnityEngine;

public class HandManager : MonoBehaviour
{
    ClickerManager clickerManager;
    public float autoGoldTime = 1.0f;
    public float autoGold = 0.4f;


    public float timer = 0;

    private void Awake()
    {
        clickerManager = FindFirstObjectByType<ClickerManager>();
    }
    void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= autoGoldTime)
        {
            clickerManager.playerGold = Mathf.RoundToInt((float)clickerManager.playerGold + autoGold);
            timer = 0;
            clickerManager.UiAggiornata();
            
        }
    }

 
}





