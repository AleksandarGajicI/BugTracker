export interface CommentDTO {
  id: string;
  message: string;
  created: string;
  commenter: {
    id: string;
    userName: string;
  };
}
