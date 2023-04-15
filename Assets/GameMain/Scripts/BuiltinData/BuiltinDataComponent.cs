using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace StarForceDemo
{
    /// <summary>
    /// 内置数据Component
    /// </summary>
    public class BuiltinDataComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;
        
        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset = null;

        [SerializeField]
        private UpdateResourceForm m_UpdateResourceFormTemplate = null;

        private BuildInfo m_BuildInfo = null;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }

        public UpdateResourceForm UpdateResourceFormTemplate
        {
            get
            {
                return m_UpdateResourceFormTemplate;
            }
        }
        //TODO:了解BuildInfo是干嘛的
        /// <summary>
        /// 初始化BuildInfo
        /// </summary>
        public void InitBuildInfo()
        {
            if(m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not bo found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if(m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }
        }

        //TODO:了解DefaultDictionary是干嘛的
        /// <summary>
        /// 初始化DefaultDictionary
        /// </summary>
        public void InitDefaultDictionary()
        {
            if(m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not bo found or empty.");
            }

            if(!GameEntry.Localization.ParseData(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }

    }
}
