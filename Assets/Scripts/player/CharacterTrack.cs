using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrack : MonoBehaviour
{
    public static CharacterTrack Instance { set; get; }

    public Shader _drawShader;
    public GameObject _terain;
    public List<Transform> _player;
    [Range(1, 500)]
    public float _brushSize;
    [Range(0, 1)]
    public float _brushStrength;

    private Material _drawMaterial;
    private Material _snowMaterial;
    private RenderTexture _splatmap;

    RaycastHit _groundHit;
    int _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _layerMask = LayerMask.GetMask("Ground");
        _drawMaterial = new Material(_drawShader);
        _terain = GameObject.Find("Snow");

        _snowMaterial = _terain.GetComponent<MeshRenderer>().material;
        _snowMaterial.SetTexture("_Splat", _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat));

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < _player.Count; i++)
        {
            if (Physics.Raycast(_player[i].position, -Vector3.up, out _groundHit, 1f, _layerMask))
            {
                if (_player[i].tag == "Player")
                    _brushSize = 5;
                else
                    _brushSize = 2;

                _drawMaterial.SetVector("_Coordinate", new Vector4(_groundHit.textureCoord.x, _groundHit.textureCoord.y, 0, 0));
                _drawMaterial.SetFloat("_Strength", _brushStrength);
                _drawMaterial.SetFloat("_Size", _brushSize);
                RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
                Graphics.Blit(_splatmap, temp);
                Graphics.Blit(temp, _splatmap, _drawMaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }
    }
}
