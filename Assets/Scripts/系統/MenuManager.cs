using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Lodiya
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Button startBtu;

        [SerializeField]
        private Button setingBtu;
        [SerializeField]
        private CanvasGroup setingGroup;
        [SerializeField]
        private Button setingBtuQuit;

        private void Awake()
        {
            startBtu.onClick.AddListener(() =>
                SceneManager.LoadScene("地雷地城"));

            setingBtu.onClick.AddListener(() =>
                StartCoroutine(FadeSystam.Fade(setingGroup)));

            setingBtuQuit.onClick.AddListener(() =>
                StartCoroutine(FadeSystam.Fade(setingGroup, 0, false)));
        }
    }
}