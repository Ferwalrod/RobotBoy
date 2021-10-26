using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCharge : MonoBehaviour
{
    [SerializeField]
    public int charges;
    [SerializeField]
    public PowerUpType Type;
    [SerializeField]
    public float timeUntilReactivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Pointer.ShurikenCharges += charges;
            GUIManager.Instance.UpdateShurikenCharges(GameManager.Instance.Pointer.ShurikenCharges);
            if (Type.Equals(PowerUpType.RENEWABLE))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(timeUntilReactivate);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public enum PowerUpType
    {
        RENEWABLE,ONE_USE
    }
}
