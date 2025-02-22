using Microsoft.Extensions.DependencyInjection;

namespace Graphs;

public static class DependencyInjection
{
    public static IServiceCollection AddGraphs(this IServiceCollection services)
    {
        services.AddTransient<Node>();
        services.AddTransient<BreadthFirstSearch.BreadthFirstSearch>();
        services.AddTransient<DepthFirstSearch.DepthFirstSearch>();
        
        services.AddTransient<GraphExample>();
        return services;
    }
    
}