using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agemaki_Distance : MonoBehaviour
{

    private float tmpTime = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;
        var colliderTest = GetComponent<Collider2D>();

        if (tmpTime >= 0.8 && 1.4 >= tmpTime)
        {
            colliderTest.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        else
        {
            colliderTest.enabled = false;
        }

        if (tmpTime >= 1.5)
        {
            tmpTime = 0;
            Destroy(this.gameObject);
        }
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObjectDisplayController salt;
            GameObject obj = GameObject.Find("Salt");
            salt = obj.GetComponent<GameObjectDisplayController>();
            salt.Salt -= 1f;
            Destroy(this.gameObject);
        }

    }
}
