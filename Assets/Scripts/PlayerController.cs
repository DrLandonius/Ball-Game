using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {
	
	public float speed;
	public int startSize;
	public float player;

	private int count;
	private Vector3 targetScale;
	
	void Start  ()
	{
		startSize = 1;
		count = startSize;

	}

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<PlayerCamera>().MyInitializeMethod(this);
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    void FixedUpdate()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed);
    }
	
		void OnTriggerEnter(Collider other)
		{
		
			if (other.gameObject.CompareTag("Pickup"))
			{
			
				other.gameObject.SetActive(false);
				count = count+1;
				transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}

			
		}
		void OnCollisionEnter (Collision collision)
		{
			if(collision.gameObject.tag == "Player")
			{
				if (count >=+ 6)
				{	
					Destroy(collision.gameObject);
				}
			}
		}


	
}


