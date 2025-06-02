using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    float delay = 2f;

    //PlayerInput pM;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip failSFX;
    AudioSource aSo;
    [SerializeField] ParticleSystem successVFX;
    [SerializeField] ParticleSystem failVFX;
    [SerializeField] MeshRenderer mR;

    bool isTransitioning = false;



    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //pM = GetComponent<PlayerInput>();
        aSo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("bazinga");
                break;
            case "Finish":
                WinState();
                break;
            case "Boinko":
                break;
            default:
                FailState();
                break;
        }
    }

    private void WinState()
    {
        successVFX.Play();
        isTransitioning = true;
        aSo.PlayOneShot(successSFX, 0.5f);
        Invoke("LoadNextLevel", delay);
    }

    private void FailState()
    {
        failVFX.Play();
        mR.enabled = false;
        isTransitioning = true;
        aSo.PlayOneShot(failSFX, 0.5f);
        //pM.enabled = false;
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
