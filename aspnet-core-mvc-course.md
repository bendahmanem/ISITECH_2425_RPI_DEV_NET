# Cours ASP.NET Core MVC (.NET 8.0)

## Table des matières

- [Cours ASP.NET Core MVC (.NET 8.0)](#cours-aspnet-core-mvc-net-80)
  - [Table des matières](#table-des-matières)
  - [Modèle Étudiant](#modèle-étudiant)
  - [Action et Vue Index](#action-et-vue-index)
    - [Action du Contrôleur](#action-du-contrôleur)
    - [Vue](#vue)
  - [Action et Vue ShowDetails](#action-et-vue-showdetails)
    - [Action du Contrôleur](#action-du-contrôleur-1)
    - [Vue](#vue-1)
  - [Tag Helpers et HTML Helpers](#tag-helpers-et-html-helpers)
    - [Tag Helpers](#tag-helpers)
    - [HTML Helpers](#html-helpers)
  - [Data Annotations](#data-annotations)
  - [Action et Vue Add](#action-et-vue-add)
    - [Actions du Contrôleur](#actions-du-contrôleur)
    - [Vue](#vue-2)
  - [Action et Vue Delete](#action-et-vue-delete)
    - [Actions du Contrôleur](#actions-du-contrôleur-1)
    - [Vue](#vue-3)

## Modèle Étudiant

Tout d'abord, définissons notre modèle Étudiant :

```csharp
public class Etudiant
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Age { get; set; }
    public string Specialite { get; set; }
}
```

Pour les données simulées, nous utiliserons une liste statique dans notre contrôleur :

```csharp
private static List<Etudiant> _etudiants = new List<Etudiant>
{
    new Etudiant { Id = 1, Nom = "Alice", Age = 20, Specialite = "Informatique" },
    new Etudiant { Id = 2, Nom = "Bob", Age = 22, Specialite = "Mathématiques" },
    new Etudiant { Id = 3, Nom = "Charlie", Age = 21, Specialite = "Physique" }
};
```

## Action et Vue Index

### Action du Contrôleur

Dans votre `EtudiantsController.cs` :

```csharp
public class EtudiantsController : Controller
{
    public IActionResult Index()
    {
        return View(_etudiants);
    }
}
```

### Vue

Créez `Views/Etudiants/Index.cshtml` :

```html
@model IEnumerable<Etudiant>
  <h2>Liste des Étudiants</h2>

  <table class="table">
    <thead>
      <tr>
        <th>ID</th>
        <th>Nom</th>
        <th>Âge</th>
        <th>Spécialité</th>
        <th>Actions</th>
      </tr>
    </thead>
    <tbody>
      @foreach (var etudiant in Model) {
      <tr>
        <td>@etudiant.Id</td>
        <td>@etudiant.Nom</td>
        <td>@etudiant.Age</td>
        <td>@etudiant.Specialite</td>
        <td>
          <a asp-action="ShowDetails" asp-route-id="@etudiant.Id">Détails</a>
        </td>
      </tr>
      }
    </tbody>
  </table></Etudiant
>
```

## Action et Vue ShowDetails

### Action du Contrôleur

Ajoutez cette méthode à votre `EtudiantsController` :

```csharp
public IActionResult ShowDetails(int id)
{
    var etudiant = _etudiants.FirstOrDefault(e => e.Id == id);
    if (etudiant == null)
    {
        return NotFound();
    }
    return View(etudiant);
}
```

### Vue

Créez `Views/Etudiants/ShowDetails.cshtml` :

```html
@model Etudiant

<h2>Détails de l'Étudiant</h2>

<dl class="row">
  <dt class="col-sm-2">ID</dt>
  <dd class="col-sm-10">@Model.Id</dd>

  <dt class="col-sm-2">Nom</dt>
  <dd class="col-sm-10">@Model.Nom</dd>

  <dt class="col-sm-2">Âge</dt>
  <dd class="col-sm-10">@Model.Age</dd>

  <dt class="col-sm-2">Spécialité</dt>
  <dd class="col-sm-10">@Model.Specialite</dd>
</dl>

<a asp-action="Index">Retour à la Liste</a>
```

## Tag Helpers et HTML Helpers

Les Tag Helpers et HTML Helpers sont tous deux utilisés pour générer du HTML dans vos vues, mais ils ont une syntaxe et des capacités différentes.

### Tag Helpers

Les Tag Helpers sont plus proches du HTML et sont généralement plus faciles à lire et à comprendre. Ils sont traités sur le serveur avant que la vue ne soit rendue.

Exemple :

```html
<a
  asp-controller="Etudiants"
  asp-action="ShowDetails"
  asp-route-id="@etudiant.Id"
  >Détails</a
>
```

Cela génère un lien vers l'action ShowDetails du contrôleur Etudiants, en passant l'ID de l'étudiant comme paramètre de route.

### HTML Helpers

Les HTML Helpers sont des appels de méthodes qui génèrent du HTML. Ils sont plus anciens que les Tag Helpers mais encore largement utilisés.

Exemple :

```html
@Html.ActionLink("Détails", "ShowDetails", new { id = etudiant.Id })
```

Cela génère le même lien que l'exemple de Tag Helper ci-dessus.

## Data Annotations

Les Data Annotations sont des attributs que vous pouvez appliquer aux propriétés du modèle pour spécifier des règles de validation, des noms d'affichage, etc.

Mettons à jour notre modèle Etudiant avec quelques Data Annotations :

```csharp
public class Etudiant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit comporter entre 2 et 50 caractères")]
    public string Nom { get; set; }

    [Range(18, 99, ErrorMessage = "L'âge doit être compris entre 18 et 99")]
    public int Age { get; set; }

    [Required(ErrorMessage = "La spécialité est obligatoire")]
    [Display(Name = "Domaine d'étude")]
    public string Specialite { get; set; }
}
```

Ces annotations ajoutent des règles de validation et personnalisent l'affichage des propriétés dans les formulaires.

## Action et Vue Add

### Actions du Contrôleur

Ajoutez ces méthodes à votre `EtudiantsController` :

```csharp
public IActionResult Add()
{
    return View();
}

[HttpPost]
public IActionResult Add(Etudiant etudiant)
{
    if (ModelState.IsValid)
    {
        etudiant.Id = _etudiants.Max(e => e.Id) + 1;
        _etudiants.Add(etudiant);
        return RedirectToAction(nameof(Index));
    }
    return View(etudiant);
}
```

### Vue

Créez `Views/Etudiants/Add.cshtml` :

```html
@model Etudiant

<h2>Ajouter un Nouvel Étudiant</h2>

<form asp-action="Add">
  <div class="form-group">
    <label asp-for="Nom"></label>
    <input asp-for="Nom" class="form-control" />
    <span asp-validation-for="Nom" class="text-danger"></span>
  </div>
  <div class="form-group">
    <label asp-for="Age"></label>
    <input asp-for="Age" class="form-control" />
    <span asp-validation-for="Age" class="text-danger"></span>
  </div>
  <div class="form-group">
    <label asp-for="Specialite"></label>
    <input asp-for="Specialite" class="form-control" />
    <span asp-validation-for="Specialite" class="text-danger"></span>
  </div>
  <button type="submit" class="btn btn-primary">Ajouter l'Étudiant</button>
</form>

<a asp-action="Index">Retour à la Liste</a>
```

## Action et Vue Delete

### Actions du Contrôleur

Ajoutez ces méthodes à votre `EtudiantsController` :

```csharp
public IActionResult Delete(int id)
{
    var etudiant = _etudiants.FirstOrDefault(e => e.Id == id);
    if (etudiant == null)
    {
        return NotFound();
    }
    return View(etudiant);
}

[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int id)
{
    var etudiant = _etudiants.FirstOrDefault(e => e.Id == id);
    if (etudiant != null)
    {
        _etudiants.Remove(etudiant);
    }
    return RedirectToAction(nameof(Index));
}
```

### Vue

Créez `Views/Etudiants/Delete.cshtml` :

```html
@model Etudiant

<h2>Supprimer l'Étudiant</h2>

<h3>Êtes-vous sûr de vouloir supprimer cet étudiant ?</h3>
<div>
  <h4>Détails de l'Étudiant</h4>
  <hr />
  <dl class="row">
    <dt class="col-sm-2">Nom</dt>
    <dd class="col-sm-10">@Model.Nom</dd>
    <dt class="col-sm-2">Âge</dt>
    <dd class="col-sm-10">@Model.Age</dd>
    <dt class="col-sm-2">Spécialité</dt>
    <dd class="col-sm-10">@Model.Specialite</dd>
  </dl>

  <form asp-action="Delete">
    <input type="hidden" asp-for="Id" />
    <input type="submit" value="Supprimer" class="btn btn-danger" />
    <a asp-action="Index" class="btn btn-secondary">Annuler</a>
  </form>
</div>
```
