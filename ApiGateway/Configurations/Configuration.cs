using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.LoadBalancing;

namespace ApiGateway.Configurations;

public static class Configuration
{
    public static IReadOnlyList<RouteConfig> GetRoutes()
    {
        return
        [
            //product api
            new RouteConfig
            {
                RouteId = "product-route", //unique identifier for this route
                ClusterId = "product-cluster", //this id is of the Cluster this route maps to
                Match = new RouteMatch
                {
                    Path = "/api/product/{**catch-all}" //url pattern for this route
                },
            },
            //order api
            new RouteConfig
            {
                RouteId = "order-route", //unique identifier for this route
                ClusterId = "order-cluster", //this id is of the Cluster this route maps to
                Match = new RouteMatch
                {
                    Path = "/api/order/{**catch-all}" //url pattern for this route
                },
            }
        ];
    }

    public static IReadOnlyList<ClusterConfig> GetClusters()
    {
        return
        [
            //product api
            new ClusterConfig
            {
                ClusterId = "product-cluster", //unique identifier for this cluster
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
                {
                    {"product-destination-1",new DestinationConfig{Address = "http://localhost:5001"}},
                    {"product-destination-2",new DestinationConfig{Address = "http://localhost:5003"}},
                    {"product-destination-3",new DestinationConfig{Address = "http://localhost:5004"}}
                },
                LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin
            },
            //order api
            new ClusterConfig
            {
                ClusterId = "order-cluster", //unique identifier for this cluster
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
                {
                    { "order-destination",new DestinationConfig {Address = "http://localhost:5002"}}
                }
            }
        ];
    }
}
