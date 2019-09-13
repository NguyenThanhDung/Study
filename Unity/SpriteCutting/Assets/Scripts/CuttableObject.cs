using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    const int INFINITY = 10000;

    [SerializeField] LayerMask cuttableLayer;

    private Texture2D texture;
    private List<Vector2> texcoords;
    private List<Vector2> polygon;

    void Start()
    {
        Transform display = this.gameObject.transform.GetChild(0);
        MeshRenderer renderer = display.gameObject.GetComponent<MeshRenderer>();
        this.texture = (Texture2D)renderer.material.mainTexture;
        this.texcoords = new List<Vector2>();
        this.polygon = new List<Vector2>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.texcoords.Clear();
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, this.cuttableLayer))
            {
                this.texcoords.Add(hit.textureCoord);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Validate();
        }
    }

    // Given three colinear points p, q, r, the function checks if 
    // point q lies on line segment 'pr' 
    bool onSegment(Vector2 p, Vector2 q, Vector2 r)
    {
        if (q.x <= Mathf.Max(p.x, r.x) && q.x >= Mathf.Min(p.x, r.x) &&
            q.y <= Mathf.Max(p.y, r.y) && q.y >= Mathf.Min(p.y, r.y))
            return true;

        return false;
    }

    // To find orientation of ordered triplet (p, q, r). 
    // The function returns following values 
    // 0 --> p, q and r are colinear 
    // 1 --> Clockwise 
    // 2 --> Counterclockwise 
    int orientation(Vector2 p, Vector2 q, Vector2 r)
    {
        // See https://www.geeksforgeeks.org/orientation-3-ordered-points/ 
        // for details of below formula. 
        int val = (int)((q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y));

        if (val == 0) return 0; // colinear 

        return (val > 0) ? 1 : 2; // clock or counterclock wise 
    }

    // The main function that returns true if line segment 'p1q1' 
    // and 'p2q2' intersect. 
    bool doIntersect(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
    {
        // Find the four orientations needed for general and 
        // special cases 
        int o1 = orientation(p1, q1, p2);
        int o2 = orientation(p1, q1, q2);
        int o3 = orientation(p2, q2, p1);
        int o4 = orientation(p2, q2, q1);

        // General case 
        if (o1 != o2 && o3 != o4)
            return true;

        // Special Cases 
        // p1, q1 and p2 are colinear and p2 lies on segment p1q1 
        if (o1 == 0 && onSegment(p1, p2, q1)) return true;

        // p1, q1 and q2 are colinear and q2 lies on segment p1q1 
        if (o2 == 0 && onSegment(p1, q2, q1)) return true;

        // p2, q2 and p1 are colinear and p1 lies on segment p2q2 
        if (o3 == 0 && onSegment(p2, p1, q2)) return true;

        // p2, q2 and q1 are colinear and q1 lies on segment p2q2 
        if (o4 == 0 && onSegment(p2, q1, q2)) return true;

        return false; // Doesn't fall in any of the above cases 
    }

    // Returns true if the point p lies inside the polygon[] with n vertices 
    bool isInside(List<Vector2> polygon, Vector2 p)
    {
        // There must be at least 3 vertices in polygon[] 
        if (polygon.Count < 3) return false;

        // Create a point for line segment from p to infinite 
        Vector2 extreme = new Vector2(INFINITY, p.y);

        // Count intersections of the above line with sides of polygon 
        int count = 0, i = 0;
        do
        {
            int next = (i + 1) % polygon.Count;

            // Check if the line segment from 'p' to 'extreme' intersects 
            // with the line segment from 'polygon[i]' to 'polygon[next]' 
            if (doIntersect(polygon[i], polygon[next], p, extreme))
            {
                // If the point 'p' is colinear with line segment 'i-next', 
                // then check if it lies on segment. If it lies, return true, 
                // otherwise false 
                if (orientation(polygon[i], p, polygon[next]) == 0)
                    return onSegment(polygon[i], p, polygon[next]);

                count++;
            }
            i = next;
        }
        while (i != 0);

        // Return true if count is odd, false otherwise 
        return (count & 1) != 0;  // Same as (count%2 == 1) 
    }

    private Texture2D Cut(Texture2D texture, List<Vector2> polygon)
    {
        for (int i = 0; i < texture.height; i++)
        {
            for (int j = 0; j < texture.width; j++)
            {
                if (isInside(polygon, new Vector2(i, j)))
                    texture.SetPixel(i, j, Color.red);
            }
        }
        return texture;
    }

    private List<Vector2> TexcoordToVertex(List<Vector2> texcoords, Texture2D texture)
    {
        List<Vector2> polygon = new List<Vector2>();
        foreach (Vector2 uv in texcoords)
        {
            Vector2 vertex = new Vector2(uv.x * texture.width, uv.y * texture.height);
            polygon.Add(vertex);
        }
        return polygon;
    }

    private void Validate()
    {
        if (this.texcoords.Count < 3)
        {
            Debug.Log("Not enough vertexes");
            return;
        }
        this.polygon = TexcoordToVertex(this.texcoords, this.texture);
        this.texture = Cut(this.texture, this.polygon);
        this.texture.Apply();
    }
}
