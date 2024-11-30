namespace CarRentalCore.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination MapToDto(TSource source);
        TSource MapToEntity(TDestination destination);
    }

}
