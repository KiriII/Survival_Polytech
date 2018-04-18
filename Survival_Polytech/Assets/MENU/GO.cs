using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour {

    private void OnMouseDown()
    {
#pragma warning disable CS0618 // Тип или член устарел
        Application.LoadLevel("Main");
#pragma warning restore CS0618 // Тип или член устарел
    }
}
