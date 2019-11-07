using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //回転速度
    [SerializeField] private float rotaspeed;
    //移動速度
    [SerializeField] private float speed;
    private float itemspeed = 0;
    //重力
    [SerializeField] private float gravity;
    //入力フラグ
    [SerializeField] private bool rotaright = false;
    [SerializeField] private bool rotaleft = false;
    [SerializeField] private bool rotaup = false;
    [SerializeField] private bool rotadown = false;
    //スティックの入力感度
    [SerializeField] private float sticRange = 0.2f;
    //回転限界
    private float rotalimit = 2.0f;
    private float rotanum = 7.0f;
    private float gravityrate = 0.98f;
    private float boundrate = 0.85f;
    private Vector2 bound;

    //死亡時用の変数
    //死亡フラグ
    [SerializeField] bool dieflag = false;
    private Vector3 keeppos;
    private float wait = 0.0f;

    //無敵状態
    [SerializeField] private bool invincible = false;
    private float invincibletime = 300;

    //リジッドボディ
    private Rigidbody rb;

    //シーン
    SceneChange scene;

    //エフェクト
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject hitEffectpos;
    [SerializeField] private GameObject rotaEffect;
    [SerializeField] private GameObject powerEffect;
    [SerializeField] private GameObject invincibleeffect;
    private effect _effect;
    private effectpos _effectpos;

    [SerializeField] GameObject ringparticle;

    //ステートパターン
    public enum State
    {
        normal,
        die,
    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _effect = hitEffect.GetComponent<effect>();
        _effectpos = hitEffectpos.GetComponent<effectpos>();
        rotaspeed = 0;
        speed = 4;
        gravity = 3;
        dieflag = false;
        bound = new Vector3();
        state = State.normal;
        scene = new SceneChange();

        Sound.LoadSE("Hit", "kick-low1");
    }

    // Update is called once per frame
    void Update()
    {
        float rotaHorizontal = Input.GetAxis("Horizontal2");
        float rotaVertical = Input.GetAxis("Vertical2");
        float viasHorizontal = Input.GetAxis("Horizontal");

        //ノーマルのステート
        if(state == State.normal)
        {
            //スティック判定
            if (rotaHorizontal >= sticRange)
            {
                rotaright = true;
            }

            if (rotaHorizontal <= -sticRange)
            {
                rotaleft = true;
            }

            if (rotaVertical >= sticRange)
            {
                rotadown = true;
            }

            if (rotaVertical <= -sticRange)
            {
                rotaup = true;
            }

            RotaCheck();

            //回転
            transform.Rotate(new Vector3(0, rotaspeed * rotanum, 0));

            if(rotaspeed > 5)
            {
                rotaEffect.SetActive(true);
            }
            else
            {
                rotaEffect.SetActive(false);
            }

            //移動
            if (rotaspeed <= rotalimit)
            {
                rb.velocity = new Vector3(speed + viasHorizontal + itemspeed, rotaspeed - gravity * rotalimit, 0) + new Vector3(bound.x, 0, 0);
            }
            else
            {
                rb.velocity = new Vector3(speed + viasHorizontal + itemspeed, rotaspeed - gravity, 0) + new Vector3(bound.x, 0, 0);
            }

            //回転数の自然現象
            rotaspeed *= gravityrate;

            //反動がなくなったら
            if (bound.x <= 1.0f && bound.x >= -1.0f && bound.y <= 1.0f && bound.y >= -1.0f)
            {
                speed = 4;
                bound = new Vector3();
            }
        }
        
        //死亡時のステート
        if(state == State.die)
        {
            //死亡演出
            speed = 0;
            rb.velocity = new Vector3(0, 0, 0);
            transform.Rotate(new Vector3(0, 0, 0));

            wait++;
            if(wait >= 60)
            {
                //scene.ChangeScene("ResultScene");
            }
        }

        if (invincible)
        {
            invincibletime--;
            powerEffect.SetActive(true);
            invincibleeffect.SetActive(true);
            if (invincibletime <= 0)
            {
                powerEffect.SetActive(false);
                invincibleeffect.SetActive(false);
                invincibletime = 300;
                invincible = false;
            }
        }

        //反発数の減少
        bound *= boundrate;
        //加速度の減少
        itemspeed *= gravityrate;
    }

    //フラグすべて立っていたら回転速度を上げる
    private void RotaCheck() { 
        if(rotaright && rotaleft && rotaup && rotadown)
        {
            rotaspeed += rotalimit;
            rotaright = false;
            rotaleft = false;
            rotaup = false;
            rotadown = false;
        }
    }

    //////////////////////////////////////////////////////////////////////
    /////当たり判定
    //////////////////////////////////////////////////////////////////////
    
    public void CollisionChaser()
    {
        state = State.die;
        dieflag = true;
    }

    public void CollisionObstract(Vector2 push, Vector2 effect)
    {
        if (invincible)
        {

        }
        else
        {
            speed = 0;
            bound = push;
            _effectpos.HiteffectPos(effect);
            _effect.HitEffect();
            itemspeed = 0;
            Sound.PlaySE("Hit");
        }
    }

    public void CollisionWall(Vector2 push, Vector2 effect)
    {
        speed = 0;
        bound = push;
        _effectpos.HiteffectPos(effect);
        _effect.HitEffect();
        Sound.PlaySE("Hit");
        itemspeed = 0;
    }

    public void CollisionRing()
    {
        itemspeed = 20;
        Instantiate(ringparticle, transform.position, transform.rotation);
    }
    
    public void CollisionBigBamb()
    {
        invincible = true;
    }

    public void CollisionFloar()
    {
        speed = 0;
    }

    ///////////////////////////////////////////////////////////////////////
   
    public bool GetDieFlag()
    {
        return dieflag;
    }
}
