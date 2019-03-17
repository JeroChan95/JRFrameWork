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

namespace JRFrameWork
{
    public class ResolutionCheck
    {
        /// <summary>
        /// 根据分辨率获取当前设备比例参考机型
        /// </summary>
        public static Device GetResolutionDevice()
        {
            float _ration = Screen.width > Screen.height ? ((float)Screen.width / Screen.height) : ((float)Screen.height / Screen.width);
            Debug.Log(_ration);
            if (CheckRange(2048f / 1536f, _ration))
                return Device.IPad;

            else if (CheckRange(960f / 640f, _ration))
                return Device.IPhone4;

            else if (CheckRange(1136f / 640f, _ration))
                return Device.IPhone5;

            else if (CheckRange(2436f / 1125f, _ration))
                return Device.IPhoneX;

            else
                return Device.None;
        }

        /// <summary>
        /// 判断当前是否为横屏状态
        /// </summary>
        public static bool IsHorizontalScreen()
        {
            return Screen.width > Screen.height ? true : false;
        }

        /// <summary>
        /// 比对分辨率 _ref参考分辨率   _self当前设备分辨率
        /// </summary>
        private static bool CheckRange(float _ref, float _self)
        {
            if ((_self < _ref + 0.05f) && (_self > _ref - 0.05f))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 参考设备
        /// </summary>
        public enum Device
        {
            None,       //不在下列范围
            IPad,       //4:3
            IPhone4,    //3:2
            IPhone5,    //16:9
            IPhoneX     //19.5:9
        }
    }
}