using UnityEngine;

public class Math
{
    public static Bounds CalcBounds(GameObject go)
    {
        var b = new Bounds(go.transform.position, Vector3.zero);

        foreach (Renderer r in go.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }

        return b;
    }
}