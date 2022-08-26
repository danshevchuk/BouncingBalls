using System.Collections;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    [SerializeField] private TextMesh _textMesh;
    [SerializeField] private float bounceAltitude = 2f;
    private Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetIndex(int index){
        if(!_textMesh){
            Debug.LogWarning("Please specify the text mesh reference");
        }
        else{
            _textMesh.text = $"{index}";

            if(index%3==0 && index%5==0){
                ApplyColor(new Color(.8f, 0, 1));
            }
            else if(index%3==0){
                ApplyColor(Color.red);
            }
            else if(index%5==0){
                ApplyColor(Color.blue);
            }
            else {
                ApplyColor(Color.grey);
            }
        }
    }
    private void ApplyColor(Color color){
        if(!_renderer){
            Debug.LogWarning("Please make sure the ball has a 'Renderer' component");
            return;
        }
        _renderer.material.color = color;
    }
 
    public void StartBouncing(Vector3 initialPosition){
        StartCoroutine(BounceEnum(initialPosition));
    }

    private IEnumerator BounceEnum(Vector3 initialPosition){
        Vector3 highestPos = initialPosition + Vector3.up * bounceAltitude;
        if(!_textMesh){
            Debug.LogWarning("Please specify the text mesh reference");
        }
        else{
            _textMesh.transform.parent = null;
            _textMesh.transform.position = initialPosition + Vector3.up * bounceAltitude + Vector3.up;
        }
        transform.localPosition = highestPos;
        float k = 1;
        while(true){
            transform.localPosition = Vector3.Lerp(initialPosition, highestPos, k);
            k = PosFunction(Time.time);
            yield return null;
        }
    }

    private float PosFunction(float x){        
        return (Mathf.Cos(x*2) + 1)/2;
    }
}
