import { TicketDTO } from "./../models/dtos/TIcketDTO";
import { TicketAbbrevDTO } from "./../models/dtos/TicketAbbrevDTO";
import Requests from "./agent";

const route = "/tickets";

const TicketActions = {
  all: () => Requests.get<TicketAbbrevDTO[]>(route),
  getById: (id: string) => Requests.getById<TicketDTO>(`${route}/${id}`),
  //   create: (project: CreateProjectRequest) =>
  //     Requests.post<Project>(route, project),
  //   delete: (id: string) => Requests.delete(`${route}/${id}`),
  //   getById: (id: string) => Requests.getById<ProjectDTO>(`${route}/${id}`),
  //   update: (id: string, project: ProjectUpdateDTO) =>
  //     Requests.put<Project>(`${route}/${id}`, project),
};

export default TicketActions;
