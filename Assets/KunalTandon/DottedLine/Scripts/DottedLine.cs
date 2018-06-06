using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DottedLine
{
    public class DottedLine : MonoBehaviour
    {
        // Inspector fields
        public Sprite Dot;
        [Range(0.01f, 1f)]
        public float Size;
        [Range(0.1f, 2f)]
        public float Delta;

        //Static Property with backing field
        private static DottedLine instance;
        public static DottedLine Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<DottedLine>();
                return instance;
            }
        }

        //Utility fields
        List<Vector2> positions = new List<Vector2>();
        List<GameObject> dots = new List<GameObject>();

        // Update is called once per frame
        void FixedUpdate()
        {
            if (positions.Count > 0)
            {
                DestroyAllDots();
                positions.Clear();
            }

        }

        private void DestroyAllDots()
        {
            foreach (var dot in dots)
            {
                Destroy(dot);
            }
            dots.Clear();
        }

        GameObject GetOneDot()
        {
            var gameObject = new GameObject();
            gameObject.transform.localScale = Vector3.one * Size;
            gameObject.transform.parent = transform;

            var sr = gameObject.AddComponent<SpriteRenderer>();
            sr.sprite = Dot;
            return gameObject;
        }

        public void DrawDottedLine(Vector2 start, Vector2 end)
        {
            DestroyAllDots();

            Vector2 point = start;
            Vector2 direction = (end - start).normalized;

            while ((end - start).magnitude > (point - start).magnitude)
            {
                positions.Add(point);
                point += (direction * Delta);
            }

            Render();
        }

        private void Render()
        {
            foreach (var position in positions)
            {
                var g = GetOneDot();
                g.transform.position = position;
                dots.Add(g);
            }
        }
    }
}