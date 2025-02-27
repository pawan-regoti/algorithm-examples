using Microsoft.Extensions.DependencyInjection;

namespace Graphs;

public static class DependencyInjection
{
    public static IServiceCollection AddGraphs(this IServiceCollection services)
    {
        services.AddTransient<Node>();
        
        services.AddTransient<BreadthFirstSearch.BreadthFirstSearch>();
        services.AddTransient<DepthFirstSearch.DepthFirstSearch>();
        services.AddTransient<Prims.PrimsMinimumSpanningTree<Node>>();
        
        services.AddTransient<BreadthFirstSearch.BreadthFirstSearchExample>();
        services.AddTransient<DepthFirstSearch.DepthFirstSearchExample>();
        services.AddTransient<Prims.PrimsMinimumSpanningTreeExample>();
        
        services.AddTransient<GraphExample>();
        return services;
    }
    
}