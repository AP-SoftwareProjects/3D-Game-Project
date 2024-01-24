using Cinemachine;
using UnityEngine;

public class BusCanScript : MonoBehaviour
{

	public float interactionRange = 4f;
	public KeyCode interactionKey = KeyCode.E;

	private GameObject _currentBus;

	[SerializeField] private CinemachineVirtualCamera _camera;
	private Camera _normalCamera;

	private Canvas canvasCar = null;
	private Canvas canvasHud = null;
	void Start()
	{
		_normalCamera = _camera.GetComponent<Camera>();

		canvasHud = GameObject.Find("HUD").GetComponentInChildren<Canvas>();
		canvasCar = GameObject.Find("Bus").GetComponentInChildren<Canvas>();
	}

	void Update()
	{
		_currentBus = GetLookingBus();
		if (_currentBus != null && Input.GetKeyDown(interactionKey))
		{
			Time.timeScale = 0;
			canvasCar.enabled = true;
			canvasHud.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
			
	}	

	GameObject GetLookingBus()
	{
		Ray ray = _normalCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
		{
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Bus"))
				return hit.collider.gameObject;
		}

		return null;
	}
}
