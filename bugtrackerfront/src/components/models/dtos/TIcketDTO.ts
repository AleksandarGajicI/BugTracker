export interface TicketDTO {
  id: string;
  title: string;
  created: string;
  updated: string;
  deadline: string;
  description: string;
  type: string;
  status: {
    id: string;
    status: string;
  };
  reporter: {
    id: string;
    userName: string;
  };
  assignedUsers: string[];
}
