using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InvertApp.Interfaces;
using InvertApp.Servcices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InvertApp.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMediator(this IServiceCollection services,
            ServiceLifetime lifetime, params Type[] args)
        {
            var handlersInfo = new Dictionary<Type, Type>();

            foreach (var arg in args)
            {
                var assembly = arg.Assembly;
                var requests = GetClasesImplementingInterface(assembly, typeof(IRequest<>));
                var handlers = GetClasesImplementingInterface(assembly, typeof(IRequestHandler<,>));
                
                requests.ForEach(x =>
                {
                    handlersInfo[x] = handlers.SingleOrDefault(q =>
                        x == q.GetInterface("IRequestHandler`2")!.GetGenericArguments()[0]);
                });

                var serviceDescriptiors =
                    handlers.Select(x => new ServiceDescriptor(x, x, lifetime));
                services.TryAdd(serviceDescriptiors);
            }
            services.AddSingleton<IMediator>(x => new Mediator(x.GetRequiredService, handlersInfo));
            
            return services;
        }

        private static List<Type> GetClasesImplementingInterface(Assembly assembly, Type typeToMatch)
        {
            return assembly.ExportedTypes
                .Where(type =>
                {
                    var genericInterfaceTypes =
                        type.GetInterfaces()
                            .Where(i => i.IsGenericType)
                            .ToList();

                    var implementRequestType = genericInterfaceTypes
                        .Any(x => x.GetGenericTypeDefinition() == typeToMatch);

                    return !type.IsInterface && !type.IsAbstract && implementRequestType;
                })
                .ToList();
        }
    }
}