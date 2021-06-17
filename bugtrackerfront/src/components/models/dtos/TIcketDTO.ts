export interface TicketDTO {
  id: string;
  title: string;
  created: string;
  updated: string;
  deadline: string;
  description: string;
  type: string;
  status: string;
  reporter: string;
  assignedUsers: string[];
}
