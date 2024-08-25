using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectables : MonoBehaviour
{
    [SerializeField] private LayerMask _selectableMask;
    private ISelectable _selected;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            var rayCastHit2D = Physics2D.Raycast(Camera.main.transform.position,
                mouseWorldPos-Camera.main.transform.position, Mathf.Infinity, _selectableMask);
            Debug.Log(rayCastHit2D.transform.gameObject.name);

            if (rayCastHit2D.transform == null)
            {
                if (_selected != null)
                    _selected.Deselect();

                _selected = null;
                return;
            }

            ISelectable selectable = rayCastHit2D.transform.GetComponent<ISelectable>();

            if (selectable != null)
            {
                if (selectable != _selected)
                    selectable.Select();

                if (_selected != null)
                    _selected.Deselect();

                _selected = selectable;
            }
        }
    }
}
