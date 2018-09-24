using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {

    public float delayTime=3f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("aiudfhasdkljfnalieufhalisdjfhnalisuehfaojdskfnalskdjfh");
            Invoke("GameRestart",3f);
        }
    }

    void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("aiudfhasdkljfnalieufhalisdjfhnalisuehfaojdskfnalskdjfh");
    }
}
