
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private void Start()
    {
        Invoke("LoadLevel", 5f);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_01");
    }
}
