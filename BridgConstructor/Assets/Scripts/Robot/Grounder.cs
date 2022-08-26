using UnityEngine;

public class Grounder : MonoBehaviour
{
    public delegate void GrounderEvent();
    public static GrounderEvent NotGrounder;

    [SerializeField]private float _rayDistacne;

    private void Update() 
    {
        bool isGrounded = chekGround();
        if(isGrounded == false)
            NotGrounder?.Invoke();
        
    }
    private bool chekGround()
    {
        RaycastHit2D groundChecker = Physics2D.Raycast(transform.position, new Vector3(0,-1 * _rayDistacne,0));

        Debug.DrawLine(transform.position,transform.position + new Vector3(0,-1 * _rayDistacne,0), Color.green);

        if(groundChecker)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
