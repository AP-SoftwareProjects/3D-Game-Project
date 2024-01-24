using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            this.gameObject.GetComponent<Canvas>().enabled = !this.gameObject.GetComponent<Canvas>().enabled;
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;

            if (Cursor.visible)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1.0f;
        }
    }
}
