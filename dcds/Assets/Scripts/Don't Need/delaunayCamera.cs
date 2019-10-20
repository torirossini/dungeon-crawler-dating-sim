using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HullDelaunayVoronoi.Delaunay;
using HullDelaunayVoronoi.Primitives;

public class delaunayCamera : MonoBehaviour
{
    [SerializeField]
    private DungeonLayoutManager dungeonLayout;
    private Material lineMaterial;
    private DelaunayTriangulation2 delaunay;

    // Start is called before the first frame update
    void Start()
    {
        lineMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        delaunay = dungeonLayout.Delaunay;
    }

    // Update is called once per frame
    void Update()
    {
        if(delaunay != null)
        {
        }
    }


    private void OnPostRender()
    {
        if (delaunay == null || delaunay.Cells.Count == 0 || delaunay.Vertices.Count == 0) return;

        GL.PushMatrix();

        GL.LoadIdentity();
        GL.MultMatrix(GetComponent<Camera>().worldToCameraMatrix);
        GL.LoadProjectionMatrix(GetComponent<Camera>().projectionMatrix);

        lineMaterial.SetPass(0);
        GL.Begin(GL.LINES);

        GL.Color(Color.red);

        foreach (DelaunayCell<Vertex2> cell in delaunay.Cells)
        {
            DrawSimplex(cell.Simplex);
        }

        //GL.Color(Color.green);

        //foreach (DelaunayCell<Vertex2> cell in delaunay.Cells)
        //{
        //    DrawCircle(cell.CircumCenter, cell.Radius, 32);
        //}

        GL.End();
        GL.Begin(GL.QUADS);
        GL.Color(Color.yellow);

        foreach (Vertex2 v in delaunay.Vertices)
        {
            DrawPoint(v);
        }

        GL.End();

        GL.PopMatrix();
    }

    private void DrawSimplex(Simplex<Vertex2> f)
    {

        GL.Vertex3(f.Vertices[0].X, f.Vertices[0].Y, 0.0f);
        GL.Vertex3(f.Vertices[1].X, f.Vertices[1].Y, 0.0f);

        GL.Vertex3(f.Vertices[0].X, f.Vertices[0].Y, 0.0f);
        GL.Vertex3(f.Vertices[2].X, f.Vertices[2].Y, 0.0f);

        GL.Vertex3(f.Vertices[1].X, f.Vertices[1].Y, 0.0f);
        GL.Vertex3(f.Vertices[2].X, f.Vertices[2].Y, 0.0f);

    }

    private void DrawPoint(Vertex2 v)
    {
        float x = v.X;
        float y = v.Y;
        float s = 0.05f;

        GL.Vertex3(x + s, y + s, 0.0f);
        GL.Vertex3(x + s, y - s, 0.0f);
        GL.Vertex3(x - s, y - s, 0.0f);
        GL.Vertex3(x - s, y + s, 0.0f);
    }

    private void DrawCircle(Vertex2 v, float radius, int segments)
    {
        float ds = Mathf.PI * 2.0f / (float)segments;

        for (float i = -Mathf.PI; i < Mathf.PI; i += ds)
        {
            float dx0 = Mathf.Cos(i);
            float dy0 = Mathf.Sin(i);

            float x0 = v.X + dx0 * radius;
            float y0 = v.Y + dy0 * radius;

            float dx1 = Mathf.Cos(i + ds);
            float dy1 = Mathf.Sin(i + ds);

            float x1 = v.X + dx1 * radius;
            float y1 = v.Y + dy1 * radius;

            GL.Vertex3(x0, y0, 0.0f);
            GL.Vertex3(x1, y1, 0.0f);
        }

    }
}
