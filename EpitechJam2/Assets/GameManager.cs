using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        Target[] tags = FindObjectsOfType<Target>();
        foreach (Target t in tags) {
            if (!t.isDone()) {
                return;
            }
        }
        FindObjectOfType<CharacterController2D>().gameObject.SetActive(false);
        EnemyGFX[] EnemyGFXs = FindObjectsOfType<EnemyGFX>();
        foreach (EnemyGFX e in EnemyGFXs) {
            e.gameObject.SetActive(false);
        }
        GameObject[] uiObjects = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject obj in uiObjects)
            obj.SetActive(true);
        this.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
