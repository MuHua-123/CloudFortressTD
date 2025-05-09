using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGlobal : TurretComponentAim {
    public override bool IsLockTarget => Target != null;

    public override void AimTarget() {

    }
}
