using UnityEngine;

public class Grappin : MonoBehaviour
{
    private Rigidbody2D _rb;
    public LineRenderer _lr;
    public DistanceJoint2D _dj;
    public bool IsGrappin = false;
    private Vector3 point;

    public LayerMask grappLayer;

    [SerializeField] private float maxGrapDistance = 8f; // distance max autorisée

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
        _dj = GetComponent<DistanceJoint2D>();
        _lr.enabled = false;
        _dj.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;


            float distance = Vector2.Distance(transform.position, mouseWorld);


            if (distance > maxGrapDistance) // si la distance est trop grande, on n'accroche pas
            {

                Debug.Log("Trop loin pour grappin");
            }
            else
            {
                
                Collider2D hit = Physics2D.OverlapCircle(mouseWorld, 0.12f, grappLayer); // vérifie qu'il y a quelque chose d'accrocheable à la position de la souris 
                if (hit != null)
                {
                    point = hit.ClosestPoint(mouseWorld); // Renvoie la position à partir de laquelle trouver le point le plus proche sur le collider.
                    StartGrapple(distance); // on passe la distance calculée
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }

        if (IsGrappin)
        {
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, point);
        }
    }

    private void StartGrapple(float distance_ball)
    {
        _lr.enabled = true;
        IsGrappin = true;
        _lr.SetPosition(0, transform.position);
        _lr.SetPosition(1, point);
        _dj.enabled = true;
        _dj.connectedAnchor = point;
        
        _dj.distance = distance_ball; //set du distance join par la distance calculé.

    }

    private void StopGrapple()
    {
        IsGrappin = false;
        _lr.enabled = false;
        _dj.enabled = false;
    }


}
