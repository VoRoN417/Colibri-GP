using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool Click = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Click == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnMouseDown()
    {
        Click = true;
    }
}
