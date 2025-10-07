using UnityEngine;

public class Monster : MonoBehaviour
{

    public float speed;
    public Rigidbody2D target;

    bool isLive;
    Rigidbody2D rigid;
    SpriteRenderer spriter;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dirVec = (target.position - rigid.position).normalized;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
    }
}
