using DbEntities;
using ShopApiTestTask.Models;


namespace ShopApiTestTask.Mappers
{
	public interface IMapper<TSource, TDestination>
	{
		TDestination Map(TSource entity);
	}
}