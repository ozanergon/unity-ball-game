using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void New() // New Game dediğimizde burası çalışır 
    {
        SaveLoadManager.decisior = 0;
        SceneManager.LoadScene(1);
    }

    public void Load() // Load Last Game dediğimizde burası çalışır
    {
        SaveLoadManager.decisior = 1;
        SceneManager.LoadScene(1);
    }

    public void Quit() // Esc'ye basıp oyundan çıkmak istediğimizde burası çalışır
    {
        Application.Quit();
    }
}