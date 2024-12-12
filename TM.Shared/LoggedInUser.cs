

using System.Security.Claims;
using System.Text.Json;

namespace TM.Shared
{
    public record LoggedInUser(int Id, string Name, string Role, string Token)
    {
        public string ToJson() => JsonSerializer.Serialize(this);

        public Claim[] ToClaims() =>
            new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Name, Name),
                new Claim(ClaimTypes.Role, Role),
                new Claim(nameof(Token), Token)
            };

        public static LoggedInUser? LoadFrom(string json) =>
            !string.IsNullOrWhiteSpace(json)
                ? JsonSerializer.Deserialize<LoggedInUser>(json)
                : null;
    }
}
