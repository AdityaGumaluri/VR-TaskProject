using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CurrentObject
{
    throwable,cup,ground
}
public class CollisionChecker : MonoBehaviour
{
    #region publicMembers
    //Type of object
    public CurrentObject currentObject;
    public bool gotHit;
    #endregion

    #region BuiltInmethods

    //Checking for collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        switch (currentObject)
        {
            //If throwable hits any collider 
            case CurrentObject.throwable:
                if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Cup"))
                {
                    print($"Collided with{ collision.gameObject.name}");
                    SpawnItem spawnItem = this.gameObject.GetComponent<SpawnItem>();
                    if(!gotHit)
                    {
                        spawnItem.InstantiateItem();
                        gotHit = true;
                    }
                }
                break;

            //If cup hits any collider 
            case CurrentObject.cup:

                if (collision.gameObject.CompareTag("Throwable"))
                {
                    if(!gotHit)
                    {
                        print($"Collided with{collision.gameObject.name}");
                        ScoreCounter.hitCount++;
                        ScoreCounter.onHitAction?.Invoke();
                        gotHit = true;
                    }
                }
                if (collision.gameObject.CompareTag("Ground"))
                {
                    if(!gotHit)
                    {
                        print($"Collided with{collision.gameObject.name}");
                        ScoreCounter.hitCount++;
                        gotHit = true;
                    }
                }
                break;
        }
    }
    #endregion
}
