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
using System.Reflection;
using System;

namespace JRFrameWork
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T mInstance = null;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("More than 1");
                        return mInstance;
                    }

                    if (mInstance == null)
                    {
                        var instanceName = typeof(T).Name;
                        Debug.LogFormat("Instance Name: {0}", instanceName);
                        var instanceObj = GameObject.Find(instanceName);

                        if (!instanceObj)
                            instanceObj = new GameObject(instanceName);

                        mInstance = instanceObj.AddComponent<T>();
                        DontDestroyOnLoad(instanceObj); //保证实例不会被释放

                        Debug.LogFormat("Add New Singleton {0} in Game!", instanceName);
                    }
                    else
                    {
                        Debug.LogFormat("Already exist: {0}", mInstance.name);
                    }
                }

                return mInstance;
            }
        }

        protected virtual void OnDestroy()
        {
            mInstance = null;
        }
    }

    public abstract class Single<T> where T : Single<T>
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    //mInstance = new Single() as T;

                    ConstructorInfo[] _ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                    ConstructorInfo _ctor = Array.Find<ConstructorInfo>(_ctors, _c => _c.GetParameters().Length == 0);

                    if (_ctor == null)
                        throw new Exception("Non-public ctor() not found!");

                    mInstance = _ctor.Invoke(null) as T;
                }

                return mInstance;
            }
        }

        protected Single() { }
    }
}