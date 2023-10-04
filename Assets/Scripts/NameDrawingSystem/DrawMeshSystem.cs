using StreetSmiter.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMeshSystem : MonoBehaviour
{

    public static DrawMeshSystem Instance { get; private set; }
    // Start is called before the first frame update
    [SerializeField] private Material drawMeshMaterial;

    private GameObject lastGameObject;
    private int lastSortingOrder;
    private Mesh mesh;
    private Vector3 lastMouseWorldPosition;
    private float lineThickness = 0.25f;
    private Color lineColour = Color.green;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!Utils.IsPointerOverUI())
        {
            // Only run logic if not over UI
            Vector3 mouseWorldPosition = MousePosition3D.GetMouseWorldPosition();
            if (Input.GetMouseButtonDown(0))
            {
                // Mouse Down
                CreateMeshObject();

                //issue probs using the MeshUtils function w/o understanding it
                //if we create a mesh just using our original function

                //mesh = MeshUtils.CreateMesh(mouseWorldPosition, mouseWorldPosition, mouseWorldPosition, mouseWorldPosition);
                mesh = CreateNewMesh();
                mesh.MarkDynamic();
                lastGameObject.GetComponent<MeshFilter>().mesh = mesh;
                Material material = new Material(drawMeshMaterial);
                material.color = lineColour;
                lastGameObject.GetComponent<MeshRenderer>().material = material;
            }

            if (Input.GetMouseButton(0))
            {
                // Mouse Held Down
                float minDistance = .1f;
                if (Vector2.Distance(lastMouseWorldPosition, mouseWorldPosition) > minDistance)
                {
                    // Far enough from last point
                    Vector2 forwardVector = (mouseWorldPosition - lastMouseWorldPosition).normalized;

                    lastMouseWorldPosition = mouseWorldPosition;

                    MeshUtils.AddLinePoint(mesh, mouseWorldPosition, lineThickness);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                // Mouse Up
                MeshUtils.AddLinePoint(mesh, mouseWorldPosition, 0f);
            }
        }
    }

    private void CreateMeshObject()
    {
        lastGameObject = new GameObject("DrawMeshSingle", typeof(MeshFilter), typeof(MeshRenderer));
        lastGameObject.tag = "DrawnLine";
        lastSortingOrder++;
        lastGameObject.GetComponent<MeshRenderer>().sortingOrder = lastSortingOrder;
        //lastGameObject.transform.Rotate(0, 90, 0, Space.World);
    }

    private Mesh CreateNewMesh()
    {
        Mesh newMesh = new Mesh();
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

        newMesh.vertices = vertices;
        newMesh.uv = uv;
        newMesh.triangles = triangles;
        //newMesh.MarkDynamic();

        //GetComponent<MeshFilter>().mesh = newMesh;
        lastMouseWorldPosition = MousePosition3D.GetMouseWorldPosition();
        return newMesh;
    }

    public void SetLineColour(Color colour)
    {
        lineColour = colour;
    }
}
