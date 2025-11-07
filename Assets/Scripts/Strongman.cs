using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strongman : MonoBehaviour
{
	public GameObject canvas;
	public GameObject image1;
	public GameObject image2;
	public Button button;
	public bool Trigger {  get; set; }
	private bool clicked = false;

	public void Viiksi()
	{
		if (Trigger)
		{
			Trigger = false;
			StartCoroutine(WaitForInput());
		}
	}

	public IEnumerator WaitForInput()
	{
		canvas.SetActive(true);
		image1.SetActive(true);
		
		button.onClick.AddListener(() => this.clicked = true);

		while (!clicked)
		{
			yield return null;
		}

		clicked = false;

		image1.SetActive(false);
		image2.SetActive(true);

		while (!clicked)
		{
			yield return null;
		}

		clicked = false;
		image2.SetActive(false);
		canvas.SetActive(false);
	}
}
