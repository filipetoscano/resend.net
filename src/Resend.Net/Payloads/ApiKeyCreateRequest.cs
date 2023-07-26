﻿using System.Text.Json.Serialization;

namespace Resend.Net.Payloads;

/// <summary />
internal class ApiKeyCreateRequest
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "permission" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Permission? Permission { get; set; }

    /// <summary />
    [JsonPropertyName( "domain_id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Guid? DomainId { get; set; }
}
