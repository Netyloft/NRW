using DefaultNamespace;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    private Building flyingBuilding;
    private Camera mainCamera;
    
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }
        
        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (flyingBuilding == null) return;
        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            Destroy(flyingBuilding.gameObject);
        }
        
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);

            int x = Mathf.RoundToInt(worldPosition.x);
            int y = Mathf.RoundToInt(worldPosition.z);

            bool available = true;

            if (x < 0 || x > GameMap.xLen - flyingBuilding.Size.x) available = false;
            if (y < 0 || y > GameMap.yLen - flyingBuilding.Size.y) available = false;

            if (available && IsPlaceTaken(x, y)) available = false;

            flyingBuilding.transform.position = new Vector3(x, 0, y);
            flyingBuilding.SetTransparent(available);

            if (available && Input.GetMouseButtonDown(0))
            {
                PlaceFlyingBuilding(x, y);
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (GameMap.map[placeX + x, placeY + y] != MapObjectType.Graund) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                GameMap.map[placeX + x, placeY + y] = MapObjectType.Building;
            }
        }
        
        flyingBuilding.SetNormal();
        flyingBuilding = null;
        //MapController.instance.Build();
    }
}
