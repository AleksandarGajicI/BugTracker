import { ProjectUserReqCreateDTO } from "./../models/dtos/ProjectUserReqCreateDTO";
import { ProjectUserReqDTO } from "../models/dtos/ProjectUserReqDTO";
import Requests from "./agent";
import { ProjectUserReqReplyDTO } from "../models/dtos/ProjectUserReqReplyDTO";

const route = "/requests";

const ProjectUserReqActions = {
  all: (headers?: any) => Requests.get<ProjectUserReqDTO[]>(route, headers),
  create: (request: ProjectUserReqCreateDTO, headers?: any) =>
    Requests.post<ProjectUserReqDTO>(route, request, headers),
  getSent: (headers?: any) =>
    Requests.get<ProjectUserReqDTO[]>(`${route}/sent`, headers),
  delete: (id: string, headers?: any) =>
    Requests.delete(`${route}/${id}`, headers),
  reply: (body: ProjectUserReqReplyDTO, headers?: any) =>
    Requests.put(`${route}/reply`, body, headers),
};

export default ProjectUserReqActions;
