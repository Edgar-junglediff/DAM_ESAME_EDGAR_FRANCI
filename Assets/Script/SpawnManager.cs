using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public ClickerManager clickerManager;
    

    public HandManager handPrefab;
    public List<Transform> transforms = new List<Transform>();

    public int winCost = 400;
    public int spawnCost = 10;
    public Button buyButton;
    public Button winButton;
    int handIndex = 0;

    public TextMeshProUGUI textUpgrade;
    public TextMeshProUGUI textWin;
    public TextMeshProUGUI perSecond;

    public float handAmount = 0f;
    public float gestione = 0f;
    public float handValue = 0.4f;


    private void Start()
    {
        textUpgrade.text = "Upgrade:" + spawnCost.ToString();
        textWin.text = "";
        perSecond.text = "PerSecond:" + gestione.ToString();
    }

    void Update()
    {
        if (buyButton != null)
        {
            buyButton.interactable = (clickerManager.playerGold >= spawnCost);
        }

        if (winButton != null)
        {
            winButton.interactable = (clickerManager.playerGold >= winCost);
        }

        perSecond.text = "PerSecond:" + gestione.ToString();
    }


    public void ButtonUpgrade()
    {
        if (clickerManager.playerGold >= spawnCost)
        {
            clickerManager.RemoveGold(spawnCost);
            spawnCost = Mathf.RoundToInt((float)spawnCost * 1.15f);
            textUpgrade.text = "Upgrade:" + spawnCost.ToString();
            Instantiate(handPrefab, transforms[handIndex].position, Quaternion.identity, transforms[handIndex]);
            handIndex++;
            FarmAutomatica();
            if (handIndex >= transforms.Count)
            {
                buyButton.gameObject.SetActive(false);

            }
        }

    }
    public void ButtonWin()
    {
        textWin.text = "HAI VINTO!!";
    }

    public void FarmAutomatica()
    {
        handAmount++;
        gestione = handAmount * handValue;
    }



}
