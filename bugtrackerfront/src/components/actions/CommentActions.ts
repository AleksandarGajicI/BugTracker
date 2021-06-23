import { CommentDTO } from "./../models/dtos/CommentDTO";
import { CommentCreateDTO } from "./../models/dtos/CommentCreateDTO";
import Requests from "./agent";

const route = "/comments";

const CommentActions = {
  create: (comment: CommentCreateDTO, headers?: any) =>
    Requests.post<CommentDTO>(route, comment, headers),
  getForTicket: (id: string, params: URLSearchParams, headers?: any) =>
    Requests.getPage<CommentDTO[]>(route + "/page/" + id, params, headers),
  delete: (id: string, headers?: any) =>
    Requests.delete(`${route}/${id}`, headers),
};

export default CommentActions;
