using System.Collections.Generic;

namespace NetCore.BackEnd.Facades.Mappers
{
    public interface IMapper<in TIn, out TOut>
    {
		TOut Map(TIn item);
		IEnumerable<TOut> Map(IEnumerable<TIn> item);
	}
}
