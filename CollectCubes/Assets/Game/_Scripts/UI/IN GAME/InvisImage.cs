using UnityEngine;
using UnityEngine.UI;

namespace CC.UI
{
    public class InvisImage : Graphic
    {
        //Avoiding Overdraw fillrate issue from GPU
        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            return;
        }
    }
}