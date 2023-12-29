using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public float maxDistance = 2f;
    public string followTag = "Head";
    public GameObject hideGameobject;

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(followTag);

        if (players.Length > 0)
        {
            Transform playerTransform = players[0].transform;

            Vector3 directionToPlayer = playerTransform.position - hideGameobject.transform.position;
            float distanceToPlayer = Vector3.Distance(hideGameobject.transform.position, playerTransform.transform.position);

            if (distanceToPlayer > maxDistance)
                hideGameobject.SetActive(false);
            else
                hideGameobject.SetActive(true);

            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            lookRotation *= Quaternion.Euler(0, 180f, 0);
            hideGameobject.transform.rotation = lookRotation;
        }
    }
}
