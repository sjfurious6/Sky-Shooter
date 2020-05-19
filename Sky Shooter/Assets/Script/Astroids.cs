using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
    #region serialize field
    [SerializeField]
    GameObject explosion;

    #endregion

    #region public properties
    public Transform startPoint { get; set; }
    public Transform endPoint { get; set; }
    #endregion

    #region private variables
    private Rigidbody rb;
    private float speed = 0.1f;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.position = startPoint.position;        
    }
    
    void Update()
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(Time.time * speed, 1.0f));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(GameSetting.PlayerBulletTag))
        {
            CreateSmallAstroids();
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);//when hit by bullet ,it shows the effect
        }        
    }

    /// <summary>
    /// creating small astroides
    /// </summary>
    void CreateSmallAstroids()
    {
        for(int i = 0; i< 3; i++)
        {
            GameObject smallAstroid = Instantiate((Resources.Load("Prefabs/Asteroids/Asteroid02")),new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation) as GameObject;            
        }
        Destroy(gameObject,0.1f);
    }
}
