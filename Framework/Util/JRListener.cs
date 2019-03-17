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

using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace JRFrameWork
{
    public class JRListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public Action<PointerEventData> onClickDown;
        public Action<PointerEventData> onDrag;
        public Action<PointerEventData> onClickUp;

        public void OnPointerDown(PointerEventData _eventData)
        {
            if (onClickDown != null)
            {
                onClickDown(_eventData);
            }
        }

        public void OnDrag(PointerEventData _eventData)
        {
            if (onDrag != null)
            {
                onDrag(_eventData);
            }
        }

        public void OnPointerUp(PointerEventData _eventData)
        {
            if (onClickUp != null)
            {
                onClickUp(_eventData);
            }
        }
    }
}