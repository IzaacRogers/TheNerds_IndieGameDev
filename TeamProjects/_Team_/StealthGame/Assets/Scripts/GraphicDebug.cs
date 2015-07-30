using UnityEngine;
using System.Collections;

public class GraphicDebug {

    public void drawPoint(Vector3 position) 
    {
        GameObject point = GameObject.CreatePrimitive(PrimitiveType.Cube);
        point.transform.position = position;
        point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        point.AddComponent<PointInfo>();
        
    }

    public void drawDirection(Vector3 from, Vector3 to) 
    {
        float distance = Vector3.Distance(from, to);
        int division = 5;

        for (int i = 0; i < division; i++) 
        {
            Vector3 Position = new Vector3();
            Position.x = ((i+1) * ((from.x - to.x) / division)) + from.x;
            Position.y = ((i+1) * ((from.y - to.z) / division)) + from.x;
            Position.z = ((i+1) * ((from.y - to.z) / division)) + from.x;

            Position.x = Position.x * -1;
            Position.y = Position.y * -1;
            Position.z = Position.z * -1;

            drawPoint(Position);
        }
    }
}
