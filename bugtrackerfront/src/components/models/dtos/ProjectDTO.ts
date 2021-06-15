import { UserOnProjectDTO } from "./UserOnProjectDTO";
import { TicketForProjectDTO } from "./TicketForProjectDTO";

export interface ProjectDTO {
  id: string;
  name: string;
  description: string;
  deadline: string;
  closed: boolean;
  recentTickets: TicketForProjectDTO[];
  usersOnProject: UserOnProjectDTO[];
}
