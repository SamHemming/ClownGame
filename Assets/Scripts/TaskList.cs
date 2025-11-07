using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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

	public Dictionary<string, bool> BoolTasks = new();

	public bool TentOpen {  get; set; }
	public bool lightsOn = false;
	public bool tentOpen = false;
	public Sprite tentOpenTexture;
	public Sprite ringLight;
	public Sprite clutterLight;

	private void OnLevelWasLoaded(int level)
	{
		Sprite img = null;
		if (level == 1 && tentOpen) //entrance
			img = tentOpenTexture;
		if (level == 2 && lightsOn) //ring
			img = ringLight;
		if (level == 3 && lightsOn) //clutter
			img = clutterLight;

		if(img != null)
			FindFirstObjectByType<Canvas>().GetComponentInChildren<Image>().sprite = img;
		
	}
}
