
using System;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public class ObjectTags : MonoBehaviour
    {
        [SerializeField] private string[] tags;

        public bool HasTag(string tagValue)
        {
            return tags.Any(t => t.Equals(tagValue, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}