using Castle.DynamicProxy;
using Core.CrossCuttingcConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            // reflected type namespace ve classın ismini verir invocation methodun adını verir.
            var arguments = invocation.Arguments.ToList();
            //metodun parametrelerini listeye çevir 
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //parametre var ise ekler yoksa null geçer
            if (_cacheManager.IsAdd(key)) //cache de bu key varmı kontrol eder
            {
                invocation.ReturnValue = _cacheManager.Get(key);// varsa methodu çalıştırmadan cachemanagerdan getir
                return;
            }
            invocation.Proceed();// yoksa methodu devam ettir
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//son olarak cache e ekler 
        }
    }
}
    