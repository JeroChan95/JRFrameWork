/*
*	
*	Title:JeroChan的框架
*		[简易对象池实现]
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

using System;
using System.Collections.Generic;

namespace JRFrameWork
{
    public interface IPool<T>
    {
        T Spawn();
        bool DeSpawn(T _obj);
    }

    public abstract class Pool<T> : IPool<T>
    {
        protected Stack<T> mCacheObj = new Stack<T>();

        public int CurCount { get { return mCacheObj.Count; } }

        public abstract T Spawn();

        public abstract bool DeSpawn(T _obj);
    }

    public class SimplePoolUtil<T> : Pool<T>
    {
        private Func<T> mFunCreate;
        private Action<T> mActionReset;

        public SimplePoolUtil(Func<T> _funCreate, Action<T> _actReset = null, int initCount = 0)
        {
            mFunCreate = _funCreate;
            mActionReset = _actReset;
            //初始化缓存对象
            for (int i = 0; i < initCount; i++)
            {
                mCacheObj.Push(mFunCreate());
            }
        }

        public override T Spawn()
        {
            if (mCacheObj.Count > 0)
            {
                return mCacheObj.Pop();
            }
            else
            {
                return mFunCreate();
            }
        }

        public override bool DeSpawn(T _obj)
        {
            if (mActionReset != null)
            {
                mActionReset(_obj);
            }

            mCacheObj.Push(_obj);

            return true;
        }
    }
}