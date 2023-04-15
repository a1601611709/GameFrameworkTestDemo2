using GameFramework;
using GameFramework.ObjectPool;
using UnityEngine;

namespace StarForceDemo
{
    public class HPBarItemObject : ObjectBase
    {
        public static HPBarItemObject Create(object target)
        {
            HPBarItemObject hPBarItemObject = ReferencePool.Acquire<HPBarItemObject>();
            hPBarItemObject.Initialize(target);
            return hPBarItemObject;
        }

        protected override void Release(bool isShutdown)
        {
            HPBarItem hpBarItem = (HPBarItem)Target;
            if(hpBarItem == null)
            {
                return;
            }

            Object.Destroy(hpBarItem.gameObject);
        }
    }
}
