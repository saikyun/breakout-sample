using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject target;

    bool CircleCircle(GameObject o1, GameObject o2)
    {
        var dist = Vector3.Distance(o1.transform.position, o2.transform.position);
        var radius = 0.5f;
        return dist <= 2 * radius;
    }

    // Update is called once per frame
    void Update()
    {
        var mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mp.x, mp.y, 0);
        if (CircleCircle(gameObject, target))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
