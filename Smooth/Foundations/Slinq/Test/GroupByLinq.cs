using System.Linq;
using UnityEngine;

#if !UNITY_3_5
namespace Smooth.Slinq.Test
{
#endif

    public class GroupByLinq : MonoBehaviour
    {
        private void Update()
        {
            for (var i = 0; i < SlinqTest.loops; ++i)
                foreach (var grouping in SlinqTest.tuples1.GroupBy(SlinqTest.to_1f))
                    grouping.Count();
        }
    }

#if !UNITY_3_5
}
#endif