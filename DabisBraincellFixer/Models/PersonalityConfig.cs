using System.Collections.Generic;

namespace DabisBraincellFixer.Models;

/// <summary>Represents one singingular personality</summary>
public record PersonalityItem(string personality, string system);

/// <summary>Bot name</summary>
public record NameItem(string name);

/// <summary>Bot voice</summary>
public record VoiceItem(string voice);

/// <summary>Bot system base prompt</summary>
public record SystemItem(string system);

/// <summary>Matches the root JSON structure:
/// An array of personality items
/// { "personalities": [ { "personality": "...", "system": "..." }, … ] }
/// </summary>
public record PersonalityConfig(IReadOnlyList<PersonalityItem> personalities);