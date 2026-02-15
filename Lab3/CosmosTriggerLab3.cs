using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace cosmicworks.functions;

public class CosmosTriggerLab3
{
    private readonly ILogger<CosmosTriggerLab3> _logger;

    public CosmosTriggerLab3(ILogger<CosmosTriggerLab3> logger)
    {
        _logger = logger;
    }

    [Function("CosmosTriggerLab3")]
    public void Run([CosmosDBTrigger(
        databaseName: "cosmicworks",
        containerName: "products",
        Connection = "cosdblab3_DOCUMENTDB",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<MyDocument> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);
            _logger.LogInformation("First document Id: " + input[0].id);
        }
    }
}

public class MyDocument
{
    public string id { get; set; }

    public string Text { get; set; }

    public int Number { get; set; }

    public bool Boolean { get; set; }
}