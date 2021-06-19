import { ProjectUserReqCreateDTO } from "./../models/dtos/ProjectUserReqCreateDTO";
import { ProjectUserReqDTO } from "../models/dtos/ProjectUserReqDTO";
import Requests from "./agent";

const route = "/requests";

const ProjectUserReqActions = {
  all: () => Requests.get<ProjectUserReqDTO[]>(route),
  create: (request: ProjectUserReqCreateDTO) =>
    Requests.post<ProjectUserReqDTO>(route, request),
};

export default ProjectUserReqActions;
