using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProceduralMesh : MonoBehaviour {

    public Vector2 offs;
    public FaceGrid faceGrid;
    List<Vector3> verts;
    List<int> tris;

    public void GenerateMesh(float[,] map, float squareSize) {
        faceGrid = new FaceGrid(map, squareSize);
        verts = new List<Vector3>();
        tris = new List<int>();

        for (int x = 0; x < faceGrid.faces.GetLength(0); x++) {
            for (int y = 0; y < faceGrid.faces.GetLength(1); y++) {
                AssignVerts(faceGrid.faces[x, y].topLeft, faceGrid.faces[x, y].topRight, faceGrid.faces[x, y].bottomRight, faceGrid.faces[x, y].bottomLeft);
            }
        }
        CreateTris(faceGrid);

        Mesh mesh = new Mesh();
        mesh.vertices = verts.ToArray();
        mesh.triangles = tris.ToArray();
        mesh.RecalculateNormals();
        mesh.Optimize();

        GetComponent<MeshFilter>().mesh = mesh;
    }

    void AssignVerts(params Node[] points) {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].vertIndex == -1) 
            {
                points[i].vertIndex = verts.Count;
                points[i].position.x += offs.x;
                points[i].position.y += offs.y;
                verts.Add(points[i].position);
            }
        }
    }

    void CreateTris(FaceGrid faceGrid) {
        foreach (Face f in faceGrid.faces){
            tris.Add(f.topLeft.vertIndex); tris.Add(f.topRight.vertIndex); tris.Add(f.bottomLeft.vertIndex);
            tris.Add(f.bottomRight.vertIndex); tris.Add(f.bottomLeft.vertIndex); tris.Add(f.topRight.vertIndex);
        }
    }

    public class FaceGrid {
        public Face[,] faces;

        public FaceGrid(float[,] map, float squareSize) {
            int nodeCountX = map.GetLength(0);
            int nodeCountY = map.GetLength(1);

            Node[,] nodes = new Node[nodeCountX, nodeCountY];

            for (int x = 0; x < nodeCountX; x++){
                for (int y = 0; y < nodeCountY; y++){
                    Vector3 pos = new Vector3(x * squareSize , map[x,y], y * squareSize);
                    nodes[x, y] = new Node(pos);
                }
            }

            faces = new Face[nodeCountX - 1, nodeCountY - 1];
            for (int x = 0; x < nodeCountX-1; x++){
                for (int y = 0; y < nodeCountY-1; y++){
                    faces[x, y] = new Face(nodes[x, y + 1], nodes[x + 1, y + 1], nodes[x + 1, y], nodes[x, y]);
                }
            }
        }
    }

    public class Face {
        public Node topLeft, topRight, bottomRight, bottomLeft;

        //public int[] tris = new int[4];

        public Face(Node tL,Node tR,Node bR,Node bL){
            topLeft = tL;
            topRight = tR;
            bottomRight = bR;
            bottomLeft = bL;

            /*
            tris[0] = topLeft.vertIndex; tris[1] = topRight.vertIndex; tris[2] = bottomLeft.vertIndex;
            tris[3] = topRight.vertIndex; tris[4] = bottomRight.vertIndex; tris[5] = bottomLeft.vertIndex;
             */
        }
    }

    public class Node {
        public Vector3 position;
        public int vertIndex = -1;

        public Node(Vector3 pos) {
            position = pos;
        }
    }
}
