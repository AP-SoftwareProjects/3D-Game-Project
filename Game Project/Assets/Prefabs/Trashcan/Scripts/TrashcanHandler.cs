using TMPro;
using UnityEngine;

public class TrashcanHandler : MonoBehaviour
{
    public float maxDistance = 2f;
    public string cameraTag = "Head";

    void Start()
    {
    }
    void Update()
    {
        GameObject[] nearbyPlayer = GameObject.FindGameObjectsWithTag(cameraTag);

        if (nearbyPlayer.Length > 0)
        {
            GameObject hoverText = transform.Find("HoverText").gameObject;
            Canvas canvas = hoverText.GetComponent<Canvas>();
            foreach (GameObject player in nearbyPlayer)
            {
                if (player.GetComponent<Camera>() != null)
                {
                    canvas.worldCamera = nearbyPlayer[0].GetComponent<Camera>();
                    break;
                }
            }
        }
    }
}
