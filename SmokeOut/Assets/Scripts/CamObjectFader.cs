using System.Collections.Generic;
using UnityEngine;

public class CamObjectFader : MonoBehaviour
{
    List<ObjectFader> _fader;
    GameObject m_Player;
    private void Awake()
    {
        _fader = new List<ObjectFader>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        if (m_Player == null) return;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDoFade();
    }

    void CheckIfDoFade()
    {
        Vector3 dir = m_Player.transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null) return;
            if (hit.collider.gameObject == m_Player)
            {
                foreach (ObjectFader obj in _fader)
                {
                    if (obj != null)
                    {
                        obj.DoFade = false;
                    }
                }
                _fader.Clear();
            }
            else
            {
                _fader.Add(hit.collider.gameObject.GetComponent<ObjectFader>());
                foreach (ObjectFader obj in _fader)
                {
                    if (obj != null)
                    {
                        obj.DoFade = true;
                    }
                }
            }
        }
    }
}
