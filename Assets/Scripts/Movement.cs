using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    NavMeshAgent nav = null;
    Vector3 targetPos = Vector3.zero;
	public static Movement single;

    void Start()
	{
		if (single == null)
			single = this;
		else Destroy(this);

		nav = GetComponent<NavMeshAgent>();
    }

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
			{
				targetPos = hit.point;

				nav.destination = targetPos;
				//TODO: move towards interactables origin???

				if (!hit.transform.gameObject.TryGetComponent<Interactable>(out _))
					Interactable.interactionCall.Invoke(null);
			}

		}
	}
}
