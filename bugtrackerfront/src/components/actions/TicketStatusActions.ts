import { TicketStatusDTO } from "../models/dtos/TicketStatusDTO";
import Requests from "./agent";

const route = "/ticketStatus";

const TicketStatusActions = {
  all: () => Requests.get<TicketStatusDTO[]>(route),
};

export default TicketStatusActions;
