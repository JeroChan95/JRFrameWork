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
using System;

namespace JRFrameWork
{
    public class EventsUtil
    {
        private static Dictionary<string, Action<object>> mdic_msg = new Dictionary<string, Action<object>>();

        /// <summary>
        /// 注册消息
        /// </summary>
        public static void RegisterMsg(string _msgName, Action<object> _handle)
        {
            if (!mdic_msg.ContainsKey(_msgName))
            {
                mdic_msg.Add(_msgName, (_obj) => { });
            }

            mdic_msg[_msgName] += _handle;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public static void SendMsg(string _msgName, object _param)
        {
            if (mdic_msg.ContainsKey(_msgName))
            {
                mdic_msg[_msgName](_param);
            }
            else
            {
                Debug.LogWarning("【EventsUtil】发送消息失败：【" + _msgName + "】不存在");
            }
        }

        /// <summary>
        /// 注销所有消息
        /// </summary>
        public static void UnRegisterMsgAll(string _msgName)
        {
            if (mdic_msg.ContainsKey(_msgName))
            {
                mdic_msg[_msgName] = null;
                mdic_msg.Remove(_msgName);
            }
            else
            {
                Debug.Log("【EventsUtil】注销消息失败：【" + _msgName + "】不存在");
            }
        }

        /// <summary>
        /// 注销消息
        /// </summary>
        public static void UnRegisterMsg(string _msgName, Action<object> _handle)
        {
            if (mdic_msg.ContainsKey(_msgName))
            {
                mdic_msg[_msgName] -= _handle;
            }
            else
            {
                Debug.Log("【EventsUtil】注销消息失败：【" + _msgName + "】不存在");
            }
        }
    }
}