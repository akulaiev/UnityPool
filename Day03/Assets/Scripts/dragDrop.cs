using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler,
IDragHandler {

	public gameManager		gameManager;
	public GameObject		prefabAmo;
	public Text				waitTime;
	public Text				range;
	public Text				damage;
	public Text				energy;
	private RectTransform	rectTransform;
	private Vector3			startPosition;
	private towerScript		prefabScript;
	private CanvasGroup		canvasGroup;
    RaycastHit2D			hit;
	bool					isAvailable = false;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		prefabScript = prefabAmo.GetComponent<towerScript>();
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = 1;
		range.text = prefabScript.range.ToString();
		damage.text = prefabScript.damage.ToString();
		waitTime.text = prefabScript.fireRate.ToString();
		energy.text = prefabScript.energy.ToString();
	}

	private void Update() {
		if (gameManager.playerEnergy >= prefabScript.energy) {
			isAvailable = true;
			canvasGroup.alpha = 1;
		}
		else {
			isAvailable = false;
			canvasGroup.alpha = 0.5f;
		}
	}

	public void OnBeginDrag(PointerEventData eventData) {
		if (isAvailable) {
			startPosition = gameObject.transform.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (isAvailable) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.transform.tag != "tower") {
					Instantiate(prefabAmo, hit.transform.position, Quaternion.identity);
					gameManager.playerEnergy -= prefabScript.energy;
				}
			}
			gameObject.transform.position = startPosition;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (isAvailable) {
			rectTransform.anchoredPosition += eventData.delta;
		}
		else {
			return;
		}
	}
}
