using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Camera MainCamera;

    public GameObject Player;

    public Rigidbody2D Shuriken;

    public int ShurikenCharges;

    public float HookDistance;
    public float HookImpulse;

    void Start()
    {
        ShurikenCharges = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 180f * Time.deltaTime);
        Vector3 MousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0f;
        Vector3 Pos = Player.GetComponent<Transform>().position;
        Pos.y = 0f;
        gameObject.transform.position = MousePos + Pos;
        if (Input.GetKeyDown(KeyCode.Mouse0) && ShurikenCharges!=0){

            ThrowShuriken();

        }
        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    UseHook();
        //}
    }



    void UseHook()
    {
        Vector3 HookVector= (this.gameObject.transform.position - Player.transform.position).normalized;
        Debug.LogError("ImpulseVector=>" + HookVector.ToString());
        Vector2 HookVector2D = new Vector2(HookVector.x, HookVector.y);
        Debug.LogError("ImpulseVector2D=>" + HookVector2D.ToString());
        Player.GetComponent<Rigidbody2D>().AddForce(HookVector2D*HookImpulse,ForceMode2D.Impulse);
        Debug.LogError("FinalImpulse=>" + HookVector2D * HookImpulse);
    }
    void ThrowShuriken()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            audio.Play();
        }
        else
        {
            Debug.LogError("Sound not found");
        }
        Rigidbody2D ShurikenThrow = Instantiate(Shuriken, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
        Vector3 bug = this.gameObject.transform.position - Player.transform.position;
        bug.z = 0f;
        ShurikenThrow.velocity = (bug).normalized * 40f;
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), ShurikenThrow.GetComponent<Collider2D>());
        GUIManager.Instance.UpdateShurikenCharges(--ShurikenCharges);
    }
}
