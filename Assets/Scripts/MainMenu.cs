using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace StellarCore
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadSceneAsync("ProtonProtonChain");
        }

        public void Stats()
        {
            SceneManager.LoadSceneAsync("Stats");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}