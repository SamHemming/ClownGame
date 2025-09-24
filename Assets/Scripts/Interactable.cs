using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class InteractableEvent : UnityEvent<Interactable>
{

}

public abstract class Interactable : MonoBehaviour, IPointerClickHandler
{
	private bool isActive = false;

	public static InteractableEvent interactionCall = new();

	[SerializeField, Range(0, 10)]
	private float interactionDistance = 1f;

	private void Start()
	{
		interactionCall.AddListener(ResetActive);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if(!Movement.single.canMove) return;

		isActive = true;
		interactionCall?.Invoke(this);
		return;
	}

	private void Update()
	{
		if(isActive)
		{
			if (Vector3.Distance(this.gameObject.transform.position, Movement.single.transform.position) < interactionDistance)
			{
				//Debug.Log($"INTERACTION COMMENCE!!!");
				isActive = false;
				Interact();
			}
		}
		return;
	}

	private void ResetActive(Interactable interactable)
	{
		if(isActive && interactable != this)
			isActive = false;
	}

	protected abstract void Interact();
}
