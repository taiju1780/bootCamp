using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitpoint : MonoBehaviour
{
    [SerializeField] static int hitpoint = 0;
    [SerializeField] GameObject player;
    float boundWall = 25.0f;
    float boundObs = 40.0f;
    Vector2 pushvec;
    Vector2 effectvec;
    private Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundObs;
                effectvec = ray.normalized * 0.3f;
                move.CollisionObstract(pushvec, effectvec);
            }
            if (col.gameObject.tag == "Chaser")
            {
                hitpoint++;
                move.CollisionChaser();
            }
            if (col.gameObject.tag == "Wall")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundWall;
                effectvec = ray.normalized * 0.3f;
                move.CollisionWall(pushvec, effectvec);
            }
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if(col.gameObject.tag == "Floor")
            {
                move.CollisionFloar();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Chaser")
            {
                move.CollisionChaser();
            }
            if (col.gameObject.tag == "ring")
            {
                move.CollisionRing();
            }
            if (col.gameObject.tag == "bamboo")
            {
                move.CollisionBigBamb();
            }
        }
    }

    public int GetHP()
    {
        return hitpoint;
    }
}
