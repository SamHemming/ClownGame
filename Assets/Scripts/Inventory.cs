using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory single;

    public List<Item> items = new();

    void Start()
    {
        if (single == null)
            single = this;
        else Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void Combine()
    {
        if(items.Contains(new Item("liima")) && items.Contains(new Item("purkka")) && items.Contains(new Item("purkki")) && items.Contains(new Item("hattara")))
        {
            items.Add(new Item("vaha"));
            items.Remove(new Item("liima"));
            items.Remove(new Item("purkka"));
            items.Remove(new Item("purkki"));
            items.Remove(new Item("hattara"));
        }
    }

}
