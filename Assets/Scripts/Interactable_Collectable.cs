using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
	public string name;
	public string description;
	public Sprite sprite;
}

public class Interactable_Collectable : Interactable
{
	public Item item;

	protected override void Interact()
	{
		Debug.Log($"Bug????");
		Inventory.single.Add(item);
		Destroy(this.gameObject);
	}
}
