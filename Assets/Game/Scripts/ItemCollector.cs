using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    //Singeleton Creation
    public static ItemCollector Instance { get; private set; }

    #region PublicMembers

    //Stroring the all spawned Items in a list
    [Header("ItemsList")]
    public List<GameObject> items;
    [Space]
    public UnityAction onItemsCleared;

    #endregion

    #region BuiltInMethods

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    #endregion

    #region CustomMethods

    //Adding items in the list
    public void AddItems(GameObject _item)
    {
        items.Add(_item);
    }

    //Clearing items in the list
    public void ClearAllItems()
    {
        for (int i = 0; i < items.Count; i++)
        { 
            Destroy(items[i]);
        }
        items.Clear();
        onItemsCleared?.Invoke();
       
    }

    #endregion
}
