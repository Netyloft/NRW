using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public abstract class Building : MapObject
{
    [Header("Cost Info")] 
    [SerializeField] private int _woodCost;
    [SerializeField] private int _stoneCost;
    [SerializeField] private int _ironCost;
    [Space(15f)]
    
    public Renderer MainRenderer;
    public NavMeshObstacle _navMeshObstacle;
    
    public Vector2Int Size = Vector2Int.one;

    public void SetTransparent(bool available)
    {
        if (available)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }

    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
        _navMeshObstacle.enabled = true;
        SubtractResources();
        OnBuilt();
    }

    public bool IsCanSubtractResources()
    {
        if (!ResourseCounter.counter.CheckResourceAvailability(_woodCost, _stoneCost, _ironCost))
            return false;

        return true;
    }
    
    private void SubtractResources()
    {
        ResourseCounter.counter.ChangeResource(MapObjectType.Tree, -_woodCost);
        ResourseCounter.counter.ChangeResource(MapObjectType.Stone, -_stoneCost);
        ResourseCounter.counter.ChangeResource(MapObjectType.Iron, -_ironCost);
    }

    protected abstract void OnBuilt();
    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}