using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = rigid;
    }
    //TalkImage�� �ڽ����� �ִ� TalkText�� �����ͼ� �װ��� scanObject�� �̸��� text�� �������ش�.
    // Update is called once per frame



    void Update()
    {
        if (Input.GetButtonDown("Jump") && scanObj != null)
        {
            Debug.Log(scanObj);
            manager.ShowText(scanObj);
        }
    }

    void FixedUpdate()
    {
        //Debug.DrawRay(rigid.position, playerDir * 1.0f, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, playerDir, 1.0f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
    }
}
