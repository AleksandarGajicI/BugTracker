using BugTracker.contracts.requests.filterAndOrdering;
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
            
            if (string.IsNullOrEmpty(filterValue) || option == ProjectFilterOptions.Default)
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
                        Console.WriteLine("Date is: " + date.Date.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return projectsQuery;
                    }
                    return projectsQuery.Where(p => p.Deadline >= date);

                case ProjectFilterOptions.ByName:
                    Console.WriteLine("Applying name filter");
                    return projectsQuery.Where(p => p.Name.Contains(filterValue));

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

            Console.WriteLine("Order option is: " + options.ToString());
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

        public static ProjectFilterOptions ConvertTStringToProjectFilterOption(this Filter filter)
        {
            switch (filter.FilterProperty.ToLower())
            {
                case "deadline":
                    return ProjectFilterOptions.ByDeadline;
                case "description":
                    return ProjectFilterOptions.ByDescription;
                case "owner":
                    return ProjectFilterOptions.ByOwner;
                case "name":
                    return ProjectFilterOptions.ByName;
                default:
                    return ProjectFilterOptions.Default;
            }
        }

        public static ProjectOrderOptions ConvertTStringToProjectOrderOption(this string filter)
        {
            if (filter == null)
            {
                return ProjectOrderOptions.ByName;
            }

            switch (filter.ToLower())
            {
                case "bydeadline":
                    return ProjectOrderOptions.ByDeadline;
                case "bydeadlinedesc":
                    return ProjectOrderOptions.ByDeadlineDesc;
                case "bynamedesc":
                    return ProjectOrderOptions.ByNameDesc;
                default:
                    return ProjectOrderOptions.ByName;
            }
        }
    }
}
