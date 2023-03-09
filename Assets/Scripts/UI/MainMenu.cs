using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TowerDefense
{

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button m_Restart;
        [SerializeField] private Button m_Continue;
        [SerializeField] private GameObject m_panel;

        private void Start()
        {
            continueButton.interactable = FileHandler.HasFile(MapCompletion.filename);
        }
        public void NewGame() 
        {
            if (continueButton.interactable == false)
            {
                StartNewGame();
            }
            if (continueButton.interactable == true)
            {
                m_panel.SetActive(true);
            }
        }

        public void StartNewGame()
        {
            FileHandler.Reset(MapCompletion.filename);
            FileHandler.Reset(Upgrades.filename);
            SceneManager.LoadScene(1);
        }


        public void Cancel()
        {
            m_panel.SetActive(false);
        }



        public void Continue()
        {
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
           Application.Quit();
        }


    }
}