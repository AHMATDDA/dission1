using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    public GameObject BlackBack;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        // 서브 메뉴
        if(Input.GetButtonDown("Cancel"))
        {
            if (BlackBack.activeSelf)
                BlackBack.SetActive(false);
            else
                BlackBack.SetActive(true);
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
