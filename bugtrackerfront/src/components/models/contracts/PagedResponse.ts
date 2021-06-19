export interface PagedResponse<T> {
  errors: string[];
  success: boolean;
  entitiesDTO: T;
  pageNum: number;
  pageSize: number;
}
