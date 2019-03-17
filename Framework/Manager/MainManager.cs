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
    public abstract class MainManager : MonoBehaviour
    {
        public EnviromentMode mMode;
        private static EnviromentMode mShareMode;
        private static bool mModeSetted = false;

        private void Start()
        {
            if (!mModeSetted)
            {
                mShareMode = mMode;
                mModeSetted = true;
            }
            else
            {
                mMode = mShareMode;
            }

            switch (mShareMode)
            {
                case EnviromentMode.Developing:
                    LaunchInDevelopingMode();
                    break;
                case EnviromentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnviromentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
    }
    public enum EnviromentMode
    {
        Developing,
        Test,
        Production
    }
}