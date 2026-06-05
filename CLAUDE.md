# phenotype-terrain

Shared Unity terrain mesh infrastructure for Phenotype-org mods targeting Unity / WorldBox. Provides height-field storage, chunk mesh generation, and LOD management, consumed by sibling Phenotype packages (`phenotype-voxel`, `phenotype-water`).

## Stack

| Layer | Technology |
|-------|------------|
| Language | C# |
| Build | `dotnet build phenotype-terrain.csproj` (Microsoft.NET.Sdk) |
| Target | Unity-friendly runtime surface (no Editor-only API) |
| Consumers | Sibling project references in Unity mods |

## Key Commands

```bash
dotnet build phenotype-terrain.csproj
dotnet test    # when tests exist
```

Unity consumers add the project as a sibling project reference; rebuild after public surface changes.

## Key Files

- `phenotype-terrain.csproj` — Project file (Microsoft.NET.Sdk)
- `src/HeightField.cs` — Per-tile elevation data and world-space Y queries
- `src/ChunkMeshBuilder.cs` — Unity Mesh generation from height-field chunks
- `src/LodManager.cs` — Camera-distance LOD tiers (if present)
- `README.md` — Usage and structure documentation
- `AGENTS.md` — Local agent governance (canonical for working conventions)
- `CONTRIBUTING.md` — Contributor guide (AgilePlus mandate, branch conventions, PR expectations)
- `SECURITY.md` — Vulnerability disclosure path
- `.editorconfig`, `.gitattributes` — formatting / line-ending rules (Unity `.meta` files use `unityyamlmerge`)

## Reference

- **Local source of truth for agent behavior:** `AGENTS.md`
- **Global Phenotype rules:** `~/.claude/CLAUDE.md` or `/Users/kooshapari/CodeProjects/Phenotype/repos/CLAUDE.md`
- **AgilePlus work tracking:** `cd /repos/AgilePlus && agileplus <command>` (required for non-trivial work per the CONTRIBUTING mandate)
- **Sibling shared packages:** `phenotype-voxel`, `phenotype-water` (consumers of this package's interfaces)
