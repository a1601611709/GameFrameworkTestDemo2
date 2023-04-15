using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarForceDemo
{
    public partial class GameEntry : MonoBehaviour
    {
        /// <summary>
        /// 游戏入口
        /// </summary>
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
        }
    }
}


