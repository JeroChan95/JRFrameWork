using UnityEngine;
using System.Collections;

namespace JRFrameWork
{
    public class ShowFPS : MonoBehaviour
    {
        public float mUpdateInterval = 0.5F;        //检测间隔
        private float mLastInterval;                //最后检测时间轴标识
        private int mFrames = 0;                    //计算帧数标识
        private float mFps;                         //  帧/秒

        private GUIStyle mStyle = new GUIStyle();   //字体大小，颜色


        void Start()
        {
            Application.targetFrameRate = 300;
            mLastInterval = Time.realtimeSinceStartup;
            mFrames = 0;

            mStyle.fontSize = 10;
            mStyle.normal.textColor = new Color(0, 255, 0, 255);
        }


        void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 200, 200), "FPS:" + mFps.ToString("f2"), mStyle);
        }


        void Update()
        {
            mFrames++;

            if (Time.realtimeSinceStartup > mLastInterval + mUpdateInterval)
            {
                mFps = mFrames / (Time.realtimeSinceStartup - mLastInterval);
                mFrames = 0;
                mLastInterval = Time.realtimeSinceStartup;
            }
        }
    }
}