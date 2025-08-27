using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable_Door : Interactable
{
	public string destinationName = "";

	protected override void Interact()
	{
		//Debug.Log($"Door activated");
		SceneManager.LoadScene(destinationName, LoadSceneMode.Single);
	}

}
