using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Rotation {angle0, angle90, angle180, angle270}

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
	public Rotation solvedState1 = Rotation.angle0;
	public Rotation solvedState2 = Rotation.angle0;

	public Rotation currentState = Rotation.angle0;
	public float rotationTime = 1.0f;

	public void OnPointerClick(PointerEventData eventData)
	{
		currentState = (currentState == Rotation.angle270) ? Rotation.angle0 : ++currentState;

		Rotate(currentState);
	}

	public bool IsCorrect()
	{
		return currentState == solvedState1 | currentState == solvedState2;
	}

	private void Start()
	{
		currentState = (Rotation)Random.Range(0, 4);
		switch (currentState)
		{
			case Rotation.angle0:
				transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				break;
			case Rotation.angle90:
				transform.rotation = Quaternion.Euler(0f, 0f, 90f);
				break;
			case Rotation.angle180:
				transform.rotation = Quaternion.Euler(0f, 0f, 180f);
				break;
			case Rotation.angle270:
				transform.rotation = Quaternion.Euler(0f, 0f, 270f);
				break;
			default:
				Debug.LogWarning($"{this.name}:default case!");
				break;
		}
	}

	private void Rotate(Rotation angle)
	{
		switch(angle)
		{
			case Rotation.angle0:
				StartCoroutine(ToAngle(0));
				break;
			case Rotation.angle90:
				StartCoroutine(ToAngle(90));
				break;
			case Rotation.angle180:
				StartCoroutine(ToAngle(180));
				break;
			case Rotation.angle270:
				StartCoroutine(ToAngle(270));
				break;
			default:
				Debug.LogWarning($"{this.name}:default case!");
				break;
		}
	}

	private IEnumerator ToAngle(int angle)
	{
		float startAngle = transform.eulerAngles.z;
		float targetAngle = angle;
		float progress = 0.0f;

		while(true)
		{
			progress += (1/rotationTime) * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(startAngle, targetAngle, progress));

			if (progress >= 1.0f)
			{
				break;
			}

			yield return null;
		}

		Interactable_Puzzle.single.IsDone();
	}

}
