using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace StellarCore
{
    public class BackButton : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                switch (SceneManager.GetActiveScene().name)
                {
                    case "MainMenu":
                        Application.Quit();
                        break;
                    case "ProtonProtonChain":
                        SceneManager.LoadSceneAsync("MainMenu");
                        break;
                }
        }
    }
}