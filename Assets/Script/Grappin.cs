using UnityEngine;

public class Grappin : MonoBehaviour
{   
    private Rigidbody2D _rb;
    public LineRenderer _lr;
    public DistanceJoint2D _dj;
    public bool IsGrappin = false; //desole Gilbert
    private Vector3 point;
    
    public LayerMask grappLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
        _dj = GetComponent<DistanceJoint2D>();
        _lr.enabled = false;
        _dj.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapCircle(point, 0.1f, grappLayer))
            {
                _lr.enabled = true; 
                IsGrappin = true;
                _lr.SetPosition(0, transform.position);
                _lr.SetPosition(1, point);
                _dj.enabled = true;
                _dj.connectedAnchor = point;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {   
            IsGrappin = false;
            _lr.enabled = false;
            _dj.enabled = false;
        }

        if (IsGrappin)
        {
            _lr.enabled = true; 
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1,point);
        }
    }
}


