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
