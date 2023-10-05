using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	[SerializeField] private ParticleSystem particlesA;
	[SerializeField] private ParticleSystem particlesB;

	[SerializeField] private UIManager uiManager;

	[SerializeField] private InputActionReference inputs;

	[SerializeField] private GameObject player;
	[SerializeField] private Vector3 startPos;

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip zipUp;
	[SerializeField] private AudioClip zipDown;

	[SerializeField] private GameObject stone;

	private bool holdingStone;
	private bool inventoryOpen;
	private bool firstTimePickup;

    // Start is called before the first frame update
    private void Start()
    {
		inventoryOpen = false;
		holdingStone = false;
		firstTimePickup = true;
    }

	public void StoneInBox(string box)
	{
		if (holdingStone) return;

		// Check which box stone is dropped in
		switch (box)
		{
			case "A":
				particlesA.Play();
				break;

			case "B":
				particlesB.Play();
				break;

			case "C":
				player.transform.position = startPos;
				uiManager.Open();
				inventoryOpen = true;
				break;
		}
	}

	public void PickUpStone()
	{
		if (firstTimePickup)
		{
			inventoryOpen = true;
			audioSource.PlayOneShot(zipDown);
		}

		holdingStone = true;
		firstTimePickup = false;

		stone.transform.parent = player.transform;
	}

	public void DropStone()
	{
		holdingStone = false;

		stone.transform.parent = null;
	}

	private void ToggleInventory(InputAction.CallbackContext context)
	{
		inventoryOpen = !inventoryOpen;
		if (inventoryOpen)
		{
			uiManager.Open();
			audioSource.PlayOneShot(zipDown);
		}
		else
		{
			uiManager.Close();
			audioSource.PlayOneShot(zipUp);
		}
	}

	private void OnEnable()
	{
		inputs.action.performed += ToggleInventory;
	}

	private void OnDisable()
	{
		inputs.action.performed -= ToggleInventory;
	}
}
