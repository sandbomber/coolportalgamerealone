using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public GameObject player;
    public float knockback;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Vector3 dir = hit.transform.position - transform.position;
                hit.gameObject.GetComponent<Rigidbody>().AddForce(dir * 10, ForceMode.Impulse);
            //hit.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y, player.transform.position.z - this.transform.position.z) * knockback, ForceMode.Impulse);
        }
    }
}
