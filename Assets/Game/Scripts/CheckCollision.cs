using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum ObjectType
{
    item,
    ground,
    Throwable
}
public class CheckCollision : MonoBehaviour
{

    public ObjectType objectType;
    public bool gotHit;
    private void OnCollisionEnter(Collision collision)
    {
            switch(objectType)
            { 
            case ObjectType.ground:
                if (collision.gameObject.CompareTag("Throwable"))
                {
                    print($"Got hit{collision.gameObject.name}");
                   //collision.gameObject.GetComponent<SpawnItem>().SpawnItems();
                   Destroy(collision.gameObject,5f);
                }
                break;
            case ObjectType.item:

                if (collision.gameObject.CompareTag("Throwable"))
                {
                    print($"Got hit{collision.gameObject.name}");
                    gotHit = true;
                    ItemHitDetection.hitCount++;
                    ItemHitDetection.onHitDetected.Invoke();
                }
                if (collision.gameObject.CompareTag("Ground"))
                {
                    print($"Got hit{collision.gameObject.name}");
                    if (!gotHit)
                    {
                      ItemHitDetection.hitCount++;
                    }
                    this.enabled = false;
                }
                break;
            case ObjectType.Throwable:
                //
                break;
        }
        
    }
}
