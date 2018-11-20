using System.Linq;
using UnityEngine;

#if !UNITY_3_5
namespace Smooth.Slinq.Test
{
#endif

    public class UnionLinq : MonoBehaviour
    {
        private void Update()
        {
            for (var i = 0; i < SlinqTest.loops; ++i)
                SlinqTest.tuples1.Union(SlinqTest.tuples2, SlinqTest.eq_1).Count();
        }
    }

#if !UNITY_3_5
}
#endif