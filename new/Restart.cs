using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Кидаем скрипт на UI Button;
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
            Time.timeScale = 1;
        }
    }

    public void OnMouseDown()
    {
        Click = true;
    }
}
