using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayButton : MonoBehaviour
{
   
    public void Play()
    {        
        
        Debug.Log("go play)"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
