import { ProjectDTO } from "./../models/dtos/ProjectDTO";
import { ProjectUpdateDTO } from "./../models/dtos/ProjectUpdateDTO";
import Project from "../models/Project";
import { CreateProjectRequest } from "./../models/project/CreateProjectRequest";
import Requests from "./agent";

const route = "/projects";

const ProjectActions = {
  all: (headers?: any) => Requests.get<Project[]>(route, headers),
  create: (project: CreateProjectRequest, headers?: any) =>
    Requests.post<Project>(route, project, headers),
  delete: (id: string, headers?: any) =>
    Requests.delete(`${route}/${id}`, headers),
  getById: (id: string, headers?: any) =>
    Requests.getById<ProjectDTO>(`${route}/${id}`, headers),
  update: (id: string, project: ProjectUpdateDTO, headers?: any) =>
    Requests.put<Project>(`${route}/${id}`, project, headers),
  page: (params: URLSearchParams, headers?: any) =>
    Requests.getPage<Project[]>(`${route}/page`, params, headers),
};

export default ProjectActions;
