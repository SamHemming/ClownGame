using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable_Door : Interactable
{
	public string destinationName = "";
	public bool isLocked = false;

	private void Start()
	{
		if (TaskList.single.lockedDoor.ContainsKey(this.name))
		{
			isLocked = TaskList.single.lockedDoor[this.name];
			Debug.Log("door found in dictionary");
		}
		else
		{
			TaskList.single.lockedDoor.Add(this.name, isLocked);
			Debug.Log("door Not found in dictionary");
		}
	}

	public void Open()
	{
		isLocked = false;
		TaskList.single.lockedDoor[this.name] = false;
	}

	protected override void Interact()
	{
		if (!isLocked) SceneManager.LoadScene(destinationName, LoadSceneMode.Single);
	}

}
