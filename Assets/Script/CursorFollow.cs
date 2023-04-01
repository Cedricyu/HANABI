using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow: MonoBehaviour
{

	private void Start()
	{
		//Cursor.visible = true;
	}

	void Update()
    {
        transform.position = Input.mousePosition;
    }
}
