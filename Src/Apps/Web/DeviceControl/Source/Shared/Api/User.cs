// using System.Text.Json.Serialization;
//
// namespace DeviceControl.Source.Shared.Api;
//
// public sealed record User
// {
//     [JsonPropertyName("id")]
//     public required Guid Id { get; init; }
//
//     [JsonPropertyName("createdTimestamp")]
//     public required long CreatedTimestamp { get; init; }
//
//     [JsonPropertyName("username")]
//     public required string Username { get; init; }
//
//     [JsonPropertyName("enabled")]
//     public required bool Enabled { get; init; }
//
//     [JsonPropertyName("totp")]
//     public required bool Totp { get; init; }
//
//     [JsonPropertyName("emailVerified")]
//     public required bool EmailVerified { get; init; }
//
//     [JsonPropertyName("firstName")]
//     public required string FirstName { get; init; }
//
//     [JsonPropertyName("lastName")]
//     public required string LastName { get; init; }
//
//     [JsonPropertyName("federationLink")]
//     public Guid FederationLink { get; init; } = Guid.Empty;
//
//     [JsonPropertyName("attributes")]
//     public Dictionary<string, List<string>> Attributes { get; init; } = new();
//
//     [JsonPropertyName("disableableCredentialTypes")]
//     public required List<object> DisableableCredentialTypes { get; init; }
//
//     [JsonPropertyName("requiredActions")]
//     public required List<object> RequiredActions { get; init; }
//
//     [JsonPropertyName("notBefore")]
//     public required int NotBefore { get; init; }
//
//     [JsonPropertyName("access")]
//     public required Access Access { get; init; }
// }
//
// public sealed record Access
// {
//     [JsonPropertyName("manageGroupMembership")]
//     public required bool ManageGroupMembership { get; init; }
//
//     [JsonPropertyName("view")]
//     public required bool View { get; init; }
//
//     [JsonPropertyName("mapRoles")]
//     public required bool MapRoles { get; init; }
//
//     [JsonPropertyName("impersonate")]
//     public required bool Impersonate { get; init; }
//
//     [JsonPropertyName("manage")]
//     public required bool Manage { get; init; }
// }