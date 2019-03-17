/*
*	
*	Title:JeroChan的框架
*		[副标题]
*
*	Description:
*		[描述]
*
*	Data:2018
*
*	Version:0.1
*
*	Modify Recoder:JeroChan
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JRFrameWork;


public class JRFW_TestScripts : JRMonoBehaviour
{

    AudioClip mAudioClip = null;
    GameObject mGO = null;

    private void Start()
    {
        RegisterMsg("吃饭", (_data) => { Debug.Log("先干嘛：" + _data); });
        RegisterMsg("吃饭", (_data) => { Debug.Log("然后：" + _data); });
        RegisterMsg("拉屎", (_data) => { Debug.Log("先干嘛：" + _data); });
        RegisterMsg("拉屎", (_data) => { Debug.Log("然后：" + _data); });

        StartCoroutine(IE_A());

        Debug.LogWarning("随机数为：" + Random.Range(0, 9999));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SendMsg("吃饭", "正常人啊");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SendMsg("拉屎", "外星");
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        Debug.LogWarning("时间为：" + Time.realtimeSinceStartup);
    }

    protected override void OnBeforeDestroy()
    {
    }


    private IEnumerator IE_A()
    {
        Debug.Log("****  A  ****  1");
        yield return IE_B();
        Debug.Log("****  A  ****  2");
    }

    private IEnumerator IE_B()
    {
        Debug.Log("****  B  ****  1");
        yield return null;
        Debug.Log("****  B  ****  2");
    }

}