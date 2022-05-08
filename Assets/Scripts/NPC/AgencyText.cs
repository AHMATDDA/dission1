using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgencyText : MonoBehaviour
{
    public float time;

    public Text text;

    int num;

    public GameObject button1;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        num = (int)time;
        switch(num)
        {
            case 1:
                {
                    text.text = " 첫 번째 대사.. ~~~~~~ ";
                    break;
                }
            case 5:
                {
                    text.text = " 두 번째 대사.. !!!!!!!";
                    break;
                }
            case 9:
                {
                    text.text = " 세 번째 대사.. ********";
                    break;
                }
            case 13:
                {
                    text.text = " 네 번째 대사.. ^^^^^^^^";
                    button1.SetActive(true);
                    break;
                }
        }

    }
}
