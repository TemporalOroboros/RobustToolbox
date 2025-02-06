using System.Numerics;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;

namespace Robust.Client.Debugging
{
    /// <summary>
    /// A collection of visual debug overlays for the client game.
    /// </summary>
    public sealed class DebugDrawingSystem : EntitySystem
    {
        [Dependency] private readonly IOverlayManager _overlayManager = default!;
        [Dependency] private readonly EntityLookupSystem _lookup = default!;
        [Dependency] private readonly TransformSystem _transform = default!;


        private bool _debugPositions;
        private bool _debugRotations;

        /// <summary>
        /// Toggles the visual overlay of the local origin for each entity on screen.
        /// </summary>
        public bool DebugPositions
        {
            get => _debugPositions;
            set
            {
                if (value == DebugPositions)
                {
                    return;
                }

                _debugPositions = value;

                if (value && !_overlayManager.HasOverlay<EntityPositionOverlay>())
                {
                    _overlayManager.AddOverlay(new EntityPositionOverlay(_lookup, _transform));
                }
                else
                {
                    _overlayManager.RemoveOverlay<EntityPositionOverlay>();
                }
            }
        }

        /// <summary>
        /// Toggles the visual overlay of the local rotation.
        /// </summary>
        public bool DebugRotations
        {
            get => _debugRotations;
            set
            {
                if (value == DebugRotations)
                {
                    return;
                }

                _debugRotations = value;

                if (value && !_overlayManager.HasOverlay<EntityRotationOverlay>())
                {
                    _overlayManager.AddOverlay(new EntityRotationOverlay(_lookup, _transform));
                }
                else
                {
                    _overlayManager.RemoveOverlay<EntityRotationOverlay>();
                }
            }
        }

        private sealed class EntityPositionOverlay : Overlay
        {
            private readonly EntityLookupSystem _lookup;
            private readonly SharedTransformSystem _transform;

            public override OverlaySpace Space => OverlaySpace.WorldSpace;

            public EntityPositionOverlay(EntityLookupSystem lookup, SharedTransformSystem transform)
            {
                _lookup = lookup;
                _transform = transform;
            }

            protected internal override void Draw(in OverlayDrawArgs args)
            {
                const float stubLength = 0.25f;

                var worldHandle = (DrawingHandleWorld) args.DrawingHandle;

                foreach (var entity in _lookup.GetEntitiesIntersecting(args.MapId, args.WorldBounds))
                {
                    var (center, worldRotation) = _transform.GetWorldPositionRotation(entity);

                    var xLine = worldRotation.RotateVec(Vector2.UnitX);
                    var yLine = worldRotation.RotateVec(Vector2.UnitY);

                    worldHandle.DrawLine(center, center + xLine * stubLength, Color.Red);
                    worldHandle.DrawLine(center, center + yLine * stubLength, Color.Green);
                }
            }
        }

        private sealed class EntityRotationOverlay : Overlay
        {
            private readonly EntityLookupSystem _lookup;
            private readonly TransformSystem _xformSystem;

            public override OverlaySpace Space => OverlaySpace.WorldSpace;

            public EntityRotationOverlay(EntityLookupSystem lookup, TransformSystem xformSystem)
            {
                _lookup = lookup;
                _xformSystem = xformSystem;
            }

            protected internal override void Draw(in OverlayDrawArgs args)
            {
                const float stubLength = 0.25f;
                var worldHandle = (DrawingHandleWorld) args.DrawingHandle;

                foreach (var entity in _lookup.GetEntitiesIntersecting(args.MapId, args.WorldBounds))
                {
                    var (center, worldRotation) = _xformSystem.GetWorldPositionRotation(entity);

                    var drawLine = worldRotation.RotateVec(-Vector2.UnitY);

                    worldHandle.DrawLine(center, center + drawLine * stubLength, Color.Red);
                }
            }
        }
    }
}
