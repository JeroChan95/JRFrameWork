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
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JRFrameWork
{
    public class MenuitemView
    {
#if UNITY_EDITOR



        [MenuItem("JRFrameWork/Example/判断屏幕分辨率参数", false, 1)]
        private static void MenuClicked_02()
        {
            Debug.Log("是否横屏：" + ResolutionCheck.IsHorizontalScreen() + "    |    分辨率为：" + Screen.width + ":" + Screen.height + "    |    参考设备：" + ResolutionCheck.GetResolutionDevice().ToString());
        }

        [MenuItem("JRFrameWork/Example/简易消息demo", false, 2)]
        private static void MenuClicked_03()
        {
            string _msg = "问好";
            System.Action<object> _act_01 = (_data) => { Debug.Log("收到1信息：" + _data); };
            System.Action<object> _act_02 = (_data) => { Debug.Log("收到2信息：" + _data); };
            EventsUtil.RegisterMsg(_msg, _act_01);
            EventsUtil.RegisterMsg(_msg, _act_02);
            EventsUtil.SendMsg(_msg, "1111");
            EventsUtil.UnRegisterMsg(_msg, _act_01);
            EventsUtil.SendMsg(_msg, "2222");
            EventsUtil.UnRegisterMsgAll(_msg);
        }
#endif
    }
}