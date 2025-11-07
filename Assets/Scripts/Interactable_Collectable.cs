using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Item
{
	public string name;
	public string description;
	public Sprite sprite;

	public Item(string name) { this.name = name; description = ""; sprite = null; }
	public static bool operator ==(Item item1, Item item2)
		{
			if (item1.name == item2.name) return true;
			return false;
		}
	public static bool operator !=(Item item1, Item item2) { return !(item1 == item2); }
}

public class Interactable_Collectable : Interactable
{
	public Item item;

	public UnityEvent onCollect;

	protected override void Interact()
	{
		//Debug.Log($"Bug????");
		Inventory.single.Add(item);
		onCollect?.Invoke();
		TaskList.single.collectedItems.Add(item);
		Destroy(this.gameObject);
	}

	private void Start()
	{
		if(TaskList.single.collectedItems.Contains(item))
		{
			Destroy(this.gameObject);
		}
	}
}
