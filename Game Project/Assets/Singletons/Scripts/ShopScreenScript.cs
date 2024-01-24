using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreenScript : MonoBehaviour
{
    private static ShopScreenScript instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ShopScreenScript Instance
    {
        get
        {
            if (instance == null)
                instance = new();
            return instance;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
