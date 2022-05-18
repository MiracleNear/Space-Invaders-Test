using System.Collections.Generic;
using UnityEngine;

namespace WaveSystem
{
    [System.Serializable]
    public class RectangleShapeWave : ShapeWave
    {
        [SerializeField] private int _sizeX, _sizeY;
        [SerializeField] private Vector2 _pivot;

        private Vector2 _size = new Vector2(0.5f, 0.5f);

        public override Vector2 Center => new Vector2(_pivot.x + (float) (_sizeX + 1) / 2f, _pivot.y + (float) (_sizeY + 1) / 2f);
        
        public override Vector2 Extents => new Vector2((_sizeX + 1) / 2f, (_sizeY +1) / 2f);

        public override Vector2[] Shape()
        {
            List<Vector2> points = new List<Vector2>();
            
            float startPointX = _pivot.x;
            float startPointY = _pivot.y;
            
            float endPointX = startPointX  +_sizeX;
            float endPointY = startPointY + _sizeY;
      
            
            for(float x = startPointX; x <= endPointX; x++)
            {
                for(float y = startPointY; y <= endPointY; y++)
                {
                    Vector2 point = new Vector2(x, y) + new Vector2(_size.x, _size.y);
                    
                    points.Add(point);
                }
            }

            return points.ToArray();
        }
    }
}