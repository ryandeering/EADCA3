// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Client-side environment variables don't make such sense, do they now? The Blazor developers seem to agree.", Scope = "member", Target = "~M:EADCA3.Pages.Index.GetDataAsync~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Major Code Smell", "S1118:Utility classes should not have public constructors", Justification = "Impossible to fix with Blazor WebAssembly. Literally the default.", Scope = "type", Target = "~T:EADCA3.Program")]
