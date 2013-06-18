namespace prep.utility.searching
{
  public delegate PropertyType PropertyAccessor<in Target, out PropertyType>(Target target);
}