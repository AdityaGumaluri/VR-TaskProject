using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject spawnableItem;
    public Transform spawnPos;
    public bool isThrowableItem,loadAtStart;

    private GameObject currentItem;
    private Transform IntialSpawnPos;


    // Start is called before the first frame update
    void Start()
    {
        if(loadAtStart)
        {
            SpawnItems();
        }
    }

    //Spawning ItemSets 
    public void SpawnItems()
    {
         //If not throwable destroy the existing item
         if (currentItem!=null&&!isThrowableItem)
         {
            Destroy(currentItem);
         }
         //instantiating the Prefab item.
         currentItem = Instantiate(spawnableItem)as GameObject;
         if(spawnPos!=null)
         {
            currentItem.transform.position = spawnPos.position;
         }
         print("ItemSpawned");
        
    }
}
