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
using UnityEngine.SceneManagement;
using JRFrameWork;


public class Example_JRHome : MainManager
{
    protected override void LaunchInDevelopingMode()
    {
        Debug.Log("加载开发者模块...");
        SceneManager.LoadScene("JRGame");
    }

    protected override void LaunchInProductionMode()
    {
        Debug.Log("加载产品模块...");
        SceneManager.LoadScene("JRGame");
    }

    protected override void LaunchInTestMode()
    {
        Debug.Log("加载测试模块...");
        SceneManager.LoadScene("JRGame");
    }
}