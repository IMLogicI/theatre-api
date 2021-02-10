using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Theatre_v2._0.Models;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.Mapping
{
    public static class MappingOperations
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorizationData, DbAccount>().ForMember(trgt => trgt.Email,src => src.MapFrom(elem => elem.Login));
                cfg.CreateMap<DbAccount, AuthorizationData>().ForMember(trgt => trgt.Login, src => src.MapFrom(elem => elem.Email));
            });

            return config.CreateMapper();
        }

        public static List<TResult> MapToList<TSource, TResult>(this IEnumerable source, IMapper mapper) where TSource : class
        {
            if (source == null)
            {
                return new List<TResult>();
            }

            var enumerable = source as IList<object> ?? source.Cast<object>().ToList();

            IEnumerable<TResult> ienumerableDest = mapper.Map<IEnumerable<TSource>, IEnumerable<TResult>>(enumerable.OfType<TSource>());

            return ienumerableDest.ToList();
        }

        public static TResult Map<TResult>(this object source, IMapper mapper) where TResult : class
        {
            return source == null ? null : mapper.Map<TResult>(source);
        }

        public static TResult Map<TSource, TResult>(this TSource source, IMapper mapper) where TSource : class where TResult : class
        {
            return source == null ? null : mapper.Map<TResult>(source);
        }
    }
}