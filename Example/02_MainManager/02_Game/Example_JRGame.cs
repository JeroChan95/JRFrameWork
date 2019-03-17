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

public class Example_JRGame : MainManager
{
    protected override void LaunchInDevelopingMode()
    {
        Debug.Log("进来了开发者模式！");
    }

    protected override void LaunchInProductionMode()
    {
        Debug.Log("进来了发布模式！");
    }

    protected override void LaunchInTestMode()
    {
        Debug.Log("进来了测试模式！");
    }
}