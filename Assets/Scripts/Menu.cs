using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject quitMenu;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            { 
                if(quitMenu.activeSelf) {
                    quitMenu.SetActive(false);
                }
                else
                    quitMenu.SetActive(true);
            }
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        public void Comehome()
        {
            quitMenu.SetActive(false);
        }
        /*public void StartFirst()
        {
            SceneManager.LoadScene("First");
        }*/
    }
}