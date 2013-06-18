namespace prep.utility.searching
{
  public class Where<Target>
  {
    public static CriteriaBuilder<Target, PropertyType> has_a<PropertyType>(
      PropertyAccessor<Target, PropertyType> accessor)
    {
      return new CriteriaBuilder<Target, PropertyType>(accessor);
    }
  }
}