using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");

        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255,  112,  0,  255);
            goalMat.color = Color.blue;
        }
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
