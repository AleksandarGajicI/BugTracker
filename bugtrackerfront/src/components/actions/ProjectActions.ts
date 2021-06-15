import { ProjectDTO } from "./../models/dtos/ProjectDTO";
import { ProjectUpdateDTO } from "./../models/dtos/ProjectUpdateDTO";
import Project from "../models/Project";
import { CreateProjectRequest } from "./../models/project/CreateProjectRequest";
import Requests from "./agent";

const route = "/projects";

const ProjectActions = {
  all: () => Requests.get<Project[]>(route),
  create: (project: CreateProjectRequest) =>
    Requests.post<Project>(route, project),
  delete: (id: string) => Requests.delete(`${route}/${id}`),
  getById: (id: string) => Requests.getById<ProjectDTO>(`${route}/${id}`),
  update: (id: string, project: ProjectUpdateDTO) =>
    Requests.put<Project>(`${route}/${id}`, project),
};

export default ProjectActions;
