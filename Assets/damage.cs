using UnityEngine;

public class damage : MonoBehaviour
{
    public int health = 3;
	public GameObject loot;
    public Transform dropLocation;
    public new Animator animation;
    public enemyAI movement;


    void OnCollisionEnter2D(Collision2D info)
    {
        animation = GetComponent<Animator>();

        if (info.gameObject.tag == "arrow")
        {
            health--;
            if (health == 0)
            {
                animation.SetTrigger("damage");
                movement.enabled = false;
                Destroy(gameObject, 1);
                Instantiate(loot, dropLocation.position, dropLocation.rotation);
            }
        }
    }
}
