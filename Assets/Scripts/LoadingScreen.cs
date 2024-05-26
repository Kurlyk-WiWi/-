using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class LoadingScreen : MonoBehaviour
    {
        public GameObject Loadingscreen;
        public Slider scale;
       public void Loading1()
        {
            Loadingscreen.SetActive(true);
            StartCoroutine(LoadAsync());
        }
        IEnumerator LoadAsync()
        {
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
            loadAsync.allowSceneActivation = false;
            while(!loadAsync.isDone)
            {
                scale.value=loadAsync.progress;
                if(loadAsync.progress>=.9f && !loadAsync.allowSceneActivation)
                {
                    yield return new WaitForSeconds(2.2f);
                    loadAsync.allowSceneActivation=true;
                }
                yield return null;
            }

        }
        public void Loading0()
        {
            Loadingscreen.SetActive(true);
            StartCoroutine(LoadAsync0());
        }
        IEnumerator LoadAsync0()
        {
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync(0);
            loadAsync.allowSceneActivation = false;
            while (!loadAsync.isDone)
            {
                scale.value = loadAsync.progress;
                if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
                {
                    yield return new WaitForSeconds(2.2f);
                    loadAsync.allowSceneActivation = true;
                }
                yield return null;
            }

        }
    }

}