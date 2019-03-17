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
using UnityEngine.EventSystems;

namespace JRFrameWork
{
    public abstract class JRMonoBehaviour : MonoBehaviour
    {

        #region EventSystem
        /// <summary>
        /// 记录当前脚本生命周期内的事件
        /// </summary>
        private List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        /// <summary>
        /// 注册消息封装
        /// </summary>
        public void RegisterMsg(string _msgName, Action<object> _handle)
        {
            EventsUtil.RegisterMsg(_msgName, _handle);
            MsgRecord _record = MsgRecord.Allocate(_msgName, _handle);
            mMsgRecorder.Add(_record);
        }

        /// <summary>
        /// 信息的发送
        /// </summary>
        public void SendMsg(string _msgName, object _obj)
        {
            EventsUtil.SendMsg(_msgName, _obj);
        }

        /// <summary>
        /// 注销消息
        /// </summary>
        public void UnRegisterMsg(string _msgName)
        {
            List<MsgRecord> _records = mMsgRecorder.FindAll(_record =>
            {
                return _record.msgName == _msgName;
            });
            if (_records.Count > 0)
            {
                for (int i = 0; i < _records.Count; i++)
                {
                    EventsUtil.UnRegisterMsg(_records[i].msgName, _records[i].handle);
                    _records[i].Recycle();
                    mMsgRecorder.Remove(_records[i]);
                }
            }
        }

        /// <summary>
        /// 注销消息
        /// </summary>
        public void UnRegisterMsg(string _msgName, Action<object> _handle)
        {
            List<MsgRecord> _records = mMsgRecorder.FindAll(_record =>
            {
                return _record.msgName == _msgName && _record.handle == _handle;
            });
            if (_records.Count > 0)
            {
                for (int i = 0; i < _records.Count; i++)
                {
                    EventsUtil.UnRegisterMsg(_records[i].msgName, _records[i].handle);
                    _records[i].Recycle();
                    mMsgRecorder.Remove(_records[i]);
                }
            }
        }

        /// <summary>
        /// 替代原生的OnDestroy方法
        /// </summary>
        protected abstract void OnBeforeDestroy();

        /// <summary>
        /// 更改OnDestroy方法处理事件的自动注销
        /// </summary>
        private void OnDestroy()
        {
            OnBeforeDestroy();
            if (mMsgRecorder.Count > 0)
            {
                for (int i = mMsgRecorder.Count - 1; i >= 0; i--)
                {
                    EventsUtil.UnRegisterMsg(mMsgRecorder[i].msgName, mMsgRecorder[i].handle);
                    mMsgRecorder[i].Recycle();
                }
                mMsgRecorder.Clear();
            }
        }

        /// <summary>
        /// 消息键值对封装
        /// </summary>
        private class MsgRecord
        {
            private static Stack<MsgRecord> mPool = new Stack<MsgRecord>();
            public string msgName;
            public Action<object> handle;

            public static MsgRecord Allocate(string _msgName, Action<object> _handle)
            {
                MsgRecord _record = null;
                if (mPool.Count > 0)
                    _record = mPool.Pop();
                else
                    _record = new MsgRecord();

                _record.msgName = _msgName;
                _record.handle = _handle;
                return _record;
            }

            public void Recycle()
            {
                msgName = null;
                handle = null;
                mPool.Push(this);
            }
        }


        #endregion


        #region UI界面监听注册
        protected void OnClickDown(GameObject _go, Action<PointerEventData> _callback)
        {
            JRListener _listener = _go.AddComponent<JRListener>();
            _listener.onClickDown = _callback;
        }

        protected void OnDrag(GameObject _go, Action<PointerEventData> _callback)
        {
            JRListener _listener = _go.AddComponent<JRListener>();
            _listener.onDrag = _callback;
        }

        protected void OnClickUp(GameObject _go, Action<PointerEventData> _callback)
        {
            JRListener _listener = _go.AddComponent<JRListener>();
            _listener.onClickUp = _callback;
        }
        #endregion
    }
}