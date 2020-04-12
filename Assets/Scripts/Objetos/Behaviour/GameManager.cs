using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    //public GameObject openGameOver;
    //private Player _checkPlayer;
    //private int playerHits;
    //private GameObject playerFinder;

    /*public void Awake()
    {
        _checkPlayer = GetComponent<Player>();
        playerHits = _checkPlayer._hits;
        playerFinder.tag = "Player";
    }
    public void FixedUpdate()
    {
        if (playerHits != 0 && playerFinder.tag != null)
        { 
            playerHits = _checkPlayer._hits;
        }        
        else
        {
            openGameOver.SetActive(true);
        }
    }
    */
    public void GameEnds()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
