using System.Collections;
using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 淡入淡出系統
    /// </summary>
    public class FadeSystam : MonoBehaviour
    {
        /// <summary>
        /// 淡入淡出
        /// </summary>
        /// <param name="group"></param>
        /// <param name="fadeIn"></param>
        /// <returns></returns>
       public static IEnumerator Fade(CanvasGroup group,float delayTime = 0, bool fadeIn = true)
        {
            yield return new WaitForSeconds(delayTime);

            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0;i<10; i++)
            {
                group.alpha += increase;
                yield return new WaitForSeconds(0.03f);
            }

            group.interactable = fadeIn;
            group.blocksRaycasts = fadeIn;
        }
    }
}