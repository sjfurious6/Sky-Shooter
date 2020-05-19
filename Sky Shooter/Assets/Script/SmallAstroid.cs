using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAstroid :MonoBehaviour
{
    public Transform startPoint { get; set; }
    public Transform endPoint { get; set; }

    [SerializeField]
    GameObject explosion;

    
    float speed = 0.1f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(2,2,2));
        startPoint = GameManager.Instance.GetStartPosition();
        endPoint = GameManager.Instance.GetEndPosition();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(this.startPoint.position, this.endPoint.position, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(GameSetting.PlayerBulletTag))
        {
            GameSetting.currentScore += 20;           

            Destroy(gameObject);
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }       
    }    
}
