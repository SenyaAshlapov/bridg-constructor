using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotTutorialStoper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Robot>())
        {
            SceneManager.LoadScene("Game");
        }
    }
}
