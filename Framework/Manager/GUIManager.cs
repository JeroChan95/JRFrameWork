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
    public enum UILayer
    {
        Bg,
        Common,
        Top
    }

    public class GUIManager
    {
        private static GameObject mUIRoot;

        public static GameObject UIRoot
        {
            get
            {
                if (mUIRoot == null)
                {
                    mUIRoot = GameObject.Instantiate(Resources.Load<GameObject>("UIRoot"));
                    mUIRoot.name = "UIRoot";
                }
                return mUIRoot;
            }
        }

        private static Dictionary<string, GameObject> mdic_panel = new Dictionary<string, GameObject>();

        public static void UnLoadPanel(string panelName)
        {
            if (mdic_panel.ContainsKey(panelName))
            {
                Object.Destroy(mdic_panel[panelName]);
            }
        }

        public static GameObject LoadPanel(string panelName, UILayer uiLayer)
        {
            var panelPrefab = Resources.Load<GameObject>(panelName);
            var panelObj = Object.Instantiate(panelPrefab);
            panelObj.name = panelName;

            mdic_panel.Add(panelName, panelObj);

            switch (uiLayer)
            {
                case UILayer.Bg:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
                case UILayer.Common:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
            }

            var panelRectTrans = panelObj.transform as RectTransform;

            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;

            panelRectTrans.localScale = Vector3.one;

            return panelObj;
        }
    }
}