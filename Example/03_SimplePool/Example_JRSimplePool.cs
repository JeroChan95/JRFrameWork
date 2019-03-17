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
    public class Example_JRSimplePool : MonoBehaviour
    {
        SimplePoolUtil<GameObject> mFishPool;
        List<GameObject> l_gobj = new List<GameObject>();
        private void Start()
        {
            mFishPool = new SimplePoolUtil<GameObject>(() => { return new GameObject(); }, null);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                l_gobj.Add(mFishPool.Spawn());
                Debug.Log(mFishPool.CurCount);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (l_gobj.Count>0)
                {
                    mFishPool.DeSpawn(l_gobj[0]);
                    l_gobj.RemoveAt(0);
                }
                Debug.Log(mFishPool.CurCount);
            }
        }
    }
}