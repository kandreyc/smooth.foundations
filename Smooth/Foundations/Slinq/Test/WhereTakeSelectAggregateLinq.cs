using System.Linq;
using UnityEngine;

#if !UNITY_3_5
namespace Smooth.Slinq.Test
{
#endif

    public class WhereTakeSelectAggregateLinq : MonoBehaviour
    {
        private void Update()
        {
            for (var i = 0; i < SlinqTest.loops; ++i)
                SlinqTest.tuples1.Where(t => true).Take(int.MaxValue).Select(t => t).Aggregate(0, (acc, t) => 0);
        }
    }

#if !UNITY_3_5
}
#endif