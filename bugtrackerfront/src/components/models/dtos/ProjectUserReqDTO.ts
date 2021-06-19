export interface ProjectUserReqDTO {
  id: string;
  message: string;
  invitedAt: string;
  project: {
    id: string;
    name: string;
    deadline: string;
  };
  role: {
    id: string;
    roleName: string;
  };
  user: {
    id: string;
    userName: string;
  };
}
