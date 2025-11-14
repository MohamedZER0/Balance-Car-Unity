using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("GAME WON !!");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // Check if there's a next level, otherwise loop back to the first level
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("All levels completed! Restarting from level 1.");
                SceneManager.LoadScene(0);
            }
        }
    }
}
