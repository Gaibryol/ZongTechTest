using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
	[SerializeField] private GameObject stoneLabel;

	[SerializeField] private Toggle weaponsToggle;
	[SerializeField] private Toggle pointsToggle;
	[SerializeField] private Toggle instrumentsToggle;

	[SerializeField] private GameObject weaponsSubCategories;
	[SerializeField] private Toggle wolfStoneToggle;
	[SerializeField] private Toggle lizardCrystalToggle;
	[SerializeField] private Toggle crushSkullSteelToggle;

	[SerializeField] private TMP_Text panelLabel;

	[SerializeField] private GameObject inventoryPanel;

	[SerializeField] private GameObject leftRayInteractor;
	[SerializeField] private GameObject rightRayInteractor;

	[SerializeField] private GameObject grid;
	[SerializeField] private GameObject wolfStone;
	[SerializeField] private GameObject lizardCrystal;
	[SerializeField] private GameObject crushSkullSteel;
	[SerializeField] private GameObject stoneItem;

	private bool holdingStone;
	private bool firstTimePickup;

	private void Start()
	{
		Close();

		WolfStone();
		holdingStone = false;
		firstTimePickup = true;
	}

	private void ClearGrid()
	{
		foreach(Transform child in grid.transform)
		{
			Destroy(child.gameObject);
		}
	}

	private void WolfStone()
	{
		panelLabel.text = "Weapons / Wolf Stone";

		ClearGrid();
		Instantiate(wolfStone, grid.transform);
		Instantiate(wolfStone, grid.transform);
	}

	private void LizardCrystal()
	{
		panelLabel.text = "Weapons / Lizard Crystal";

		ClearGrid();
		Instantiate(lizardCrystal, grid.transform);
	}

	private void CrushSkullSteel()
	{
		panelLabel.text = "Weapons / Crush Skull Steel";

		ClearGrid();
		Instantiate(crushSkullSteel, grid.transform);
		Instantiate(crushSkullSteel, grid.transform);
		Instantiate(crushSkullSteel, grid.transform);
	}

	private void Stone()
	{
		ClearGrid();

		if (holdingStone)
		{
			Instantiate(stoneItem, grid.transform);
		}
	}

	public void PickUpStone()
	{
		// Only activate UI for the first time you pick up the stone
		if (firstTimePickup)
		{
			stoneLabel.SetActive(false);
			inventoryPanel.SetActive(true);

			leftRayInteractor.SetActive(true);
			rightRayInteractor.SetActive(true);
		}

		holdingStone = true;
		firstTimePickup = false;

		if (instrumentsToggle.isOn)
		{
			Stone();
		}
	}

	public void DropStone()
	{
		holdingStone = false;

		if (instrumentsToggle.isOn)
		{
			ClearGrid();
		}
	}

	private void OnWeaponsToggle(bool active)
	{
		// Toggle weapon sub categories
		weaponsSubCategories.SetActive(active);
		if (wolfStoneToggle.isOn)
		{
			WolfStone();
		}
		else if (lizardCrystalToggle.isOn)
		{
			LizardCrystal();
		}
		else if (crushSkullSteelToggle.isOn)
		{
			CrushSkullSteel();
		}
	}

	private void OnPointsToggle(bool active)
	{
		if (active)
		{
			panelLabel.text = "Points";
			ClearGrid();
		}
	}

	private void OnInstrumentsToggle(bool active)
	{
		if (active)
		{
			panelLabel.text = "Instruments";
			Stone();
		}
	}

	private void OnWolfStoneToggle(bool active)
	{
		if (active)
		{
			WolfStone();
		}
	}

	private void OnLizardCrystalToggle(bool active)
	{
		if (active)
		{
			LizardCrystal();
		}
	}

	private void OnCrushSkullSteelToggle(bool active)
	{
		if (active)
		{
			CrushSkullSteel();
		}
	}

	public void Close()
	{
		inventoryPanel.SetActive(false);

		leftRayInteractor.SetActive(false);
		rightRayInteractor.SetActive(false);
	}

	public void Open()
	{
		inventoryPanel.SetActive(true);

		leftRayInteractor.SetActive(true);
		rightRayInteractor.SetActive(true);

		if (weaponsToggle.isOn && wolfStoneToggle.isOn)
		{
			WolfStone();
		}
		else if (weaponsToggle.isOn && lizardCrystalToggle.isOn)
		{
			LizardCrystal();
		}
		else if (weaponsToggle.isOn && crushSkullSteelToggle.isOn)
		{
			CrushSkullSteel();
		}
		else if (instrumentsToggle.isOn)
		{
			Stone();
		}
	}

	private void OnEnable()
	{
		weaponsToggle.onValueChanged.AddListener(OnWeaponsToggle);
		pointsToggle.onValueChanged.AddListener(OnPointsToggle);
		instrumentsToggle.onValueChanged.AddListener(OnInstrumentsToggle);
		wolfStoneToggle.onValueChanged.AddListener(OnWolfStoneToggle);
		lizardCrystalToggle.onValueChanged.AddListener(OnLizardCrystalToggle);
		crushSkullSteelToggle.onValueChanged.AddListener(OnCrushSkullSteelToggle);
	}

	private void OnDisable()
	{
		weaponsToggle.onValueChanged.RemoveListener(OnWeaponsToggle);
		pointsToggle.onValueChanged.RemoveListener(OnPointsToggle);
		instrumentsToggle.onValueChanged.RemoveListener(OnInstrumentsToggle);
		wolfStoneToggle.onValueChanged.RemoveListener(OnWolfStoneToggle);
		lizardCrystalToggle.onValueChanged.RemoveListener(OnLizardCrystalToggle);
		crushSkullSteelToggle.onValueChanged.RemoveListener(OnCrushSkullSteelToggle);
	}
}
