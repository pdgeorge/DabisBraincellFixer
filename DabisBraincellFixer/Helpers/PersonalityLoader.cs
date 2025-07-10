using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DabisBraincellFixer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DabisBraincellFixer.Helpers;

public static class PersonalityLoader
{
    private static readonly JsonSerializerOptions _jsonOpts =
        new() { PropertyNameCaseInsensitive = true };

    public static SelectList FromFile(string path)
    {
        var json   = File.ReadAllText(path);
        var parsed = JsonSerializer.Deserialize<PersonalityConfig>(json, _jsonOpts)!;
        return new SelectList(parsed.personalities
                               .Select(p => p.personality));
    }

    public static async Task<SelectList> FromGitHubAsync(string rawUrl)
    {
        using var http = new HttpClient();
        var json   = await http.GetStringAsync(rawUrl);
        var parsed = JsonSerializer.Deserialize<PersonalityConfig>(json, _jsonOpts)!;
        return new SelectList(parsed.personalities.Select(p => p.personality));
    }
}