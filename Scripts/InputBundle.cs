﻿using UnityEngine;
using System.Collections;

public class InputBundle{

	public readonly Vector2 direction;
	public readonly Vector2 mouseDelta;
	public readonly float scrollWheelDelta;

	public InputBundle(){
		direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
//		mouseDelta = InputBundle.
	}

}