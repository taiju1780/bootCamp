using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitpoint : MonoBehaviour
{
    [SerializeField] static int hitpoint = 3;
    [SerializeField] GameObject player;
    float boundnum = 25.0f;
    Vector2 pushvec;
    private Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
       if(hitpoint == 0)
        {
            //SceneManager.LoadScene("ResultScene");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                hitpoint--;
                move.CollisionObstract();
            }
            if (col.gameObject.tag == "Wall")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundnum;
                move.CollisionWall(pushvec);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                hitpoint--;
                move.CollisionObstract();
            }
            if (col.gameObject.tag == "Wall")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundnum;
                move.CollisionWall(pushvec);
            }
        }
    }

    public int GetHP()
    {
        return hitpoint;
    }
}
