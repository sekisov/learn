using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropApple : MonoBehaviour
{
    // Start is called before the first frame update
    public float DropTimeApple = 3;
    public Transform PoinDropApple;
    void Start()
    {
        InvokeRepeating("timer", DropTimeApple, DropTimeApple);
    }

    private void timer()
	{
        GetComponent<Animator>().SetTrigger("GetApple");
        GameObject apple = Instantiate(Resources.Load("Apple"),PoinDropApple.position,Random.rotation) as GameObject;
        apple.GetComponent<Rigidbody>().AddForce(apple.transform.forward * 10);
        Destroy(apple,15.0f);
	}
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
 