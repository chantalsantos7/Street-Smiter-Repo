using StreetSmiter.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField] private Material lineMaterial;
    private Vector3 lastMousePosition;
    [SerializeField] float lineThickness = 0.2f;

    private void OnEnable()
    {
        CreateNewMesh();
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            UpdateMesh();
        }
    }

    private void CreateNewMesh()
    {
        mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = MousePosition3D.GetMouseWorldPosition();
        vertices[1] = MousePosition3D.GetMouseWorldPosition();
        vertices[2] = MousePosition3D.GetMouseWorldPosition();
        vertices[3] = MousePosition3D.GetMouseWorldPosition();

        uv[0] = Vector2.zero;
        uv[1] = Vector2.zero;
        uv[2] = Vector2.zero;
        uv[3] = Vector2.zero;

        triangles[0] = 1;
        triangles[1] = 3;
        triangles[2] = 0;

        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.MarkDynamic();

        GetComponent<MeshFilter>().mesh = mesh;
        lastMousePosition = MousePosition3D.GetMouseWorldPosition();
    }

    private void UpdateMesh()
    {
        //when a new line is being drawn, the previous line updates matching the new movements
        Debug.Log("Updating mesh");
        float minDistance = 0.1f;
        if (Vector3.Distance(MousePosition3D.GetMouseWorldPosition(), lastMousePosition) > minDistance)
        {
            Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
            Vector2[] uv = new Vector2[mesh.uv.Length + 2];
            int[] triangles = new int[mesh.triangles.Length + 6];

            mesh.vertices.CopyTo(vertices, 0);
            mesh.uv.CopyTo(uv, 0);
            mesh.triangles.CopyTo(triangles, 0);

            int vIndex = vertices.Length - 4;
            int vIndex0 = vIndex + 0;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;

            Vector3 mouseForwardVector = (MousePosition3D.GetMouseWorldPosition() - lastMousePosition).normalized;
            Vector3 normal3D = new Vector3(-1f, 0, 0);
            Vector3 newVertexUp = MousePosition3D.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal3D) * lineThickness;
            Vector3 newVertexDown = MousePosition3D.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal3D * -1f) * lineThickness;


            vertices[vIndex2] = newVertexUp;
            vertices[vIndex3] = newVertexDown;
            uv[vIndex2] = Vector2.zero;
            uv[vIndex3] = Vector2.zero;

            int tIndex = triangles.Length - 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex2;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex2;
            triangles[tIndex + 5] = vIndex3;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            lastMousePosition = MousePosition3D.GetMouseWorldPosition();
        }
    }
}
