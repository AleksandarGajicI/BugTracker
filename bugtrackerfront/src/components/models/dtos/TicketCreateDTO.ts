export interface TicketCreateDTO {
  title: string;
  deadline: string;
  description: string;
  ticketType: string;
  reporterId: string;
  projectId: string;
  statusId: string;
}
