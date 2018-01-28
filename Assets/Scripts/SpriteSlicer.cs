using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class SpriteSlicer : MonoBehaviour {
    public const float EPSILON = 0.01f;
    public bool printVerts = false;
	
    //we can get the start and end position from a trigger enter and exit 



    void Update()
    {
        if(printVerts)
        {
            SliceBrain(Vector2.zero, Vector2.zero);
            printVerts = false;
        }

    }
    public void SliceBrain(Vector2 start, Vector2 end)
    {

        Vector2 direction = (start + end).normalized;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;

        //Vector2[] vertices = sprite.vertices;
        var vertices = sprite.vertices;
        var triangle = sprite.triangles;

        foreach (var vert in vertices)
            Debug.Log(vert);
        
        for (int i = 0; i < triangle.Length; i+=3)
        {
            bool found1, found2, found3;


            Vector2 intersection1 = GetIntersectionPointCoordinates( vertices[triangle[i]], vertices[triangle[i + 1]], 
                start, end, out found1);
            Vector2 intersection2 = GetIntersectionPointCoordinates(vertices[triangle[i+1]], vertices[triangle[i + 2]],
                start, end, out found2);
            Vector2 intersection3 = GetIntersectionPointCoordinates(vertices[triangle[i + 2]], vertices[triangle[i]],
                start, end, out found3);

            Debug.Log("i1: " + found1 + "v: " + intersection1);
            Debug.Log("i2: " + found2 + "v: " + intersection2);
            Debug.Log("i3: " + found3 + "v: " + intersection3);
        }


       // mesh.vertices = vertices;
    

        //get start position
        //get end position
        //test vector against intersection with each vertices in the mesh

        //create new mesh collider for the main brain
        //animation for the leftover piece

    }




    public Vector2 GetIntersectionPointCoordinates(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2, out bool found)
    {
        float tmp = (B2.x - B1.x) * (A2.y - A1.y) - (B2.y - B1.y) * (A2.x - A1.x);

        if (System.Math.Abs(tmp) < EPSILON)
        {
            found = false;
            return Vector2.zero;
        }

        float mu = ((A1.x - B1.x) * (A2.y - A1.y) - (A1.y - B1.y) * (A2.x - A1.x)) / tmp;

        found = true;

        return new Vector2(
            B1.x + (B2.x - B1.x) * mu,
            B1.y + (B2.y - B1.y) * mu
        );
    }
}
