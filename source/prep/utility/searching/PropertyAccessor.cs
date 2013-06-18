namespace prep.utility.searching
{
  public delegate PropertyType PropertyAccessor<in ItemToBuildSpecificationOn, out PropertyType>(ItemToBuildSpecificationOn target);
}