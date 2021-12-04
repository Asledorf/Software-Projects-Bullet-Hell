using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public bool soundToMenu = true;
        static SceneController instance = null;
        public static SceneController Instance { get { return instance; } }
     
        public void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(instance.gameObject);
                instance = this;
            }

            DontDestroyOnLoad(this);
        }

        public void OnLoadScene(string sceneString)
        {
            StartCoroutine(LoadScene(sceneString));
        }

        public IEnumerator LoadScene(string sceneString)
        {
            SceneManager.LoadScene(sceneString);

            yield return null;
        }
    }
}
