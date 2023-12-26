using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Tester");
        if (collision.tag == "Player")
            SceneManager.LoadScene("Level5");
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
