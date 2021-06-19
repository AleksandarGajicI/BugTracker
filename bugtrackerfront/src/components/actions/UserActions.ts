import { LoginResponse } from "./../models/dtos/LoginResponse";
import { LoginRequest } from "./../models/dtos/LoginRequest";
import { UserCreationDTO } from "../models/dtos/UserCreationDTO";
import { User } from "../models/User";
import { UserNoToken } from "../models/UserNoToken";
import Requests from "./agent";
import { UserDTO } from "../models/dtos/UserDTO";

const route = "/users";

const UserActions = {
  create: (user: UserCreationDTO) => Requests.post<User>("/register", user),
  //treba da se stavi token u header
  getUserFromToken: () => Requests.get<UserNoToken>("/user/token"),
  login: (req: LoginRequest) =>
    Requests.login<LoginResponse>("/users/login", req),
  all: () => Requests.get<UserDTO[]>(route),
};

export default UserActions;
