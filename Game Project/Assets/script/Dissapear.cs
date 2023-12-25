using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissapear : MonoBehaviour
{

    public GameObject MainCanvas;
    Text points;
    // Start is called before the first frame update
    void Start()
    {
        points = MainCanvas.GetComponent<Text>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            points.text = (int.Parse(points.text) + 1).ToString();
        }
        
    }

}
