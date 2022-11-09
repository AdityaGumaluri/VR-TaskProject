using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemHitDetection : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI popUpText;
    public CanvasGroup PopupPanel;
    [SerializeField] int TotalItemsGotHit;

    public static int hitCount;
    public static UnityAction onHitDetected;

    // Start is called before the first frame update
    void Start()
    {
        onHitDetected += CheckForHitCount;
    }
    public void CheckForHitCount()
    {
        TotalItemsGotHit = hitCount;
        print(hitCount);
        if(hitCount>8)
        {
          TweenPopUpPanelWithText("Nice Hit!");
        }
    }
    public void TweenPopUpPanelWithText(string _text)
    {
        PopupPanel.transform.LeanMoveLocalY(-0.5f, 0f);
        popUpText.text =_text;
        PopupPanel.LeanAlpha(1, 0.5f);
        PopupPanel.transform.LeanMoveLocalY(0.5f,1f).setEase(LeanTweenType.linear);
        PopupPanel.LeanAlpha(0,0.5f).setDelay(0.6f);
        print("popupPanelTweened");

    }
}
