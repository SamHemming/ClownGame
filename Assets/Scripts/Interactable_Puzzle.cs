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
			Movement.single.canMove = true;
		}
	}

	protected override void Interact()
	{
		OnPuzzleStart?.Invoke();
		Movement.single.canMove = false;
	}
}
