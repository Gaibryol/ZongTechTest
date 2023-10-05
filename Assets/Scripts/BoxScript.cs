using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
	[SerializeField] private string box;
	[SerializeField] private GameManager gameManager;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Stone")
		{
			gameManager.StoneInBox(box);
		}
	}
}
