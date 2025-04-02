using UnityEngine;

namespace Behaviours
{
    sealed class LineDrawer
    {
        private float _timeStep = 0.05f;
        private int _stepCount = 15;

        private LineRenderer _lineRenderer;
        private Transform _spawnTransform;

        public LineDrawer(LineRenderer lineRenderer, Transform spawnTransform)
        {
            _lineRenderer = lineRenderer;
            _spawnTransform = spawnTransform;
        }

        public void DrawTrajectory(Vector2 velocity)
        {
            Vector3[] trajectoryPositions = new Vector3[_stepCount];
            for (int i = 0; i < _stepCount; i++)
            {
                float time = i * _timeStep;
                Vector3 position = (Vector2)_spawnTransform.position + velocity * time + 0.5f * Physics2D.gravity * time * time;
                trajectoryPositions[i] = position;
            }
            _lineRenderer.positionCount = _stepCount;
            _lineRenderer.SetPositions(trajectoryPositions);
        }
        public void ClearLine()
        {
            _lineRenderer.positionCount = 0;
        }
    }
}
