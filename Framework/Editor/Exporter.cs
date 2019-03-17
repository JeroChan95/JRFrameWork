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
using System.IO;
using UnityEditor;

namespace JRFrameWork
{
    public class Exporter
    {

        [MenuItem("JRFrameWork/Editor/01   导出UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            string _fileName = "JRFrameWork_" + System.DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
            string _exportPath = @"C:\U3D_Project\游戏开发备份\个人框架";
            string _assetPath = "Assets/JRFrameWork";
            Exporter.ExportPackage(_assetPath, _exportPath + "/" + _fileName);
        }

        /// <summary>
        /// 打包文件    _assetPath需打包的资源全路径     _filePath目标路径       _isOpenFolder打包成功是否弹出文件夹提示
        /// </summary>
        public static void ExportPackage(string _assetPath, string _filePath, bool _isOpenFolder = true)
        {
            string _exportPath = Path.Combine(_filePath, "../");
            //导出路径存在判定
            if (!Directory.Exists(_exportPath))
            {
                Directory.CreateDirectory(_exportPath);
            }

            //导出Package
            AssetDatabase.ExportPackage(_assetPath, _filePath, ExportPackageOptions.Recurse);

            //导出结果判断
            if (File.Exists(_filePath))
            {
                Debug.Log("资源导出成功：" + _filePath);
                if (_isOpenFolder)
                {
                    Application.OpenURL(_exportPath);
                }
            }
            else
            {
                Debug.LogWarning("资源导出失败，目标路径为：" + _filePath);
            }
        }
    }
}
