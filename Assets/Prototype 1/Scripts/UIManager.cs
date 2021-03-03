using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Prototype1
{
    public class UIManager : Singleton<UIManager>
    {

        public GameObject startMenu;
        public GameObject deathMenu;
        public Text timerText;

        void Start()
        {
            Time.timeScale = 0;
            deathMenu.SetActive(false);
            startMenu.SetActive(true);
        }

        void Update()
        {
            timerText.text = _GM1.currentTime.ToString("F2");
        }



        public void Play()
        {
            startMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public void Quit()
        {
            Application.Quit();
            print("Quit");
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
