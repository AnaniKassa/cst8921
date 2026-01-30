using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CosmicWorks.Functions;

public class ItemsListener
{
    private readonly ILogger<ItemsListener> _logger;

    public ItemsListener(ILogger<ItemsListener> logger)
    {
        _logger = logger;
    }

    [Function("ItemsListener")]
    public void Run([CosmosDBTrigger(
        databaseName: "cosmicworks",
        containerName: "products",
        Connection = "CosmosDbConnection",
        LeaseContainerName = "productslease",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<dynamic> input)
    {
        if (input != null && input.Count > 0)
        {
            // Log the number of modified documents
            _logger.LogInformation("Documents modified: {Count}", input.Count);

            // Safely cast dynamic id to string before logging
            string firstId = input[0].id?.ToString() ?? "unknown";
            _logger.LogInformation("First document Id: {Id}", firstId);
        }
    }
}
