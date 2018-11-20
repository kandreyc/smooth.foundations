using System.Linq;
using UnityEngine;

#if !UNITY_3_5
namespace Smooth.Slinq.Test
{
#endif

    public class GroupJoinLinq : MonoBehaviour
    {
        private void Update()
        {
            for (var i = 0; i < SlinqTest.loops; ++i)
                SlinqTest.tuples1.GroupJoin(SlinqTest.tuples2, SlinqTest.to_1f, SlinqTest.to_1f, (a, bs) => bs.Count())
                    .Count();
        }
    }

#if !UNITY_3_5
}
#endif