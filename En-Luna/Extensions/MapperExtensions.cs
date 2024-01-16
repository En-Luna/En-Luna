using AutoMapper;
using X.PagedList;

namespace En_Luna.Extensions
{
    public static class MapperExtensions
    {
		/// <summary>
		/// This method converts a paged list from one type to another.
		/// This allows us to use AutoMapper with PagedList.
		/// </summary>
		/// <typeparam name="F">The type to convert from.</typeparam>
		/// <typeparam name="T">The type to convert to.</typeparam>
		/// <param name="source">The source paged list.</param>
		/// <param name="mapper">An instance of IMapper.</param>
		/// <returns>A new paged list of the converted type (typically a view model).</returns>
		public static IPagedList<T> Map<F, T>(this IPagedList<F> source, IMapper mapper)
		{
			List<T> converted = new List<T>();

			foreach (var item in source)
			{
				converted.Add(mapper.Map<T>(item));
			}

			return new StaticPagedList<T>(converted, source.GetMetaData());
		}

		/// <summary>
		/// This method converts an ienumerable from one type to another.
		/// </summary>
		/// <typeparam name="F">The type to convert from.</typeparam>
		/// <typeparam name="T">The type to convert to.</typeparam>
		/// <param name="source">The source paged list.</param>
		/// <param name="mapper">An instance of IMapper.</param>
		/// <returns>A new paged list of the converted type (typically a view model).</returns>
		public static IEnumerable<T> Map<F, T>(this IEnumerable<F> source, IMapper mapper)
		{
			List<T> converted = new List<T>();

			foreach (var item in source)
			{
				converted.Add(mapper.Map<T>(item));
			}

			return converted;
		}
	}
}
