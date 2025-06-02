using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    float delay = 2f;

    Flipper pI;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip failSFX;
    AudioSource aSo;
    [SerializeField] ParticleSystem successVFX;
    [SerializeField] ParticleSystem failVFX;
    [SerializeField] MeshRenderer mR;
    [SerializeField] TextMeshPro scoreText;


    int score = 0;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        pI = GetComponent<Flipper>();
        aSo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if points are over 100 then you win
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Bumper":
                Bumper();
                break;
            case "Finish":
                WinState();
                break;
            case "Ouch":
                FailState();
                break;
            default:

                break;
        }
    }

    private void WinState()
    {
        successVFX.Play();
        aSo.PlayOneShot(successSFX, 0.5f);
        Invoke("LoadNextLevel", delay);
    }

    private void Bumper()
    {
        
        score++;
        Debug.Log(score);
        aSo.PlayOneShot(successSFX, 0.5f);
        successVFX.Play();

    }

    private void FailState()
    {
        failVFX.Play();
        aSo.PlayOneShot(failSFX, 0.5f);
        pI.enabled = false;
        Invoke("ReloadLevel", delay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
