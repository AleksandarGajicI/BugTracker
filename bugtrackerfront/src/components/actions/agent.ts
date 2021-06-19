import { PagedResponse } from "./../models/contracts/PagedResponse";
import axios, { AxiosResponse } from "axios";
import DeleteResponse from "../models/contracts/DeleteReponse";
import MultipleEntityReponse from "../models/contracts/MultipleEntityReponse";
import SingleEntityResponse from "../models/contracts/SingleEntityResponse";
import { LoginResponse } from "../models/dtos/LoginResponse";

axios.defaults.baseURL = "http://localhost:5000/api/v1";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const Requests = {
  get: <T>(url: string) =>
    axios
      .get<MultipleEntityReponse<T>>(url)
      .then(responseBody)
      .then((data) => {
        return data.foundEntitiesDTO;
      }),
  post: <T>(url: string, body: any) =>
    axios
      .post<SingleEntityResponse<T>>(url, body)
      .then(responseBody)
      .then((data) => data.entityDTO),
  put: <T>(url: string, body: {}) =>
    axios
      .put<SingleEntityResponse<T>>(url, body)
      .then(responseBody)
      .then((data) => data.entityDTO),
  delete: (url: string) => axios.delete<DeleteResponse>(url).then(responseBody),
  getById: <T>(url: string) =>
    axios
      .get<SingleEntityResponse<T>>(url)
      .then(responseBody)
      .then((data) => data.entityDTO),
  getPage: <T>(url: string, params: URLSearchParams) =>
    axios
      .get<PagedResponse<T>>(url, { params })
      .then(responseBody)
      .then((data) => data.entitiesDTO),
  login: <T>(url: string, body: any) =>
    axios
      .post<LoginResponse>(url, body)
      .then(responseBody)
      .then((data) => data),
};

export default Requests;
