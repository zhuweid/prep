namespace prep.utility.searching
{
  public class AttributeMatch<ItemWithAttribute, AttributeType> : IMatchA<ItemWithAttribute>
  {
    PropertyAccessor<ItemWithAttribute, AttributeType> accessor;
    IMatchA<AttributeType> value_specification;

    public AttributeMatch(PropertyAccessor<ItemWithAttribute, AttributeType> accessor, IMatchA<AttributeType> value_specification)
    {
      this.accessor = accessor;
      this.value_specification = value_specification;
    }

    public bool matches(ItemWithAttribute item)
    {
      var value = accessor(item);

      return value_specification.matches(value);
    }
  }
}