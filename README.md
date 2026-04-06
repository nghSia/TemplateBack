# TemplateBack

Template d'API REST .NET 10 en architecture en couches. Clone, configure ta connection string, et tu pars.

---

## Stack

- **EF Core 10** + **SQL Server** — CRUD
- **Dapper** — requêtes complexes
- **AutoMapper** — mapping entre couches
- **FluentValidation** — validation (à brancher)
- **JWT Bearer** — auth (à brancher)
- **NLog** — logging (à brancher)
- **Scalar** — UI de doc sur `/scalar/v1`

---

## Structure

```
TemplateBack.API/            → Controllers, Middlewares, Modules DI
TemplateBack.Core/           → Interfaces, DTOs, Models, Mappers
TemplateBack.Service/        → Logique métier
TemplateBack.Infrastrucutre/ → EF Context, Entities, Repositories, UnitOfWork
```

---

## Ce qui est prêt

- Architecture 4 couches avec un exemple `Example` complet de bout en bout
- Pattern Repository + Unit of Work
- Middleware de gestion d'erreurs global → retourne du JSON propre
- Mapping `Entity ↔ Model ↔ DTO` via AutoMapper
- Scalar configuré en dev, `/` redirige vers `/scalar/v1`

---

## Démarrer

Ajouter la connection string dans `appsettings.json` :

```json
"ConnectionStrings": {
  "Default": "Server=...;Database=...;"
}
```