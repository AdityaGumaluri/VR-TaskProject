using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    #region Public Members

    [Header("UI")]
    public TextMeshProUGUI popUpText;
    public CanvasGroup PopupPanel;
    public int TotalItemsGotHit;

    public static int hitCount;
    public static UnityAction onHitAction;

    #endregion

    #region BuiltInMethods
    // Start is called before the first frame update
    void Start()
    {
        onHitAction += CheckForHitCount;
    }
    #endregion

    #region CustomMethods

    //Checking for HitCount
    public void CheckForHitCount()
    {
        TotalItemsGotHit = hitCount;
        print(hitCount);
        if(hitCount>8)
        {
          TweenPopUpPanelWithText("Nice Hit!");
        }
        if (hitCount >15)
        {
            TweenPopUpPanelWithText("Nice Hit!");
        }
    }

    //Tweening popup Panel
    public void TweenPopUpPanelWithText(string _text)
    {
        PopupPanel.transform.LeanMoveLocalY(-0.5f, 0f);
        popUpText.text =_text;
        PopupPanel.LeanAlpha(1, 0.5f);
        PopupPanel.transform.LeanMoveLocalY(0.5f,1f).setEase(LeanTweenType.linear);
        PopupPanel.LeanAlpha(0,0.5f).setDelay(0.6f);
        print("popupPanelTweened");

    }

    #endregion
}
