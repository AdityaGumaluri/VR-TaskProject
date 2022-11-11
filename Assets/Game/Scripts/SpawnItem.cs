using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    #region Public Members

    public ItemInfo itemTobeSpawned;
    public Transform spawnPos;
    public bool loadAtStart;
    public GameObject currentSpawnedItem{ get; private set; }

    #endregion

    ItemCollector collector;

    #region BuiltInMethods
    // Start is called before the first frame update
    void Start()
    {
        collector = ItemCollector.Instance;
        //spawning Item on start when boolean is true
        if(loadAtStart)
        {
            InstantiateItem();
        }
    }
    #endregion


    #region CustomMethods

    //spawns Item in the scene
    public void InstantiateItem()
    {
        if (itemTobeSpawned != null)
        {
            collector.onItemsCleared -= InstantiateItem;

            //if item is not a throwable destroying the existing item when another getting created.
            if (currentSpawnedItem != null&!itemTobeSpawned.isThrowable)
            {
                Destroy(currentSpawnedItem);
            }

            //If spawnPos is null making the item default pos as spawnPos
            if (spawnPos == null)
            {
                spawnPos = itemTobeSpawned.itemPrefab.transform;
            }

            currentSpawnedItem = Instantiate(itemTobeSpawned.itemPrefab);
            currentSpawnedItem.transform.position = spawnPos.position;

            //Adding spawned item in the list
            collector.AddItems(currentSpawnedItem);
            if(loadAtStart)
            {
                collector.onItemsCleared += InstantiateItem;
            }
        }
    }
    #endregion
}
