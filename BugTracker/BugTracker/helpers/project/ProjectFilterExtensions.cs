using BugTracker.model;
using System;
using System.Linq;

namespace BugTracker.helpers.project
{
    public static class ProjectFilterExtensions
    {
        public static IQueryable<Project> ApplyFilterOption(this IQueryable<Project> projectsQuery,
                                                            ProjectFilterOptions option,
                                                            string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
            {
                return projectsQuery;
            }

            switch (option)
            {
                case ProjectFilterOptions.ByDeadline:
                    DateTime date;
                    try
                    {
                        date = DateTime.Parse(filterValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return projectsQuery;
                    }
                    return projectsQuery.Where(p => p.Deadline >= date);

                case ProjectFilterOptions.ByName:
                    return projectsQuery.Where(p => p.Name == filterValue);

                case ProjectFilterOptions.ByDescription:
                    return projectsQuery.Where(p => p.Description.Contains(filterValue));

                case ProjectFilterOptions.ByOwner:
                    return projectsQuery.Where(p => p.ProjectUsersReq
                                                    .Where(pur => pur.Role.RoleName == "PROJECT_MANAGER")
                                                    .FirstOrDefault()
                                                    .UserAssigned.UserName == filterValue);
                default:
                    return projectsQuery;
            }
        }

        public static IQueryable<Project> ApplySortingOptions(this IQueryable<Project> projectsQuery,
                                                              ProjectOrderOptions options)
        {
            switch (options)
            {
                case ProjectOrderOptions.ByDeadline:
                    return projectsQuery.OrderBy(p => p.Deadline);

                case ProjectOrderOptions.ByDeadlineDesc:
                    return projectsQuery.OrderByDescending(p => p.Deadline);

                case ProjectOrderOptions.ByName:
                    return projectsQuery.OrderBy(p => p.Name);

                case ProjectOrderOptions.ByNameDesc:
                    return projectsQuery.OrderByDescending(p => p.Name);

                default:
                    return projectsQuery;
            }
        }
    }
}
