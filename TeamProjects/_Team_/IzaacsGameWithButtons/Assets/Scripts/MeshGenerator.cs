using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshGenerator : MonoBehaviour {

    public GameObject obj;



    public FaceGrid faceGrid;
    List<Vector3> verts;
    List<int> tris;

    public void GenerateMesh(int[,] map, float squareSize) {
        faceGrid = new FaceGrid(map, squareSize);

        verts = new List<Vector3>();
        tris = new List<int>();

        for (int x = 0; x < faceGrid.faces.GetLength(0); x++) {
            for (int y = 0; y < faceGrid.faces.GetLength(1); y++) {
                triangulateFace(faceGrid.faces[x, y]);
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verts.ToArray();
        mesh.triangles = tris.ToArray();
        //mesh.RecalculateNormals();
        obj.GetComponent<MeshFilter>().mesh = mesh;
    }

    void triangulateFace(Face face) {
        switch (face.config) 
        {
            case 0:
                break;
            
            //1 point
            case 1:
                MeshFromPoints(face.centerBottom, face.bottomLeft, face.centerLeft);
                break;
            case 2:
                MeshFromPoints(face.centerRight, face.bottomRight, face.centerBottom);
                break;
            case 4:
                MeshFromPoints(face.centerTop, face.topRight, face.centerRight);
                break;
            case 8:
                MeshFromPoints(face.topLeft, face.centerTop, face.centerLeft);
                break;

            //2 point
            case 3:
                MeshFromPoints(face.centerRight, face.bottomRight, face.bottomLeft, face.centerLeft);
                break;

            case 6:
                MeshFromPoints(face.centerTop, face.topRight, face.bottomRight, face.centerBottom);
                break;

            case 12:
                MeshFromPoints(face.topLeft, face.topRight, face.centerRight, face.centerLeft);
                break;

            case 5:
                MeshFromPoints(face.centerTop, face.topRight, face.centerRight, face.centerBottom, face.bottomLeft, face.centerLeft);
                break;
            
            case 10:
                MeshFromPoints(face.topLeft, face.centerTop, face.centerRight, face.bottomRight, face.centerBottom, face.centerLeft);
                break;

            //3 point cases
            case 7:
                MeshFromPoints(face.centerTop, face.topRight, face.bottomRight, face.bottomLeft, face.centerLeft);
                break;

            case 11:
                MeshFromPoints(face.topLeft, face.centerTop, face.centerRight, face.bottomRight, face.bottomLeft);
                break;

            case 13:
                MeshFromPoints(face.topLeft, face.topRight, face.centerRight, face.centerBottom, face.bottomLeft);
                break;

            case 14:
                MeshFromPoints(face.topLeft, face.topRight, face.bottomRight, face.centerBottom, face.centerLeft);
                break;

            //4 point
            case 15:
                MeshFromPoints(face.topLeft, face.topRight, face.bottomRight, face.bottomLeft);
                break;

        }
    }

    void MeshFromPoints(params Node[] points) 
    {
        AssignVerts(points);
        if (points.Length >= 3) 
            CreateTris(points[0], points[1], points[2]);
        if (points.Length >= 4)
            CreateTris(points[0], points[2], points[3]);
        if (points.Length >= 5)
            CreateTris(points[0], points[3], points[4]);
        if (points.Length >= 6)
            CreateTris(points[0], points[4], points[5]);
            
        
    }
    void AssignVerts(Node[] points) 
    {
        for (int i = 0; i < points.Length; i++) {
            if (points[i].vertIndex == -1) {
                points[i].vertIndex = verts.Count;
                verts.Add(points[i].position);
            }
        }
    }

    void CreateTris(Node a, Node b, Node c) 
    {
        tris.Add(a.vertIndex);
        tris.Add(b.vertIndex);
        tris.Add(c.vertIndex);

    }

    public class FaceGrid 
    {
        public Face[,] faces;

        public FaceGrid(int[,] map, float squareSize) 
        {
            int nodeCountX = map.GetLength(0);
            int nodeCountY = map.GetLength(1);

            //float mapWidth = nodeCountX * squareSize;
            //float mapHeight = nodeCountY * squareSize;

            ControleNode[,] controlNodes = new ControleNode[nodeCountX, nodeCountY];

            for(int x=0; x < nodeCountX; x++){
                for(int y=0; y < nodeCountY; y++){
                    Vector3 pos = new Vector3(x * squareSize + squareSize/2, 0, y * squareSize + squareSize/2);
                    controlNodes[x, y] = new ControleNode(pos, map[x, y] == 1, squareSize);

                }
            }

            faces = new Face[nodeCountX - 1, nodeCountY - 1];
            for (int x = 0; x < nodeCountX-1; x++)
            {
                for (int y = 0; y < nodeCountY-1; y++)
                {
                    faces[x, y] = new Face(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
                }
            }

        }
    }

    public class Face 
    {
        public ControleNode topLeft, topRight, bottomRight, bottomLeft;
        public Node centerTop, centerRight, centerBottom, centerLeft;
        public int config;


        public Face(ControleNode _topLeft, ControleNode _topRight, ControleNode _bottomRight, ControleNode _bottomLeft)
        {
            topLeft = _topLeft; 
            topRight = _topRight; 
            bottomRight = _bottomRight; 
            bottomLeft = _bottomLeft;

            centerTop = topLeft.right; 
            centerRight = bottomRight.above;
            centerBottom = bottomLeft.right; 
            centerLeft = bottomLeft.above;

            if (topLeft.active)
                config += 8;
            if (topRight.active)
                config += 4;
            if (bottomRight.active)
                config += 2;
            if (bottomLeft.active)
                config += 1;


        }
    }

    public class Node 
    {
        public Vector3 position;
        public int vertIndex = -1;

        public Node(Vector3 _pos) {
            position = _pos;
        }
    }

    public class ControleNode : Node
    {
        public bool active;
        public Node above, right;

        public ControleNode(Vector3 _pos, bool _active, float squareSize) : base(_pos) {
            active = _active;
            above = new Node(position + Vector3.forward * squareSize / 2f);
            right = new Node(position + Vector3.right * squareSize / 2f);
        }
    }

}
