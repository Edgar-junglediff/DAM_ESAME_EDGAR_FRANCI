using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickerManager : MonoBehaviour
{
    SpawnManager spawnManager;
    public int goldClick = 1;
    
    public int playerGold;
    public LayerMask cookieLayerMask;
    public TextMeshProUGUI textMeshProUGUI;
    

    private void Start()
    {
        playerGold = 0;
        textMeshProUGUI.text = "Biscotti" + playerGold.ToString();
        
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 100, cookieLayerMask);
            if (hit.collider != null)
            {
                GiveGold();
                


            }
        }
    }

    public void GiveGold()
    {
        playerGold++;
        UiAggiornata();
    }

    public void RemoveGold(int amount)
    {
        playerGold-=amount;
        UiAggiornata();
    }

    public void UiAggiornata()
    {
        textMeshProUGUI.text = "Biscotti:" + playerGold.ToString();
    }


}
