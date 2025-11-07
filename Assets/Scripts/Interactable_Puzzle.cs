using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_Puzzle : Interactable
{
	public static Interactable_Puzzle single;
	public List<PuzzlePiece> PieceList;

	public UnityEvent OnPuzzleStart;
	public UnityEvent OnPuzzleDone;

	private void Start()
	{
		if (single == null)
			single = this;
		else Destroy(this.gameObject);
	}

	public void IsDone()
	{
		bool done = true;

		foreach(PuzzlePiece piece in PieceList)
		{
			if(!piece.IsCorrect())
				done = false;
		}

		if(done)
		{
			OnPuzzleDone?.Invoke();
			if (TaskList.single.BoolTasks.ContainsKey("RingLeader"))
				TaskList.single.BoolTasks["RingLeader"] = true;
			else
				TaskList.single.BoolTasks.Add("RingLeader", true);
			Movement.single.canMove = true;
			TaskList.single.lightsOn = true;
		}
	}

	protected override void Interact()
	{
		OnPuzzleStart?.Invoke();
		Movement.single.canMove = false;
	}
}
