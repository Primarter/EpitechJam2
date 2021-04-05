using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Target : MonoBehaviour
{
    [SerializeField] private float m_alpha;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private SpriteRenderer m_crosshair;

    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private BoxCollider2D thisCollider;
    private bool _isDone = false;

    private Stopwatch stopWatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        stopWatch.Start();
        m_alpha = 0f;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerCollider.IsTouching(this.GetComponent<BoxCollider2D>()) && Input.GetKey(KeyCode.E))
        {
            tagUpdate();
        }

        Color color = new Color(1f, 1f, 1f, m_alpha);
        m_spriteRenderer.color = color;
    }

    void tagUpdate()
    {
        if (_isDone)
            return;
        if (m_alpha >= 1f)
        {
            m_crosshair.enabled = false;
            _isDone = true;
            return;
        }
        if (stopWatch.ElapsedMilliseconds >= 100)
        {
            m_alpha += 0.033f;
            if (m_alpha >= 1f)
            {
                stopWatch.Stop();
            }
            stopWatch.Restart();
        }
    }

    public bool isDone()
    {
        return _isDone;
    }
}
