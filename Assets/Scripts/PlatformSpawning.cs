using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawning : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject gem;
    [SerializeField] private BallController _ballController;

    private Vector3 location;
    void Start()
    {
        location = transform.position;
        
        for (int i = 0; i < 20; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                location += new Vector3(2, 0, 0);
            }
            else
            {
                location += new Vector3(0, 0, 2);
            }

            if (Random.Range(0, 5) == 1)
            {
                Instantiate(gem, location + new Vector3(0, 1, 0), Quaternion.identity);
            }
            
            Instantiate(platform, location, Quaternion.identity);
        }

        StartCoroutine(NextSpawn());
    }

    IEnumerator NextSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        if (Random.Range(0, 2) == 0)
        {
            location += new Vector3(2, 0, 0);
        }
        else
        {
            location += new Vector3(0, 0, 2);
        }
        
        if (Random.Range(0, 5) == 1)
        {
            Instantiate(gem, location + new Vector3(0, 1, 0), Quaternion.identity);
        }

        Instantiate(platform, location, Quaternion.identity);
        if (_ballController.onGround == true)
        {
            StartCoroutine(NextSpawn());
        }
    }
}
