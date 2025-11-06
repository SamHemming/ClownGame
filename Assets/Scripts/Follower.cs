using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Follower : MonoBehaviour
{
	NavMeshAgent nav = null;
	[SerializeField]
	GameObject playerOne = null;

	public Animator animator;

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
	}

	private void FixedUpdate()
	{
		if (nav != null && playerOne != null)
			nav.destination = playerOne.transform.position;
	}

	private void Update()
	{
		animator.SetBool("IsStopped", !(nav.velocity.magnitude > 0));
	}

}
