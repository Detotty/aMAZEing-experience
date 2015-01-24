using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingScript : MonoBehaviour
{
	// Mouse UI
	public bool isMouseEnabled = true;
	private bool isMousePressed;

	// UI elements
	enum DrawingShape
	{
		NONE,
		LINE,
		SQUARE
	};
	public float lineWidth = 0.025f;
	public Color lineColor = Color.green;
	DrawingShape drawingShape; // Current drawing shape
	GameObject drawingObject; // Current drawing object

	// For some misterious reason, whenever a line object is created, it is immediately moved to
	// z = -54.76953. Since we want the lines to be in front of everything, at z = -5 (arbitrary value),
	// every instanciated line should have this z value.
	static private float LINE_OFFSET_Z_AXIS = 49.76953f;

	// The z-axis coordinate of the line object with respect to it's parent. Make it a negative number
	// in order to have it in front of the parent.
	static private float LINE_POSITION_Z_AXIS = -5;

	// Singleton pattern
	void Awake()
	{
		isMousePressed = false;
		// drawingShape = DrawingShape.NONE;
		drawingShape = DrawingShape.LINE;
	}

	// Create a new line
	GameObject InstantiateLine()
	{
		GameObject lineGameObject = new GameObject("Line");
		lineGameObject.transform.position = new Vector3(0, 0, LINE_POSITION_Z_AXIS);
		lineGameObject.transform.parent = gameObject.transform;

		LineRenderer lineRenderer = lineGameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Custom/LineShader"));
		lineRenderer.material.color = lineColor;
		lineRenderer.SetVertexCount(0);
		lineRenderer.SetWidth(lineWidth, lineWidth);
		lineRenderer.SetColors(lineColor, lineColor);
		lineRenderer.useWorldSpace = false;

		return lineGameObject;
	}

	// Add a new line object and return it's reference
	GameObject AddLine(Vector3 begin, Vector3 end)
	{
		GameObject lineGameObject = InstantiateLine();
		LineRenderer lineRenderer = lineGameObject.GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(2);
		lineRenderer.SetPosition(0, begin);
		lineRenderer.SetPosition(1, end);
		return lineGameObject;
	}

	// Move the line end point to another place
	void SetLineEnd(GameObject line, Vector3 end)
	{
		LineRenderer lineRenderer = line.GetComponent<LineRenderer>();

		// Check whether the line is bounded by the collider
		Vector3 extents = gameObject.collider2D.bounds.extents;
		Vector3 center = gameObject.collider2D.bounds.center;

		if (end.x < (center.x - extents.x))
			end.x = center.x - extents.x;
		else if (end.x > (center.x + extents.x))
			end.x = center.x + extents.x;

		if (end.y < (center.y - extents.y))
			end.y = center.y - extents.y;
		else if (end.y > (center.y + extents.y))
			end.y = center.y + extents.y;

		// Update line end point
		lineRenderer.SetPosition(1, end);
	}

	// Initialize line drawing
	void OnMouseDown()
	{
		if (isMouseEnabled)
		{
			Debug.Log("Mouse button pressed");
			isMousePressed = true;
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = LINE_OFFSET_Z_AXIS;

			if (drawingShape == DrawingShape.LINE)
				drawingObject = AddLine(mousePosition, mousePosition);
		}
	}

	// Finalize line drawing
	void OnMouseUp()
	{
		if (isMouseEnabled)
		{
			Debug.Log("Mouse button released");
			isMousePressed = false;
			// drawingShape = DrawingShape.NONE;
		}
	}

	void Update()
	{
		if (isMouseEnabled && isMousePressed)
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = LINE_OFFSET_Z_AXIS;

			if (drawingShape == DrawingShape.LINE)
				SetLineEnd(drawingObject, mousePosition);
		}
	}
}
