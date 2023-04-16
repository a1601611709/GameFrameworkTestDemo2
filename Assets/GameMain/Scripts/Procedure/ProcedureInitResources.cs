using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace StarForceDemo
{
    public class ProcedureInitResources : ProcedureBase
    {
        private bool m_InitResourcesComplete;
        
        public override bool UseNativeDialog
        {
            get { return true; }
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_InitResourcesComplete = false;
            
            GameEntry.Resource.InitResources(onInitResourcesComplete);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_InitResourcesComplete)
            {
                //初始化资源未完成，继续等待
                return;
            }
            
            ChangeState<ProcedurePreload>(procedureOwner);
        }

        private void onInitResourcesComplete()
        {
            m_InitResourcesComplete = true;
            Log.Info("Init resource complete");
        }
    }
}