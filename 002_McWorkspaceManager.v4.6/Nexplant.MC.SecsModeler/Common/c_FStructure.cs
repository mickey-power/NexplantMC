using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// --
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public struct FBatchModifierJob
    {
        public FBatchModifierType fTargetObjectType;
        public string Target;
        public string Value;

        public FBatchModifierJob(
            FBatchModifierType fTarget,
            string target,
            string value
            )
        {
            fTargetObjectType = fTarget;
            Target = target;
            Value = value;
        }
    }
}
