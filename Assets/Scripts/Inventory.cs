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
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}
