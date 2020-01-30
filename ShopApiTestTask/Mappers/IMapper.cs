using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApiTestTask.Mappers
{
	public interface IMapper<TSource, TDestination>
	{
		TDestination Map(TSource entity);
	}
}