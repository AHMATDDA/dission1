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
                    text.text = " 똑똑.. ";
                    break;
                }
            case 4:
                {
                    text.text = " 안녕하세요. 의뢰하고 싶어서 찾아오게 되었어요.";
                    break;
                }
            case 8:
                {
                    text.text = " 저는 제가 왜 죽었는 지 알고싶어서 왔어요,," +
                        "풍족하지는 않았지만 행복하게 살고 있었던 것 같은데,,!";
                    break;
                }
            case 13:
                {
                    text.text = " 꼭 부탁드립니다..";
                    button1.SetActive(true);
                    break;
                }
        }

    }
}
