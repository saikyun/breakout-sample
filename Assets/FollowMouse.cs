using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform target;

    private SpriteRenderer _renderer;
    private Camera _camera;
    private float _radius;

    public void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _radius = transform.localScale.x * 0.5f;
        _camera = Camera.main;
    }

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
        if (CollisionCheck(transform.position, _radius, target))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public bool CollisionCheck(Vector3 vector, float radius, Transform square)
    {
        Vector3 sqExtent = square.localScale * 0.5f;
        bool top = ((vector.y - radius) < (square.position.y + sqExtent.y));
        bool bottom = ((vector.y + radius) > (square.position.y - sqExtent.y));
        bool left = ((vector.x + radius) > (square.position.x - sqExtent.x));
        bool right = ((vector.x - radius) < (square.position.x + sqExtent.x));

        return (top && bottom && left && right);
    }
}
