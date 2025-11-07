using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueProgress : MonoBehaviour
{
	public Character me;
	private int progress = 0;
	private Interactable_Dialogue interactable;

	public Dialogue dialogue1;
	public Dialogue dialogue2;

	public bool condition = false;
	public Item wantedItem = new();

	public Dialogue dialogue3;
	public Dialogue dialogue4;

	public UnityEvent onDialogue1;
	public UnityEvent onDialogue2;
	public UnityEvent onDialogue3;
	public UnityEvent onDialogue4;

	private void Start()
	{
		interactable = GetComponent<Interactable_Dialogue>();

		if (TaskList.single.dialogueProgress.ContainsKey(me))
		{
			progress = TaskList.single.dialogueProgress[me];
		}
		else
		{
			TaskList.single.dialogueProgress.Add(me, progress);
		}
	}

	public void CheckProgress()
	{
		switch (progress)
		{
			case 0:
				//play dialogue 1 and progress to next.
				interactable.dialogue = dialogue1;
				progress++;
				onDialogue1?.Invoke();
				if (!TaskList.single.BoolTasks.ContainsKey(this.name))
				{
					TaskList.single.BoolTasks.Add(this.name, condition);
					Debug.Log(this.name);
				}
				break;
			case 1:
				//if reguest is filled progress to next and play next, else play this.
				if (wantedItem.name != "")
				{
					condition = Inventory.single.items.Contains(wantedItem);
				}
				else
				{
					condition = TaskList.single.BoolTasks[this.name];
				}

				if (condition)
				{
					progress++;
					goto case 2;
				}
				interactable.dialogue = dialogue2;
				onDialogue2?.Invoke();
				break;
			case 2:
				//play dialogue 3 and progress to next.
				interactable.dialogue = dialogue3;
				progress++;
				onDialogue3?.Invoke();
				break;
			case 3:
				//play dialogue 4 for all eternity.
				interactable.dialogue = dialogue4;
				onDialogue4?.Invoke();
				break;
			default:
				Debug.LogWarning($"{this.name}:default case!/nProgressed past last case???");
				break;
		}

		TaskList.single.dialogueProgress[me] = progress;
	}
}
