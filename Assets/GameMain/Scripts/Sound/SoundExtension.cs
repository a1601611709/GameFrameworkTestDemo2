


using GameFramework.Sound;
using UnityEditor.Playables;
using UnityGameFramework.Runtime;
using Utility = GameFramework.Utility;

namespace StarForceDemo
{
    public static class SoundExtension
    {
        private const float FadevolumeDuration = 1f;
        private static int? s_MusicSerialId = null;

        /// <summary>
        /// 是否静音
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        /// <param name="soundGroupName">声音的父组件名</param>
        /// <returns></returns>
        public static bool isMute(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid");
                return true;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid");
                return true;
            }

            return soundGroup.Mute;
        }
        
        //TODO:搞懂这个this是干嘛的
        public static void Mute(this SoundComponent soundComponent, string soundGroupName, bool mute)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound Group is invalid");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("sound group '{0}' is invalid");
                return;
            }

            soundGroup.Mute = mute;
            
            GameEntry.Setting.SetBool(Utility.Text.Format(Constant.Setting.SoundGroupMuted, soundGroupName), mute);
            GameEntry.Setting.Save();
        }

        public static float getVolume(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound Group is invalid");
                return 0f;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("sound group '{0}' is invalid");
                return 0f;
            }

            return soundGroup.Volume;
        }

        public static void setVolume(this SoundComponent soundComponent, string soundGroupName, float volume)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound Group is invalid");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("sound group '{0}' is invalid");
                return;
            }

            soundGroup.Volume = volume;
            GameEntry.Setting.SetFloat(Utility.Text.Format(Constant.Setting.SoundGroupVolume, soundGroupName), volume);
            GameEntry.Setting.Save();
        }
    }
}