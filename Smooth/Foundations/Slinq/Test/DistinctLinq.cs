using System.Linq;
using UnityEngine;

#if !UNITY_3_5
namespace Smooth.Slinq.Test
{
#endif

    public class DistinctLinq : MonoBehaviour
    {
        private void Update()
        {
            for (var i = 0; i < SlinqTest.loops; ++i) SlinqTest.tuples1.Distinct(SlinqTest.eq_1).Count();
        }
    }

#if !UNITY_3_5
}
#endif