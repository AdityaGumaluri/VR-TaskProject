using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TweenScale : MonoBehaviour
{
    public GameObject[] objectsTobeScaled;
    public GameObject objectToBeScaled;
    public float finalScaleValue;
    [Space]
    public UnityEvent onFinalScaleReached;

    // Start is called before the first frame update
    void Start()
    {
        if(objectsTobeScaled.Length>0)
        {
            foreach (var item in objectsTobeScaled)
            {
                item.LeanScale(new Vector3(finalScaleValue, finalScaleValue, finalScaleValue), 0.75f).
                setDelay(0.25f).setEase(LeanTweenType.easeInElastic);
            }
            onFinalScaleReached.Invoke();
        }
        else if(objectToBeScaled!=null)
        {
            objectToBeScaled.LeanScale(new Vector3(finalScaleValue, finalScaleValue, finalScaleValue), 0.75f).
            setDelay(0.25f).setEase(LeanTweenType.easeInElastic).
            setOnComplete(() => onFinalScaleReached.Invoke());
        }
        
    }
}
