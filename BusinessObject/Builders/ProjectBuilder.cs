using Bogus;
using BusinessObject.Models;

namespace BusinessObject.Builders;

public static class ProjectBuilder
{
    private static readonly Faker<ProjectModel> Faker = new Faker<ProjectModel>()
        .RuleFor(projectModel => projectModel.Name, f => f.Random.String2(1, 5))
        .RuleFor(projectModel => projectModel.Announcement, f => f.Random.String2(1, 30));

    public static ProjectModel GetProject()
    {
        return Faker.Generate();
    }
    
    public static ProjectModel GetEmptyProject()
    {
        return new ProjectModel();
    }
}