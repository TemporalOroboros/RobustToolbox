﻿using System.Collections.Generic;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;

namespace Robust.Shared.Toolshed.Commands.Entities;

[ToolshedCommand]
internal sealed class ReplaceCommand : ToolshedCommand
{
    [CommandImplementation]
    public IEnumerable<EntityUid> Replace([PipedArgument] IEnumerable<EntityUid> input, EntProtoId prototype)
    {
        var xformSystem = EntityManager.System<SharedTransformSystem>();

        foreach (var i in input)
        {
            var xform = Transform(i);
            var coords = xform.Coordinates;
            var rot = xform.LocalRotation;
            QDel(i); // yeet
            var res = Spawn(prototype, coords);
            xformSystem.SetLocalRotationNoLerp(res, rot);
            yield return res;
        }
    }
}
