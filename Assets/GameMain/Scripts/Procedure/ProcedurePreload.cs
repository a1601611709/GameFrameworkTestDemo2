using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameMain.Scripts.DataTable;
using Unity.VisualScripting;

namespace StarForceDemo
{
    public class ProcedurePreload : ProcedureBase
    {

        public static readonly string[] DataTableNames = new string[]
        {
            "Aircraft",
            "Armor",
            "Asteroid",
            "Entity",
            "Music",
            "Scene",
            "Sound",
            "Thruster",
            "UIForm",
            "UISound",
            "Weapon",
        };

        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

        public override bool UseNativeDialog { get { return true; } }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnAddListener()
        {
            
        }

        private void onRemoveListener()
        {
            
        }

        private void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            m_LoadedFlag.Add(dataTableName, false);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
        }
        
        // TODO:写到这里了，继续写资源预加载
    }
}