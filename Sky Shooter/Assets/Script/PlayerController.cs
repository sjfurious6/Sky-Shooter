using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    #region
    private float thrust = 5f;
    private float rotationSpeed = 180f;
    private float maxSpeed = 3f;
    private Camera mainCamera;
    private Rigidbody rigidBody;
    private float nextFire;
    private AudioSource audioSource;
    #endregion

    [SerializeField]
    GameObject playerExplosion;

    #region
    public ParticleSystem EngineEffect;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    #endregion

    void Start()
    {
        mainCamera = Camera.main;
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (GameSetting.gameStatus == GameSetting.GameStatus.GAME_START)            
        {
            ControlRocket();
            CheckPosition();
        }

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space") && GameSetting.gameStatus == GameSetting.GameStatus.GAME_START)
        {
            Shoot();                          
        }
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (GameSetting.gameStatus == GameSetting.GameStatus.GAME_START)
        {
            if (other.gameObject.tag.Equals(GameSetting.EnemyTag))
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject);
            }
            if (other.tag.Equals(GameSetting.EnemyTag))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
        }
        
    }

    /// <summary>
    /// bullet is instantiating in the scene
    /// </summary>
    void Shoot()
    {
        if (GameSetting.gameStatus == GameSetting.GameStatus.GAME_START)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shot.tag = GameSetting.PlayerBulletTag;
            audioSource.Play();
            CheckScore();
        }
    }

    void CheckScore()
    {

        GameManager.Instance.PlayerScore = GameSetting.currentScore.ToString();
        if (GameSetting.currentScore >= 100*GameSetting.level)
        {
            GameSetting.gameStatus = GameSetting.GameStatus.GAME_LEVEL_UP;
            GameManager.Instance.LevelUp();            
        }

        if (GameSetting.currentScore > GameSetting.highScore)
        {
            GameSetting.highScore = GameSetting.currentScore;
            PlayerPrefs.SetInt(GameSetting.HighScoreValue, GameSetting.highScore);
        }        
    }


    /// <summary>
    /// here we are controlling the movement of the rocket by the key inputs
    /// </summary>
    private void ControlRocket()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rigidBody.AddForce(transform.up* thrust * Input.GetAxis("Vertical"));        
        rigidBody.velocity = new Vector2(Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rigidBody.velocity.y, -maxSpeed, maxSpeed));
        if(Input.GetAxis("Vertical")>0)
        {
            EngineEffect.Play();
        }
        else
            EngineEffect.Stop();
    }

    /// <summary>
    /// here we are calculating the boundry of the screen so that the rocket will always be in the screen area. 
    /// </summary>
    private void CheckPosition()
    {
        float sceneWidht = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        float sceneHight = mainCamera.orthographicSize * 2;

        float sceneRightEdge = sceneWidht / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        if (transform.position.x > sceneRightEdge)
        {
            transform.position = new Vector3(sceneLeftEdge, transform.position.y,20);
        }
        if (transform.position.x < sceneLeftEdge)
        {
            transform.position = new Vector3(sceneRightEdge, transform.position.y,20);
        }
        if (transform.position.y > sceneTopEdge)
        {
            transform.position = new Vector3(transform.position.x, sceneBottomEdge,20);
        }
        if (transform.position.y < sceneBottomEdge)
        {
            transform.position = new Vector3(transform.position.x, sceneTopEdge,20);
        }
    }

    public void Reset()
    {
        transform.position = new Vector2(0f, 0f);
        transform.eulerAngles = new Vector3(0,180f,0);
        rigidBody.velocity = new Vector3(0f, 0f, 0f);
        rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
    }
}
