import { UserDTO } from "../models/dtos/UserDTO";
import Requests from "./agent";

const route = "/users";

const UserActions = {
  all: () => Requests.get<UserDTO[]>(route),
  //   create: (project: CreateProjectRequest) =>
  //     Requests.post<Project>(route, project),
  //   delete: (id: string) => Requests.delete(`${route}/${id}`),
  //   getById: (id: string) => Requests.getById<ProjectDTO>(`${route}/${id}`),
  //   update: (id: string, project: ProjectUpdateDTO) =>
  //     Requests.put<Project>(`${route}/${id}`, project),
};

export default UserActions;
