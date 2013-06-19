using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.collections;

namespace prep.utility.searching
{
    public static class IEnumerableExtensions
    {
        public static ApplicatingExtensionPoint<Target, AttributeType> where<Target, AttributeType>
            (this IEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
        {
            return new ApplicatingExtensionPoint<Target, AttributeType>(movies, accessor);
        }
    }

    public class ApplicatingExtensionPoint<Target, AttributeType>
    {
        public readonly IEnumerable<Target> _items;
        public readonly PropertyAccessor<Target, AttributeType> _accessor;
        public MatchCreationExtensionPoint<Target, AttributeType> _internalMatchCreationXtnPoint;

        public ApplicatingExtensionPoint(IEnumerable<Target> items, PropertyAccessor<Target, AttributeType> accessor)
        {
            _items = items;
            _accessor = accessor;
            _internalMatchCreationXtnPoint = new MatchCreationExtensionPoint<Target, AttributeType>(accessor);
        }

        public IEnumerable<Target> equal_to(AttributeType value)
        {
            return _items.all_items_matching(_internalMatchCreationXtnPoint.equal_to(value));
        }
    }        
}

