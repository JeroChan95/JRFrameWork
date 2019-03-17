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
    public class MathUtil
    {


        /// <summary>
        /// 根据概率判断是否命中（0-100）
        /// </summary>
        public static bool RandomFocus(int _accuracyPercent)
        {
            return Random.Range(1, 100) <= _accuracyPercent;
        }

        /// <summary>
        /// 获得随机值
        /// </summary>
        public static T GetRandomValueFrom<T>(params T[] _params)
        {
            return _params[UnityEngine.Random.Range(0, _params.Length)];
        }
    }
}