using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 音效管理器
    /// </summary>
    // 要求元件(元件類型) 套用腳本時同步添加此物件
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static SoundManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static SoundManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<SoundManager>();

                return _instance;
            }
        }
        #endregion

        [Header("音效資料"), SerializeField]
        public AudioClip[] allSounds;

        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        public void PlaySound(SoundType soundType)
        {
            aud.PlayOneShot(allSounds[(int)soundType]);
        }

        /// <summary>
        /// 播放音效: 隨機音量 能指定最大最小音量
        /// </summary>
        /// <param name="soundType"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void PlaySound(SoundType soundType, float min, float max) 
        {
            float volume = Random.Range(min, max);

            aud.PlayOneShot(allSounds[(int)soundType], volume);
        }
    }
}