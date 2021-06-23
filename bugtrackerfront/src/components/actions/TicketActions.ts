import { TicketUpdateDTO } from "./../models/dtos/TicketUpdateDTO";
import { TicketDTO } from "./../models/dtos/TIcketDTO";
import { TicketAbbrevDTO } from "./../models/dtos/TicketAbbrevDTO";
import Requests from "./agent";
import { TicketCreateDTO } from "../models/dtos/TicketCreateDTO";

const route = "/tickets";

const TicketActions = {
  all: () => Requests.get<TicketAbbrevDTO[]>(route),
  getById: (id: string, headers?: any) =>
    Requests.getById<TicketDTO>(`${route}/${id}`, headers),
  getForProject: (projectId: string, headers?: any) =>
    Requests.get<TicketAbbrevDTO[]>(`${route}/projects/${projectId}`, headers),
  page: (params: URLSearchParams, headers?: any) =>
    Requests.getPage<TicketAbbrevDTO[]>(route + "/page", params, headers),
  create: (body: TicketCreateDTO, headers?: any) =>
    Requests.post(route, body, headers),
  update: (id: string, body: TicketUpdateDTO, headers?: any) =>
    Requests.put(route + "/" + id, body, headers),
  delete: (id: string, headers?: any) =>
    Requests.delete(`${route}/${id}`, headers),
};

export default TicketActions;
