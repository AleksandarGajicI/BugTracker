import { RoleDTO } from "./../models/dtos/RoleDTO";
import Requests from "./agent";

const route = "/roles";

const RoleActions = {
  all: () => Requests.get<RoleDTO[]>(route),
};

export default RoleActions;
