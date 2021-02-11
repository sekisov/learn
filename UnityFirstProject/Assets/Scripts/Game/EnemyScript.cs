using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private PlayerHelper _player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        _player = GameObject.FindObjectOfType<PlayerHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
