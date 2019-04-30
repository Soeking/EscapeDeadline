using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    private bool canChange = true;
    private bool UpDown = false;
    private bool Jumping = false;
    private const float moveSpeed = 3f;
    private float deltaTimes = 0f;
    private float stamina = 10f;

    public static int layer = 8;
    public static float playerMove;

    public Sprite Right;
    public Sprite Left;
    public Sprite Normal;
    public Sprite Jump;
    private ChangeSprite _changeSprite;
    public GameObject change;
    public Slider staminaSlider;

    public static bool Attacking = false;
    private float AttackTime = 0.0f;

    Quaternion quaternion;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider.value = stamina;
        this.quaternion = gameObject.transform.rotation;
        _changeSprite = change.GetComponent<ChangeSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.isBlackOut)
        {
            this.Moving();
            this.Attack();
            useItem();
        }

        if (!Jumping)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 3.5f), ForceMode2D.Impulse);
                Jumping = true;
            }
        }

        layer = gameObject.layer;
    }

    void Moving()
    {
        gameObject.transform.rotation = this.quaternion;
        //if (!Jumping) transform.position = new Vector3(transform.position.x, GlobalData.yPosition[-layer + 12], 0.0f);
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        this.deltaTimes += Time.deltaTime;


        if (this.deltaTimes >= 1.0) this.deltaTimes -= 1.0f;

        if (this.deltaTimes >= 0.75)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Right;
        }
        else if (this.deltaTimes >= 0.5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
        }
        else if (this.deltaTimes >= 0.25)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Left;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
        }

        if (!UpDown)
        {
            if (Input.GetKey(KeyCode.W) && layer < 12)
            {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 7.5f), ForceMode2D.Impulse);
                BackGroundFloor.finishDash();
                Jumping = true;
                pos.y = GlobalData.yPosition[-layer + 11] + 0.5f;
                myTransform.position = pos;//*/
                gameObject.layer += 1;
                UpDown = true;
            }
            if (Input.GetKey(KeyCode.S) && layer > 8)
            {
                /*pos.y -= 1f;
                pos.y = (int)pos.y;
                myTransform.position = pos;//*/
                BackGroundFloor.finishDash();
                gameObject.layer -= 1;
                Jumping = true;
                UpDown = true;
            }
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            UpDown = false;
        }

        if (Input.GetKey(KeyCode.A) && pos.x > -8)
        {
            pos.x -= moveSpeed * Time.deltaTime;
            myTransform.position = pos;
        }
        if (Input.GetKey(KeyCode.D) && pos.x < 8)
        {
            pos.x += moveSpeed * Time.deltaTime;
            myTransform.position = pos;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor" && collision.gameObject.layer == gameObject.layer)
        {
            this.Jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "red" && collision.gameObject.layer == gameObject.layer)
        {
            Destroy(collision.gameObject);
            this.stamina += 3.0f;
            if (this.stamina > 20.0f) this.stamina = 20.0f;
            staminaSlider.value = stamina;
        }
        if (collision.gameObject.tag == "monster" && collision.gameObject.layer == gameObject.layer)
        {
            Destroy(collision.gameObject);
            this.canChange = true;
        }//*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "red" && collision.gameObject.layer == gameObject.layer)
        {
            Destroy(collision.gameObject);
            this.stamina += 3.0f;
            if (this.stamina > 20.0f) this.stamina = 20.0f;
            staminaSlider.value = stamina;
        }
        if(collision.gameObject.tag == "monster" && collision.gameObject.layer == gameObject.layer)
        {
            Destroy(collision.gameObject);
            this.canChange = true;
        }
    }

    void useItem()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canChange)
            {
                _changeSprite.changeSprites();
                this.canChange = false;
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (stamina>0)
            {
                stamina -= Time.deltaTime * 2;
                BackGroundFloor.isDash();
                staminaSlider.value = stamina;
            }
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            BackGroundFloor.finishDash();
        }
    }

    void Attack()
    {
        if(!Attacking)
        {
            if(Input.GetKey(KeyCode.J))
            {
                Attacking = true;
                AttackTime = 0.0f;
            }
        }
        else
        {
            AttackTime += Time.deltaTime;
            if(AttackTime >= 0.75f)
            {
                Attacking = false;
            }
        }
    }
}
