using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    NavMeshAgent nav = null;
	public static Movement single;
	public bool canMove = true;
	public Animator animator;

    void Start()
	{
		if (single == null)
			single = this;
		else Destroy(this.gameObject);

		nav = GetComponent<NavMeshAgent>();
    }

	private void Update()
	{
		animator.SetBool("IsStopped", !(nav.velocity.magnitude > 0));

		if(canMove && Input.GetMouseButtonDown(0))
		{

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
			{

				if (hit.transform.gameObject.TryGetComponent<Interactable>(out _))
				{
					Interactable.interactionCall.Invoke(null);
					nav.destination = hit.transform.position;
				}
				else
				{
					nav.destination = hit.point;
				}
			}

		}
	}
}
