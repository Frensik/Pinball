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

    //Flipper pI;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip failSFX;
    AudioSource aSo;
    [SerializeField] ParticleSystem successVFX;
    [SerializeField] ParticleSystem failVFX;
    [SerializeField] MeshRenderer mR;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button restart;
    [SerializeField] Canvas deathCanvas;


    int score = 0;

    void Start()
    {
        //gets current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //pI = GetComponent<Flipper>();
        aSo = GetComponent<AudioSource>();
        deathCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        //attributes the score to the UI text
        scoreText.text = "score " + score.ToString();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //different things will happen depending on which tag an object has that the ball collides with
        switch (other.gameObject.tag)
        {
            case "Bumper":
                Bumper();
                break;
            case "Ouch":
                FailState();
                break;
            default:
                break;
        }
    }

    private void Bumper()
    {
        //adds to the score
        //plays a noise
        score++;
        Debug.Log(score);
        aSo.PlayOneShot(successSFX, 0.5f);

    }

    private void FailState()
    {
        failVFX.Play();
        aSo.PlayOneShot(failSFX);
        //pI.enabled = false;
        //deathCanvas.gameObject.SetActive(true);
        //restart.onClick.AddListener(ReloadLevel);
        //Invoke("ReloadLevel", delay);
    }

    public void ReloadLevel()
    {
        //reloads the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
