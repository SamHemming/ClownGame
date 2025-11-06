using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character {diva, strongman, ringleader, lion, twins, ticketmaster}

public class TaskList : MonoBehaviour
{
	public static TaskList single;

	void Awake()
	{
		if (single == null)
			single = this;
		else Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	}

	public Dictionary<Character, int> dialogueProgress = new();

	public List<Item> collectedItems = new();

	public Dictionary<string, bool> lockedDoor = new();

	public bool fuseFixed = false;
}
